using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfServiceContract2
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class StudentService : IStudent
    {
        IStudentCallback callback = null;

        private static List<Student> students;

        public StudentService()
        {
            students = new List<Student>()
            {
                new Student("260402", "Wojciech", "Dominiak", 2.0),
                new Student("260391", "Marcin", "Nowak", 5.5),
                new Student("272727", "Joanna", "Kowalska", 4.97)
            };
            callback = OperationContext.Current.GetCallbackChannel<IStudentCallback>();
        }

        private Student findByIndex(string index)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].index == index)
                {
                    return students[i];
                }
            }
            return null;
        }
        
        public bool addStudent(Student student)
        {
            Console.WriteLine("...adding a student");
            if (findByIndex(student.index) == null)
            {
                students.Add(student);
                Console.WriteLine("added.");
                return true;
            }
            else
            {
                Console.WriteLine("duplicate index.");
                return false;
            }

        }

        public string getAllStudents()
        {
            Console.WriteLine("...getting all students");
            string result = "";
            if (students.Count != 0)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    result += (students[i].index + "\t" + students[i].name + "\t" +
                        students[i].surname + "\t" + students[i].avg_grade + "\n");
                }
            }
            return result;
        }

        public void getStudentByIndex(string index)
        {
            Console.WriteLine("...finding student with index: " + index);
            Thread.Sleep(5000);
            Student found = findByIndex(index);
            callback.getStudentByIndexResult(found);
        }

        public bool removeStudent(string index)
        {
            Console.WriteLine("...removing student with index: " + index);
            Student studentToRemove = findByIndex(index);
            
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.WriteLine("removed.");
                return true;
            }
            else
            {
                Console.WriteLine("not found.");
                return false;
            }
        }
    }
}
