using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFilesInfo
{
    public class CheckForUpdates
    {
        public string VersionUrl { get; private set; }
        public string CurrentVersion { get; private set; }

        public CheckForUpdates(string versionUrl, string currentVersion)
        {
            VersionUrl = versionUrl;
            CurrentVersion = currentVersion;
        }

        public void Start()
        {
            try
            {
                // Определяем путь к папке temp внутри директории приложения
                string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string tempFolderPath = Path.Combine(appDirectory, "temp");
                Directory.CreateDirectory(tempFolderPath); // Создаём папку temp, если её нет

                // Скачиваем содержимое version.txt в временный файл
                string tempFilePath = Path.Combine(tempFolderPath, "version.txt"); // Используем папку temp
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(VersionUrl, tempFilePath);
                }

                // Читаем файл с помощью StreamReader
                string latestVersion = null;
                string downloadUrl = null;
                using (StreamReader reader = new StreamReader(tempFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim(); // Удаляем лишние пробелы
                        if (line.StartsWith("version=", StringComparison.OrdinalIgnoreCase))
                        {
                            latestVersion = line.Substring("version=".Length).Trim();
                        }
                        else if (line.StartsWith("downloadUrl=", StringComparison.OrdinalIgnoreCase))
                        {
                            downloadUrl = line.Substring("downloadUrl=".Length).Trim();
                        }
                    }
                }

                // Проверяем, что оба значения были найдены
                if (string.IsNullOrEmpty(latestVersion) || string.IsNullOrEmpty(downloadUrl))
                {
                    MessageBox.Show("Неверный формат version.txt: отсутствует version или downloadUrl.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Проверка URL
                if (!Uri.IsWellFormedUriString(downloadUrl, UriKind.Absolute))
                {
                    MessageBox.Show("Неверный формат downloadUrl: URL недействителен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Сравниваем версии
                if (IsNewerVersion(latestVersion))
                {
                    string message = $"Доступна новая версия: {latestVersion}\nТекущая версия: {CurrentVersion}\nЖелаете обновить программу?";
                    DialogResult result = MessageBox.Show(message, "Доступно обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        StartUpdateProcess(downloadUrl, tempFolderPath); // Передаём путь к папке temp
                    }
                }

                // Удаляем временный файл после использования
                File.Delete(tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось проверить обновления: " + ex.Message + "\n\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartUpdateProcess(string downloadUrl, string tempFolderPath)
        {
            try
            {
                // Определяем путь к ZIP-файлу внутри папки temp
                string tempZipPath = Path.Combine(tempFolderPath, "update.zip");

                // Скачиваем ZIP-архив
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine("Url: " + downloadUrl + " Path: " + tempZipPath);
                    client.DownloadFile(downloadUrl, tempZipPath);
                }

                // Определяем путь к updater.exe
                string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "updater.exe");

                Console.WriteLine(tempZipPath);

                // Запускаем updater и передаём путь к ZIP-файлу
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = updaterPath,
                    Arguments = $"\"{@tempZipPath}\"",
                    UseShellExecute = true,
                    Verb = "runas" // Запуск с правами администратора
                };
                Process.Start(startInfo);

                // Завершаем работу основного приложения
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при начале обновления: {ex.Message}\n\n {ex.StackTrace}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool IsNewerVersion(string latestVersion)
        {
            Version latest = new Version(latestVersion);
            Version current = new Version(CurrentVersion);

            if (latest > current)
            {
                return true;
            }

            return false;
        }
    }
}
