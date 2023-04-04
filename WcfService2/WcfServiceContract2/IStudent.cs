using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract2
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract (SessionMode = SessionMode.Required, CallbackContract = typeof(IStudentCallback))]
    public interface IStudent
    {
        [OperationContract(IsOneWay = true)]
        void getStudentByIndex(string index);

        [OperationContract]
        string getAllStudents();

        [OperationContract]
        bool addStudent(Student student);

        [OperationContract]
        bool removeStudent(string index);
    }

    public interface IStudentCallback
    {
        [OperationContract(IsOneWay = true)]
        void getStudentByIndexResult(Student result);
    }

    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    // Możesz dodać pliki XSD do projektu. Po skompilowaniu projektu możesz bezpośrednio użyć zdefiniowanych w nim typów danych w przestrzeni nazw „WcfServiceContract2.ContractType”.
    [DataContract]
    public class Student
    {
        [DataMember]
        public string index { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string surname { get; set; }

        [DataMember]
        public double avg_grade { get; set; }

        public Student(string index, string name, string surname, double avg_grade)
        {
            this.index = index;
            this.name = name;
            this.surname = surname;
            this.avg_grade = avg_grade;
        }
    }
}
