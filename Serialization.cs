using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }

        public override string ToString()
        {

            return string.Format($"The name :{Name} with id {Id} from Address {Address} is available at phone {Phone}");

        }
    }

    class Serialization
    {
        static void Main(string[] args)
        {
            binaryExample();

        }

        private static void binaryExample()
        {
            Console.WriteLine("What do U want to do today: Read or Write");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "read")
                deserializing();
            else
                serializing();
        }

        private static void serializing()
        {
            Student s = new Student { Id = 111, Name = "Sahana", Address = "Mysuru", Phone = 971771777787 };
            BinaryFormatter fm = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, s);
            fs.Close();
        }

        private static void deserializing()
        {
            try
            {
                FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
                BinaryFormatter fm = new BinaryFormatter();
                Student s = fm.Deserialize(fs) as Student;
                Console.WriteLine(s.Name);
                fs.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception" + ex.Message);
            }
        }
       

      
           
        }
    }



