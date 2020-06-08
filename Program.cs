using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace struct_lab_student
{
    partial class Program
    {
        static Student[] ReadData(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] arr = sr.ReadToEnd().Split('\n');
                Student[] studs = new Student[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    string prev_str;
                    do
                    {
                        prev_str = arr[i];
                        arr[i] = arr[i].Replace("  ", " ");
                    }
                    while (arr[i] != prev_str);
                    if(arr[i] != "")
                    {
                        studs[i] = new Student(arr[i]);
                    }
                }
                return studs;
            }
        }

        static void runMenu(Student[] studs)
        {
            string path = @"data_new.txt";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write("");
            }
            for (int i = 0; i < studs.Length; i++)
            {
                if (Convert.ToInt32(studs[i].mathematicsMark - '0') < 3 || Convert.ToInt32(studs[i].physicsMark - '0') < 3 || Convert.ToInt32(studs[i].informaticsMark - '0') < 3)
                    {
                    studs[i].scholarship = 0;
                    string text = studs[i].firstName + ' ' + studs[i].surName + ' ' + studs[i].patronymic + " Оцінки: " + studs[i].mathematicsMark + ' ' + studs[i].physicsMark + ' ' + studs[i].informaticsMark + " Cтипеднія: " + studs[i].scholarship;
                    Console.WriteLine(text);
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                            {
                                sw.WriteLine(text);
                            }
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(text);
                        }
                    }
                }
            }
        }

        static void Main()
        {
            Student[] studs = ReadData("input.txt");
            runMenu(studs);
            Console.ReadKey();
        }
    }
}
