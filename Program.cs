using System;
using System.IO;
using System.Linq;
//using System.Diagnostics;

namespace ex._1_console_
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.txt", outputFile = "output.txt";
            //using (FileStream fs = new FileStream(inputFile, FileMode.OpenOrCreate)) { }
            string[] stroki = File.ReadAllLines(inputFile);
            string[] nmx = stroki[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //int n = int.Parse(nmx[0]), 
            int x = int.Parse(nmx[2]), m = int.Parse(nmx[1]);
            int Si = 0, Sj = 0, count = 0, SiLenght, SjLenght;

            string[] S = new string[stroki.Length - 1];
            for (int i = 1; i < stroki.Length; i++)
            {
                S[i - 1] = stroki[i];
            }



            for (int i = 0; i <= stroki.Length-3; i++)
            {
                for (int j = i + 1; j <= stroki.Length-2; j++)
                {
                    SiLenght = S[i].Length;
                    SjLenght = S[j].Length;
                    for(int a=0; a<SiLenght; a++)
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







                    //s = S[i];
                    //SiLenght = (int)Math.Log10(S[i]) + 1;
                    //SjLenght = (int)Math.Log10(S[j]) + 1;
                    //for (int a = SiLenght - 1; a >= 0; a--)
                    //{
                    //    Si = Si + (int)(Math.Truncate(s / (Math.Pow(10, a))) * Math.Pow(x, SiLenght - a - 1));
                    //    s = (int)(s - Math.Truncate(s / (Math.Pow(10, a))) * (Math.Pow(10, a)));
                    //}
                    //Si = Si % m;

                    //s = S[j];
                    //for (int a = SjLenght - 1; a >= 0; a--)
                    //{
                    //    Sj = Sj + (int)(Math.Truncate(s / (Math.Pow(10, a))) * Math.Pow(x, SjLenght - a - 1));
                    //    s = (int)(s - Math.Truncate(s / (Math.Pow(10, a))) * (Math.Pow(10, a)));
                    //}
                    //Sj = Sj % m;

                    if ((Si == Sj)&&(oki==okj))
                    {
                        count++;
                    }
                    Si = 0;
                    Sj = 0;
                }
            }
            //using (FileStream fs = new FileStream(outputFile, FileMode.OpenOrCreate)) { }
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.Write(count);
            }
            Console.WriteLine("\nOUTPUT.TXT\n\n" + count);
            //return 0;
        }
    }
}
