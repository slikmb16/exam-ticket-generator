using System;
using System.IO;
using ClosedXML.Excel;

class Program
{
    private const string FileName = "journal.xlsx";
    private static readonly string[] Headers =
    {
        "Last name", "First name", "Номер билета", "Дата и время"
    };

    static void Main()
    {
        EnsureWorkbookExists();

        Console.WriteLine("Для выхода нажмите ESC.");
        Console.WriteLine(new string('-', 40));

        var random = new Random();

        while (true)
        {
            string? lastName = ReadLastNameWithEsc();
            if (lastName == null)
            {
                Console.WriteLine("\nВыход из программы.");
                break;
            }

            string firstName = ReadNonEmpty("First name: ");
            int ticketNumber = random.Next(1, 21);

            Console.WriteLine($"Билет № {ticketNumber}");

            bool ok = AppendRecordWithRetry(lastName, firstName, ticketNumber);
            Console.WriteLine(ok
                ? "✅ Запись сохранена в journal.xlsx\n"
                : "⚠️ Запись не сохранена.\n");
        }
    }

    static void EnsureWorkbookExists()
    {
        if (File.Exists(FileName)) return;

        using var workbook = new XLWorkbook();
        var ws = workbook.Worksheets.Add("Journal");

        for (int i = 0; i < Headers.Length; i++)
            ws.Cell(1, i + 1).Value = Headers[i];

        // Небольшая красота
        ws.Row(1).Style.Font.Bold = true;
        ws.Columns().AdjustToContents();

        workbook.SaveAs(FileName);
    }

    static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string value = (Console.ReadLine() ?? "").Trim();

            if (!string.IsNullOrWhiteSpace(value))
                return value;

            Console.WriteLine("Поле не может быть пустым. Повторите ввод.");
        }
    }

    static string? ReadLastNameWithEsc()
    {
        while (true)
        {
            Console.Write("Last name: ");
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Escape)
                return null;

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                Console.WriteLine("Поле не может быть пустым. Повторите ввод.");
                continue;
            }

            Console.Write(key.KeyChar);
            string rest = Console.ReadLine() ?? "";
            string full = (key.KeyChar + rest).Trim();

            if (!string.IsNullOrWhiteSpace(full))
                return full;

            Console.WriteLine("Поле не может быть пустым. Повторите ввод.");
        }
    }

    static bool AppendRecordWithRetry(string lastName, string firstName, int ticketNumber)
    {
        while (true)
        {
            try
            {
                using var workbook = new XLWorkbook(FileName);
                var ws = workbook.Worksheet(1);

                int nextRow = ws.LastRowUsed()?.RowNumber() + 1 ?? 2;
                if (nextRow < 2) nextRow = 2;

                ws.Cell(nextRow, 1).Value = lastName;
                ws.Cell(nextRow, 2).Value = firstName;
                ws.Cell(nextRow, 3).Value = ticketNumber;
                ws.Cell(nextRow, 4).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ws.Columns().AdjustToContents();

                // Критично: сохраняем сразу после каждого студента
                workbook.SaveAs(FileName);
                return true;
            }
            catch (IOException)
            {
                Console.WriteLine("\n❌ Не удалось записать в journal.xlsx.");
                Console.WriteLine("Скорее всего файл открыт в Excel. Закройте его и нажмите Enter для повтора.");
                Console.ReadLine();
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\n❌ Нет доступа к journal.xlsx.");
                Console.WriteLine("Проверьте блокировку/права и нажмите Enter для повтора.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Неожиданная ошибка: {ex.Message}");
                return false;
            }
        }
    }
}