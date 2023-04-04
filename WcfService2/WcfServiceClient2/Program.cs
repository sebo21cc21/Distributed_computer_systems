using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceClient2.ServiceReference1;

namespace WcfServiceClient2
{
    class StudentCallback : IStudentCallback
    {
        public void getStudentByIndexResult(Student result)
        {
            if (result != null)
            {
                Console.WriteLine("Student found!");
                Console.WriteLine(result.index + "\t" + result.name + "\t" + result.surname + "\t" + result.avg_grade);
            }
            else
                Console.WriteLine("Student not found!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client started");
            string input;
            string output;
            bool finished = false;

            StudentCallback myCbBHandler = new StudentCallback();
            InstanceContext instanceContext = new InstanceContext(myCbBHandler);
            StudentClient client = new StudentClient(instanceContext);
            
            while (!finished)
            {
                Console.WriteLine("Choose option");
                Console.WriteLine("1 - get all students");
                Console.WriteLine("2 - get student by index number");
                Console.WriteLine("3 - add a student");
                Console.WriteLine("4 - remove a student");
                Console.WriteLine("other - finish");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("trying to get all students...");
                        output = client.getAllStudents();
                        Console.WriteLine(output);
                        break;

                    case "2":
                        Console.WriteLine("Type index number: ");
                        input = Console.ReadLine();
                        Console.WriteLine("You have to wait for the result... ");
                        client.getStudentByIndex(input);
                        break;

                    case "3":
                        Console.WriteLine("Type index number: ");
                        string index = Console.ReadLine();
                        Console.WriteLine("Type name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Type surname: ");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Type average grade");
                        double avg_grade = Convert.ToDouble(Console.ReadLine());
                        Student toAdd = new Student(index, name, surname, avg_grade);
                        bool added = client.addStudent(toAdd);
                        if (added)
                            Console.WriteLine("Student added successfully!");
                        else
                            Console.WriteLine("Student with this index number already exists!");
                        break;

                    case "4":
                        Console.WriteLine("Type index number: ");
                        input = Console.ReadLine();
                        bool removed = client.removeStudent(input);
                        if (removed)
                            Console.WriteLine("Student removed successfully!");
                        else
                            Console.WriteLine("Student with this index number does not exist!");
                        break;

                    default:
                        finished = true;
                        break;

                }
            }
            client.Close();
        }
    }
}
