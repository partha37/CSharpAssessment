using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    [Serializable]
    class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return string.Format($"Name: {Name}\nID: {Id}\nAddress: {Address}");
        }
    }

    class ConsoleInvoke
    {
        public static void BinarySerialization()
        {

            do
            {
                Console.Write("\nDo You Want to Read or Write? (r/w): \n");
                Console.Write("Pressing any other keys will exit the program!!!!\n");
                string choice = Console.ReadLine();

                if (choice.ToLower() == "w")
                    SerialDeserial.serialize();
                else if (choice.ToLower() == "r")
                    SerialDeserial.deserialize();
                else
                    break;
            } while (true);
        }
    }
    class SerialDeserial
    {
        public static void serialize()
        {
            Employee emp = new Employee { Name = "Parthiban", Id = 14, Address = "Mysore" };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("FileSave.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, emp);
            Console.WriteLine("\nThe Contents of File Are Written to the File");
            Console.WriteLine("-----------------------------------------------");
            fs.Close();
        }

        public static void deserialize()
        {
            FileStream fs = new FileStream("FileSave.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Employee emp = bf.Deserialize(fs) as Employee;
            Console.WriteLine("\nThe Contents of File After Reading");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Employee Name: {emp.Name}");
            Console.WriteLine($"Employee Name: {emp.Id}");
            Console.WriteLine($"Employee Name: {emp.Address}");
            fs.Close();
        }
    }
    class BinarySerialization
    {
        static void Main(string[] args)
        {
            ConsoleInvoke.BinarySerialization();
        }

    }
}