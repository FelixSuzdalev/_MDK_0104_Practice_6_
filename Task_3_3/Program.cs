using System;
using System.IO;

namespace Task_3_3
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Вводим данные в файлы");
                FileStream T = new FileStream("T.txt", FileMode.Create, FileAccess.ReadWrite);

                string[] lines = {
                    "Suzdalev +79245453466",
                    "Shevtsov +78484542378",
                    "Vinogradov +75435558900"
                };

                foreach (string line in lines)
                {
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(line + Environment.NewLine);
                    T.Write(bytes, 0, bytes.Length);
                }

                Console.Write("Введите фамилию сотрудника для поиска его номера: ");
                string searchName = Console.ReadLine();
                bool found = false;
                int fileNumber = 1;

                T.Seek(0, SeekOrigin.Begin);
                string lineFromFile;
                while ((lineFromFile = new StreamReader(T).ReadLine()) != null)
                {
                    if (lineFromFile.Contains(searchName))
                    {
                        string[] parts = lineFromFile.Split(' ');
                        File.WriteAllText($"{searchName}_{fileNumber}.txt", $"{searchName} {parts[1]}");
                        found = true;
                        fileNumber++;
                    }
                }

                if (!found)
                {
                    File.WriteAllText("errors.txt", $"Сотрудник с фамилией {searchName} не найден.");
                }

                Console.WriteLine("Готово!");
                T.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}

