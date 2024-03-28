
using System;
using System.IO;
namespace Task_3_2
{
    class Class1
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Программа, которая выводит из любых 10 символов только цифры");
                FileStream fchar = new FileStream("test1.txt", FileMode.Create, FileAccess.ReadWrite);
                char[] x = new char[10];
                Console.WriteLine("Введите 10 символов");
                for (int i = 0; i < 10; ++i)
                {
                    x[i] = (char)Console.Read();
                    fchar.WriteByte((byte)x[i]);
                }
                Console.ReadLine();
                int a;
                fchar.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < 10; i++)
                {
                    a = fchar.ReadByte();
                    if ((a >= 48) && (a <= 57))
                    {
                        Console.Write((char)a + " ");
                    }
                }
                Console.WriteLine();

                fchar.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}//dsdsdsd