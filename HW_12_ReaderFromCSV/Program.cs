using HW_12;
using HW_12_Common;
using HW_12_ReaderFromCSV;

try
{
    string appDataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Constants.AppDataFileName);
    if (!File.Exists(appDataFilePath))
    {
        Console.WriteLine($"Файла {appDataFilePath} не существует");

        return;
    }

    string csvFilePath = File.ReadAllText(appDataFilePath);

    if (!File.Exists(csvFilePath))
    {
        Console.WriteLine($"Файла {csvFilePath} не существует");

        return;
    }
    ElementReaderWorker elementReaderWorker = new ElementReaderWorker();
    List<ArchiveElement> archiveElements = elementReaderWorker.GetElementList(csvFilePath);

    if (!archiveElements.Any())
    {
        Console.WriteLine($"Не удалось получить информацию из csv файла: {csvFilePath}");

        return;
    }

    Console.WriteLine($"Данные из: {Path.GetFileName(csvFilePath)};");

    var orderedfos = archiveElements.OrderBy(i => i.DateChange);
    foreach(var element in orderedfos)
    {
        Console.WriteLine(element);
    }

    File.Delete(appDataFilePath);
} 
catch (Exception ex)
{
    Console.WriteLine($"Произошла непредвиденная ошибка {ex.Message}");
}