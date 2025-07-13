using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Hashing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFilesInfo
{
    public partial class frmMain : Form
    {
        private readonly CheckForUpdates checkForUpdates = new CheckForUpdates(CurrentVersion, "YOUR-GiTHUB-APIKEY");
        private const string CurrentVersion = "1.2.0";

        private readonly List<MyFolderInfo> Folders = [];
        private readonly Dictionary<Sorts, (Func<MyFileInfo, object> selector, bool ascending)> _sortStrategies = new()
{
    { Sorts.FilePath,            (f => f.FilePath, true) },
    { Sorts.NameAsc,             (f => f.FileName, true) },
    { Sorts.NameDesc,            (f => f.FileName, false) },
    { Sorts.PagesAsc,            (f => f.PageCount ?? 0, true) },
    { Sorts.PagesDesc,           (f => f.PageCount ?? 0, false) },
    { Sorts.HashAsc,              (f => f.FileHash, true) },
    { Sorts.HashDesc,             (f => f.FileHash, false) },
    { Sorts.FileExtensionAsc,    (f => f.FileExtension, true) },
    { Sorts.FileExtensionDesc,   (f => f.FileExtension, false) }
};

        private static string FolderMessage(string Folder)
        {
            return $"\n\n[------------------------------------------------------------ Выбранная папка: \"{Folder}\"; SHA-256 Хэш  ------------------------------------------------------------]\n\n";
        }

        public frmMain()
        {
            InitializeComponent();

            btSortByFilePath.Tag = Sorts.FilePath;
            btSortByNameAsc.Tag = Sorts.NameAsc;
            btSortByNameDesc.Tag = Sorts.NameDesc;
            btSortByPagesAsc.Tag = Sorts.PagesAsc;
            btSortByPagesDesc.Tag = Sorts.PagesDesc;
            btSortByHashAsc.Tag = Sorts.HashAsc;
            btSortByHashDesc.Tag = Sorts.HashDesc;
            btSortByExtensionAsc.Tag = Sorts.FileExtensionAsc;
            btSortByExtensionDesc.Tag = Sorts.FileExtensionDesc;
        }

        private void SelectFolder()
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    txtPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            EnableUI(false);
            SelectFolder();
            EnableUI(true);
        }

        private void EnableUI(bool enable)
        {
            txtPath.Enabled = enable;
            btView.Enabled = enable;
            chbShouldNumerable.Enabled = enable;
            btSortByHashAsc.Enabled = enable;
            btSortByHashDesc.Enabled = enable;
            btSortByExtensionAsc.Enabled = enable;
            btSortByExtensionDesc.Enabled = enable;
            btSortByFilePath.Enabled = enable;
            btSortByNameAsc.Enabled = enable;
            btSortByNameDesc.Enabled = enable;
            btSortByPagesAsc.Enabled = enable;
            btSortByPagesDesc.Enabled = enable;
            btStart.Enabled = enable;
            btExport.Enabled = enable;
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            EnableUI(false);

            for (int i = 0; i < 3; i++)
            {
                string FolderPath = txtPath.Text;

                if (!string.IsNullOrEmpty(FolderPath) && Directory.Exists(FolderPath))
                {
                    await Task.Run(() => UpdateUI(FolderMessage(FolderPath)));
                    await ProcessFilesAsync(FolderPath);
                    txtPath.Text = FolderPath;
                    break;
                }
                else if (string.IsNullOrEmpty(FolderPath))
                {
                    SelectFolder();
                }
                else if (!Directory.Exists(FolderPath))
                {
                    MessageBox.Show("Указанная директория не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            EnableUI(true);
        }

        int Id;
        private async Task ProcessFilesAsync(string folderPath)
        {
            List<MyFileInfo> fileList = new List<MyFileInfo>();
            int symbolsCount = folderPath.Length;

            foreach (var file in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    string fileName = Path.GetFileName(file);
                    string fileHash = "";
                    string fileExtension = Path.GetExtension(file);

                    int? pdfPageCount = null;

                    using (SHA256 sha256 = SHA256.Create())
                    {
                        using (FileStream fileStream = File.OpenRead(file))
                        {
                            byte[] hashBytes = await sha256.ComputeHashAsync(fileStream);

                            fileHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                        }
                    }

                    if (fileExtension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        using PdfDocument pdf = PdfDocument.Load(file);
                        pdfPageCount = pdf.PageCount;
                    }

                    string filePath = Path.GetDirectoryName(file).Remove(0, symbolsCount);

                    fileList.Add(new MyFileInfo
                    {
                        FilePath = filePath,
                        FileName = fileName,
                        FileExtension = fileExtension,
                        PageCount = pdfPageCount,
                        FileHash = fileHash
                    });
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            Folders.Add(new MyFolderInfo
            {
                FolderId = Id,
                FolderPath = folderPath,
                FolderFiles = fileList
            });

            Id++;

            UpdateUIFromList(fileList);
        }

        private void UpdateUI(string message)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new MethodInvoker(() => UpdateUI(message)));
            }
            else
            {
                txtLog.AppendText(message);
                Debug.WriteLine(message);

                txtLog.SelectionStart = txtLog.TextLength;
                txtLog.ScrollToCaret();
            }
        }

        #region Sort
        private void SortButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Sorts sortType)
            {
                SortBy(sortType);
            }
        }

        private void SortBy(Sorts sortBy)
        {
            if (Folders.Count == 0)
                return;

            txtLog.Clear();

            if (!_sortStrategies.TryGetValue(sortBy, out var strategy))
            {
                MessageBox.Show("Неизвестный тип сортировки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var folder in Folders)
            {
                UpdateUI(FolderMessage(folder.FolderPath));
                SortAndDisplay(folder.FolderFiles, strategy.selector, strategy.ascending);
            }
        }

        private void SortAndDisplay(List<MyFileInfo> fileList, Func<MyFileInfo, object> keySelector, bool ascending = true)
        {
            var sortedList = ascending
                ? fileList.OrderBy(keySelector).ToList()
                : fileList.OrderByDescending(keySelector).ToList();

            UpdateUIFromList(sortedList);
        }

        private void UpdateUIFromList(List<MyFileInfo> fileList)
        {
            bool shouldNumerable = chbShouldNumerable.Checked;
            int fileNum = 1;

            foreach (var fileInfo in fileList)
            {
                string fileNumInfo = "";
                string pageCountInfo = fileInfo.PageCount.HasValue ? $"Страниц: {fileInfo.PageCount};" : "";

                if (shouldNumerable)
                {
                    fileNumInfo = $"{fileNum}. ";
                }

                string message = $"{fileNumInfo}Путь к файлу: {fileInfo.FilePath};     Имя файла: {fileInfo.FileName};     {pageCountInfo}     Хэш файла: {fileInfo.FileHash};\n";

                if (shouldNumerable)
                {
                    fileNum++;
                }

                UpdateUI(message);
            }
        }
        #endregion

        private async void tsmCheckForUpdates_Click(object sender, EventArgs e)
        {
            EnableUI(false);
            await checkForUpdates.Start();
            EnableUI(true);
        }

        private void tsmAboutInfo_Click(object sender, EventArgs e)
        {
            string aboutProgrammInfoMsg = $"О программе:\r\n\r\nНазвание программы: {Process.GetCurrentProcess().ProcessName}\r\nВерсия: {CurrentVersion}\r\nЯзык программирования: c#\r\nПлатформа: Windows ({RuntimeInformation.FrameworkDescription})\r\nТип приложения: WinForms\r\nПрограмма предназначена для облегчения работы с экспертизами за счёт отображения информации о файлах внутри указанной директории.";
            string aboutAuthorInfoMsg = "\r\n\r\nО разработчике:\r\n\r\nИмя: Глазов Михаил\r\nEmail: glazalmazgl@gmail.com\r\nGitHub: https://github.com/Glaz-almaz-GL";
            MessageBox.Show(aboutProgrammInfoMsg + aboutAuthorInfoMsg, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLog.Text))
            {
                MessageBox.Show("Вывод пустой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog folderBrowserDialog = new SaveFileDialog())
            {
                folderBrowserDialog.FileName = "GetFilesInfo Output.txt";
                folderBrowserDialog.Filter = "Text File |*.txt";
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.FileName))
                {
                    File.WriteAllText(folderBrowserDialog.FileName, txtLog.Text);
                }
            }
        }
    }
}