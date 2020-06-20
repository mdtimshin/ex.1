using System;
using System.IO;
using System.Linq;

namespace ex._1_console_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFile = "input.txt", outputFile = "output.txt";

                string[] stroki = File.ReadAllLines(inputFile);
                string[] nmx = stroki[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int x = int.Parse(nmx[2]), m = int.Parse(nmx[1]);
                int Si = 0, Sj = 0, count = 0, SiLenght, SjLenght;

                string[] S = new string[stroki.Length - 1];
                for (int i = 1; i < stroki.Length; i++)
                {
                    S[i - 1] = stroki[i];
                }



                for (int i = 0; i <= stroki.Length - 3; i++)
                {
                    for (int j = i + 1; j <= stroki.Length - 2; j++)
                    {
                        SiLenght = S[i].Length;
                        SjLenght = S[j].Length;
                        for (int a = 0; a < SiLenght; a++)
                        {
                            Si = Si + (int)(int.Parse(S[i][a].ToString()) * Math.Pow(x, a));
                        }
                        bool oki = true, okj = true;
                        if (Si == 0) oki = false;
                        Si = Si % m;

                        for (int a = 0; a < SjLenght; a++)
                        {
                            Sj = Sj + (int)(int.Parse(S[j][a].ToString()) * Math.Pow(x, a));
                        }
                        if (Sj == 0) okj = false;
                        Sj = Sj % m;

                        if ((Si == Sj) && (oki == okj))
                        {
                            count++;
                        }
                        Si = 0;
                        Sj = 0;
                    }
                }
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.Write(count);
                }
                Console.WriteLine("\nOUTPUT.TXT\nКоличество строк, для которых выполняется условие = " + count);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Файл input.txt не найден.");
            }
            catch (System.FormatException)
            {
                Console.WriteLine("В файле должны присутствовать только числа");
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Файл input.txt пуст");
            }
        }
    }
}
