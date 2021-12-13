using HW_12_Common;
using HW_12_WriterInCSV;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace HW_12
{
    public class Program
    {
        private static string FilePath { get; } = @"C:\Users\Admin\Desktop\Homework12.zip";
        private static string UnzippedFolderName { get; } = "UnzippedFiles";
        private static string PathToUnzippedFolder { get; } = Path.Combine(Environment.CurrentDirectory, UnzippedFolderName);
        private static string csvFileName { get; } = "CSVFile.csv";
        private static string PathToCSVFile = Path.Combine(Environment.CurrentDirectory, csvFileName);

        static void Main(string[] args)
        {
            try
            {
                ZipFile.ExtractToDirectory(FilePath, PathToUnzippedFolder);
                Console.WriteLine($"Архив успешно распакован в {PathToUnzippedFolder}");
                ElementWriterWorker elementWorker = new ElementWriterWorker();
                List<ArchiveElement> archiveElement = elementWorker.CreateElementList(PathToUnzippedFolder);
                if(archiveElement.Any() == false)
                {
                    Console.WriteLine("Отсутствуют данные для записи");
                    return;
                }
                CSVWorker csvWorker = new CSVWorker();
                if (csvWorker.CreateCSVFile(archiveElement, PathToCSVFile) == false)
                {
                    return;
                }
                Console.WriteLine($"Cоздан CSV файл: {PathToCSVFile}");
                string appDataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.AppDataFileName);
                File.WriteAllText(appDataFilePath, PathToCSVFile);
                Console.WriteLine("Данные записаны в CSV файл");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка {e.Message}");
            }
            finally
            {
                Directory.Delete(PathToUnzippedFolder, true);
            }
        }
    }
}
