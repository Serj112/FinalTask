using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Runtime;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace FinalTask 
{
    class Program
    {
        static string pathdesktop = @"C:\\Users\Toshka\Desktop\Students\";

        static string GetPath(string Group)
        {
            return pathdesktop + Group + ".dat";
        }

        static void Main(string[] args)
        {
            string path = @"C:\\Skillfactory\1\Students.dat";
            

            if (!Directory.Exists(pathdesktop))
            {
                Directory.CreateDirectory(pathdesktop);
            }

            BinaryFormatter formatter = new BinaryFormatter();


            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Student[] students = (Student[])formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Student student in students)
                {
                    var fileInfo = new FileInfo(GetPath(student.Group));

                    using (StreamWriter sw = fileInfo.AppendText())
                    {
                        sw.WriteLine($"{student.Name}, {student.Date}");
                    }
                }
            }

        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime Date { get; set; }

        public Student(string name, string group, DateTime date)
        {
            Name = name;
            Group = group;
            Date = date;
        }
    }

    

}
