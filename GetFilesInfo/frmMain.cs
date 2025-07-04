using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Hashing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFilesInfo
{
    public partial class frmMain : Form
    {
        private string CurrentVersion = "1.1.0";
        private string VersionUrl = "https://raw.githubusercontent.com/Glaz-almaz-GL/Get-Files-Info/refs/heads/main/version.txt";
        private bool ShouldNumerable;

        private static string FolderMessage(string Folder)
        {
            return $"\n\n[------------------------------------------------------------ Выбранная папка: {Folder}; Длина CRC = 64  ------------------------------------------------------------]\n\n";
        }

        List<MyFolderInfo> Folders = new List<MyFolderInfo>();
        int Id = 0;

        public frmMain()
        {
            CheckForUpdates checkForUpdates = new CheckForUpdates(VersionUrl, CurrentVersion);
            checkForUpdates.Start();

            InitializeComponent();
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
            SelectFolder();
        }

        private void EnableUI(bool enable)
        {
            txtPath.Enabled = enable;
            btView.Enabled = enable;
            chbShouldNumerable.Enabled = enable;
            btSortByCRCAsc.Enabled = enable;
            btSortByCRCDesc.Enabled = enable;
            btSortByExtensionAsc.Enabled = enable;
            btSortByExtensionDesc.Enabled = enable;
            btSortByFilePath.Enabled = enable;
            btSortByNameAsc.Enabled = enable;
            btSortByNameDesc.Enabled = enable;
            btSortByPagesAsc.Enabled = enable;
            btSortByPagesDesc.Enabled = enable;
            btStart.Enabled = enable;
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            EnableUI(false);

            string FolderPath = txtPath.Text;

            await Task.Run(() => UpdateUI($"\n\n[------------------------------------------------------------ Выбранная папка: {FolderPath} ------------------------------------------------------------]\n\n"));

            if (!string.IsNullOrEmpty(FolderPath))
            {
                await ProcessFilesAsync(FolderPath);
            }
            else
            {
                MessageBox.Show("Путь некорректный или пустой", "Ошибка");
            }

            EnableUI(true);
        }

        private async Task ProcessFilesAsync(string folderPath)
        {
            List<MyFileInfo> fileList = new List<MyFileInfo>();
            int symbolsCount = folderPath.Length;

            foreach (var file in Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    string fileName = Path.GetFileName(file);
                    string fileCRC = "";
                    string fileExtension = Path.GetExtension(file);

                    int? pdfPageCount = null;

                    using (FileStream fileStream = File.OpenRead(file))
                    {
                        var crc64 = new Crc64();
                        await crc64.AppendAsync(fileStream);

                        fileCRC = BitConverter.ToString(crc64.GetCurrentHash());
                    }

                    if (fileExtension.Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        using (PdfDocument pdf = PdfDocument.Load(file))
                        {
                            pdfPageCount = pdf.PageCount;
                        }
                    }

                    string filePath = Path.GetDirectoryName(file).Remove(0, symbolsCount);

                    fileList.Add(new MyFileInfo
                    {
                        FilePath = filePath,
                        FileName = fileName,
                        FileExtension = fileExtension,
                        PageCount = pdfPageCount,
                        FileCRC = fileCRC
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

            // Обновляем UI на основе текущего списка
            UpdateUIFromList(fileList);
        }

        private void UpdateUIFromList(List<MyFileInfo> fileList)
        {
            int fileNum = 1;

            foreach (var fileInfo in fileList)
            {
                string fileNumInfo = "";
                string pageCountInfo = fileInfo.PageCount.HasValue ? $"Страниц: {fileInfo.PageCount};" : "";

                if (ShouldNumerable)
                {
                    fileNumInfo = $"{fileNum}. ";
                }

                string message = $"{fileNumInfo}Путь к файлу: {fileInfo.FilePath}; Имя файла: {fileInfo.FileName}; {pageCountInfo} Значение CRC: {fileInfo.FileCRC};\n";

                if (ShouldNumerable)
                {
                    fileNum++;
                }

                UpdateUI(message);
            }
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
                Console.WriteLine(message);

                txtLog.SelectionStart = txtLog.TextLength;
                txtLog.ScrollToCaret();
            }
        }

        private void SortAndDisplay(List<MyFileInfo> fileList, Func<MyFileInfo, object> keySelector, bool ascending = true)
        {
            var sortedList = ascending ? fileList.OrderBy(keySelector).ToList() : fileList.OrderByDescending(keySelector).ToList();
            UpdateUIFromList(sortedList);
        }

        private void btSortByFilePath_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FilePath);
                }
            }
        }

        private void btSortByNameAsc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FileName);
                }
            }
        }

        private void btSortByNameDesc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FileName, false);
                }
            }
        }

        private void btSortByPagesAsc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.PageCount ?? 0);
                }
            }
        }

        private void btSortByPagesDesc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.PageCount ?? 0, false);
                }
            }
        }

        private void btSortByCRCAsc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FileCRC);
                }
            }
        }

        private void btSortByCRCDesc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FileCRC);
                }
            }
        }

        private void btSortByExtensionAsc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FileExtension);
                }
            }
        }

        private void btSortByExtensionDesc_Click(object sender, EventArgs e)
        {
            if (Folders.Count > 0)
            {
                txtLog.Clear(); // Очищаем текущий текст
                foreach (var Folder in Folders)
                {
                    UpdateUI(FolderMessage(Folder.FolderPath));
                    SortAndDisplay(Folder.FolderFiles, f => f.FileExtension, false);
                }
            }
        }

        private void chbShouldNumerable_CheckedChanged(object sender, EventArgs e)
        {
            ShouldNumerable = chbShouldNumerable.Checked;
        }
    }
}