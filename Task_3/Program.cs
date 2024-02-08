using System.IO;
using System;

namespace Task_3
{
    class Class1
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Вводим данные в файлы");
                FileStream f = new FileStream("test1.txt", FileMode.Create, FileAccess.ReadWrite);
                Random rand = new Random();
                byte[] x = new byte[10];

                for (byte i = 0; i < 10; ++i)
                {
                    x[i] = (byte)rand.Next();
                }
                f.Write(x, 0, 10);
                for (int i = 0; i < 10; i++)
                {
                    f.ReadByte();
                }
                string inf_file1 = string.Join(", ", x);
                Console.WriteLine("Файл 1: {0}", inf_file1);
                f.Close();

                Console.WriteLine();

                FileStream g = new FileStream("test2.txt", FileMode.Create, FileAccess.ReadWrite);
                byte[] z = new byte[10];

                for (byte i = 0; i < 10; ++i)
                {
                    z[i] = (byte)rand.Next();
                }
                g.Write(z, 0, 10);
                for (int i = 0; i < 10; i++)
                {
                    g.ReadByte();
                }
                string inf_file2 = string.Join(", ", z);
                Console.WriteLine("Файл 2: {0}", inf_file2);
                Console.WriteLine();
                g.Close();

                Console.WriteLine("Обмениваем данные в файлах");
                FileStream f1 = new FileStream("test1.txt", FileMode.Open, FileAccess.ReadWrite);
                byte[] b1 = new byte[10];
                f1.Read(b1, 0, 10);

                FileStream f2 = new FileStream("test2.txt", FileMode.Open, FileAccess.ReadWrite);
                byte[] b2 = new byte[10];
                f2.Read(b2, 0, 10);


                f1.Seek(0, SeekOrigin.Begin);
                f2.Seek(0, SeekOrigin.Begin);
                f1.Write(b2, 0, 10);
                f2.Write(b1, 0, 10);
                f1.Seek(0, SeekOrigin.Begin);
                f2.Seek(0, SeekOrigin.Begin);

                f1.Read(b1, 0, 10);
                f2.Read(b2, 0, 10);
                f1.Seek(0, SeekOrigin.Begin);
                f2.Seek(0, SeekOrigin.Begin);


                string fString = string.Empty;
                fString = string.Join(", ", b1);
                Console.WriteLine("Файл 1: {0}", fString);

                Console.WriteLine();
                
                f1.Close();
                fString = string.Join(", ", b2);
                Console.WriteLine("Файл 2: {0}", fString);
                f2.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }   
        }
    }
 }