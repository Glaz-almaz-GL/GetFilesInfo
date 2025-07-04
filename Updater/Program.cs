using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Ошибка: Не указан путь к ZIP-файлу.");
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Environment.Exit(1);
                        break;
                    }
                }
            }

            string zipPath = @args[0]; // Путь к ZIP-файлу
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory; // Директория основного приложения

            // Создание пользовательской папки "temp" внутри директории приложения
            string tempFolderPath = Path.Combine(appDirectory, "temp");
            string extractPath = Path.Combine(tempFolderPath, "update");

            // Создание необходимых папок
            Directory.CreateDirectory(tempFolderPath);
            Directory.CreateDirectory(extractPath);

            KillProcess("GetFilesInfo");

            // Скачивание и распаковка ZIP-архива
            DownloadAndExtract(zipPath, extractPath);

            // Обновление файлов
            UpdateApplication(extractPath, appDirectory);

            // Перезапуск приложения
            RestartApplication(appDirectory);

            // Очистка временных файлов
            CleanUpTemporaryFiles();

            Environment.Exit(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обновлении: {ex.Message}\n\n{ex.StackTrace}");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    Environment.Exit(1);
                    break;
                }
            }
        }
    }

    private static void DownloadAndExtract(string zipPath, string extractPath)
    {
        Console.WriteLine("Начинается распаковка...");
        ZipFile.ExtractToDirectory(zipPath, extractPath);
        Console.WriteLine("Распаковка завершена.");
    }

    private static void UpdateApplication(string sourceDir, string targetDir)
    {
        Console.WriteLine($"Обновление файлов: {targetDir}");
        DeleteDirectoryContents(targetDir, targetDir); // Передаём baseDirectory для проверки
        CopyDirectory(sourceDir, targetDir);
        Console.WriteLine("Обновление файлов завершено.");
    }

    private static void RestartApplication(string appDirectory)
    {
        string mainAppPath = Path.Combine(appDirectory, "GetFilesInfo.exe");
        if (File.Exists(mainAppPath))
        {
            Console.WriteLine("Перезапуск приложения...");
            Process.Start(mainAppPath);
        }
        else
        {
            Console.WriteLine("Ошибка: Главное приложение не найдено.");
        }
    }

    private static void KillProcess(string processName)
    {
        try
        {
            foreach (Process process in Process.GetProcessesByName(processName))
            {
                process.Kill();
                process.WaitForExit(); // Подождать завершения процесса
                Console.WriteLine($"Процесс {processName} завершён.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Не удалось закрыть процесс {processName}: {ex.Message}");
        }
    }

    // Метод для удаления всех файлов и папок в указанной директории
    private static bool IsSafeToDelete(string path, string baseDirectory)
    {
        // Нормализуем пути для корректного сравнения
        string fullPath = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
        string fullBaseDirectory = Path.GetFullPath(baseDirectory).TrimEnd(Path.DirectorySeparatorChar);

        // Если путь является самой папкой temp, то не удаляем
        string tempFolder = Path.Combine(fullBaseDirectory, "temp");
        return !string.Equals(fullPath, tempFolder, StringComparison.OrdinalIgnoreCase);
    }

    private static void DeleteDirectoryContents(string directoryPath, string baseDirectory)
    {
        if (!Directory.Exists(directoryPath))
        {
            return;
        }

        foreach (string file in Directory.GetFiles(directoryPath))
        {
            try
            {
                if (!Path.GetFileNameWithoutExtension(file).Contains("Updater"))
                {
                    File.SetAttributes(file, FileAttributes.Normal); // Убираем атрибут "только для чтения"
                    File.Delete(file);
                    Console.WriteLine($"Удалён файл: {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось удалить файл {file}: {ex.Message}");
            }
        }

        foreach (string dir in Directory.GetDirectories(directoryPath))
        {
            try
            {
                // Проверяем, безопасно ли удалять эту папку
                if (IsSafeToDelete(dir, baseDirectory))
                {
                    Directory.Delete(dir, recursive: true); // Рекурсивно удаляем подпапки
                    Console.WriteLine($"Удалена папка: {dir}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось удалить папку {dir}: {ex.Message}");
            }
        }
    }

    // Метод для рекурсивного копирования директории
    private static void CopyDirectory(string sourceDir, string targetDir)
    {
        if (!Directory.Exists(targetDir))
        {
            Directory.CreateDirectory(targetDir);
            Console.WriteLine($"Создана папка: {targetDir}");
        }

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            try
            {
                string destinationFile = Path.Combine(targetDir, Path.GetFileName(file));
                File.Copy(file, destinationFile, true); // true — перезапись существующих файлов
                Console.WriteLine($"Скопирован файл: {destinationFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось скопировать файл {file}: {ex.Message}");
            }
        }

        foreach (string dir in Directory.GetDirectories(sourceDir))
        {
            string subdirName = Path.GetFileName(dir);
            string targetSubdir = Path.Combine(targetDir, subdirName);
            CopyDirectory(dir, targetSubdir);
        }
    }

    // Метод для очистки временных файлов
    private static void CleanUpTemporaryFiles()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string tempFolder = Path.Combine(baseDirectory, "temp");

        try
        {
            // Удаление временной папки
            if (Directory.Exists(tempFolder))
            {
                Directory.Delete(tempFolder, true); // Рекурсивно удаляем папку и её содержимое
                File.Delete(tempFolder);
                Console.WriteLine($"Временная папка удалена: {tempFolder}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при удалении временных файлов: {ex.Message}");
        }
    }
}