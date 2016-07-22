using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Student_assignment5
{
    class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                const char DELIM = ',';
                Console.WriteLine("Enter the name of the File");
                string FILENAME = Console.ReadLine();
                if (File.Exists(FILENAME))
                {
                    FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(inFile);
                    string recordIn;
                    string[] fields;
                    Console.WriteLine("\n{0,-5}{1,-12}{2,8}\n", "Name", "Class", "Grade");
                    recordIn = reader.ReadLine();
                    while (recordIn != null)
                    {
                        recordIn = reader.ReadLine();
                        Student std = new Student();
                        fields = recordIn.Split(DELIM);
                        std.Name = fields[0];
                        std.Class = fields[1];
                        std.Grade = fields[2];
                        std.ID = fields[3];
                        Console.WriteLine("{0,5}{1,12}{2,8}{3,10}", std.Name, std.Class, std.Grade, std.ID);
                        recordIn = reader.ReadLine();
                    }
                    reader.Close();
                    inFile.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
