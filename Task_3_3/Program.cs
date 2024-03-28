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

                T.Seek(0, SeekOrigin.Begin);
                string lineFromFile = string.Empty;
                byte[] bytesFromFile = new byte[1024];


                {
                    int index = 0;
                    int b = 0;
                    while (true)
                    {
                        b = T.ReadByte();
                        if (b == -1)
                            break;
                        bytesFromFile[index++] = (byte)b;
                    }

                    for (int i = 0; i != index - 1; ++i)
                    {
                        char ch = (char)bytesFromFile[i];
                        lineFromFile += ch;
                    }
                }
                //Clear from \r symbol
                string[] stringsFromFile = lineFromFile.Split('\n');
                for (int i = 0; i != stringsFromFile.Length; ++i)
                    stringsFromFile[i] = stringsFromFile[i].Remove(stringsFromFile[i].Length - 1, 1);


                foreach (string s in stringsFromFile)
                {
                    if (lineFromFile.Contains(searchName))
                    {
                        string[] parts = s.Split(' ');

                        FileStream outfile = new FileStream($"{searchName}.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        byte[] byteOutString = System.Text.Encoding.UTF8.GetBytes($"{searchName} {parts[1]}");
                        outfile.Write(byteOutString, 0, byteOutString.Length);
                        found = true;
                        outfile.Close();
                        Console.WriteLine($"Сотрудник с фамилией {searchName} найден");
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine($"Сотрудник с фамилией {searchName} не найден");
                    FileStream fileStream = new FileStream("errors.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    fileStream.Seek(0, SeekOrigin.End);
                    byte[] byteOutString = System.Text.Encoding.UTF8.GetBytes($"Сотрудник с фамилией {searchName} не найден\n");
                    fileStream.Write(byteOutString, 0, byteOutString.Length);
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
