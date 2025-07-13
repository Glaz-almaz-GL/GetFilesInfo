using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetFilesInfo
{
    public class CheckForUpdates(string currentVersion, string githubToken)
    {
        public string CurrentVersion { get; private set; } = currentVersion;
        public string GithubToken { get; private set; } = githubToken;

        public const string owner = "Glaz-almaz-GL";
        public const string repo = "GetFilesInfo";

        public async Task Start()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string tempFolderPath = Path.Combine(appDirectory, "temp");

            try
            {
                var latestRelease = await GetLatestRelease(owner, repo, GithubToken);

                if (latestRelease == null)
                    return;

                string latestVersion = latestRelease["tag_name"].ToString().Replace("v", "");

                var assets = latestRelease["assets"] as JArray;
                string downloadUrl;

                if (assets.Count > 0)
                {
                    var firstAsset = assets[0];
                    downloadUrl = firstAsset["browser_download_url"]?.ToString();
                }
                else
                {
                    MessageBox.Show("В релизе нет файлов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Directory.CreateDirectory(tempFolderPath);

                if (string.IsNullOrEmpty(latestVersion) || string.IsNullOrEmpty(downloadUrl))
                {
                    MessageBox.Show("Неверный формат version.txt: отсутствует version или downloadUrl.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Uri.IsWellFormedUriString(downloadUrl, UriKind.Absolute))
                {
                    MessageBox.Show("Неверный формат downloadUrl: URL недействителен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (IsNewerVersion(latestVersion))
                {
                    string message = $"Доступна новая версия: {latestVersion}\nТекущая версия: {CurrentVersion}\nЖелаете обновить программу?";
                    DialogResult result = MessageBox.Show(message, "Доступно обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        await StartUpdateProcess(downloadUrl, tempFolderPath);
                    }
                }
                else
                {
                    MessageBox.Show($"Уже установлена последняя версия: {CurrentVersion}", "Обновление не требуется", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось проверить обновления: " + ex.Message + "\n\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task<JObject> GetLatestRelease(string owner, string repo, string GithubToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.UserAgent.ParseAdd("C# App");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github+json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GithubToken);
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");

            string url = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject release = JObject.Parse(responseBody);

                    string htmlUrl = release["html_url"]?.ToString();

                    if (!string.IsNullOrEmpty(htmlUrl))
                    {
                        return release;
                    }
                    else
                    {
                        UpdateUI("Не удалось извлечь 'html_url' из ответа.");
                    }
                }
                else
                {
                    UpdateUI($"Ошибка при запросе новейшей версии: {(int)response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                UpdateUI($"Исключение: {ex.Message}");
            }

            return null;
        }

        private static async Task StartUpdateProcess(string downloadUrl, string tempFolderPath)
        {
            try
            {
                string tempZipPath = Path.Combine(tempFolderPath, "update.zip");

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        using var response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
                        response.EnsureSuccessStatusCode();

                        await using var stream = await response.Content.ReadAsStreamAsync();
                        await using var fileStream = new FileStream(tempZipPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);

                        await stream.CopyToAsync(fileStream);
                    }
                    catch (HttpRequestException e)
                    {
                        UpdateUI($"Ошибка HTTP: {e.Message}");
                    }
                    catch (Exception e)
                    {
                        UpdateUI($"Общая ошибка: {e.Message}");
                    }
                }

                string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "updater.exe");

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = updaterPath,
                    Arguments = $"\"{@tempZipPath}\"",
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(startInfo);
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

        private static void UpdateUI(string msg, string msgName = "")
        {
            Debug.WriteLine($"[{DateTime.Now}] {msg}");
            MessageBox.Show(msg, msgName);
        }
    }
}
