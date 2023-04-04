﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceClient2.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Student", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceContract2")]
    [System.SerializableAttribute()]
    public partial class Student : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double avg_gradeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string indexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string surnameField;

        public Student(string index, string name, string surname, double avg_grade)
        {
            this.index = index;
            this.name = name;
            this.surname = surname;
            this.avg_grade = avg_grade;
        }

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double avg_grade {
            get {
                return this.avg_gradeField;
            }
            set {
                if ((this.avg_gradeField.Equals(value) != true)) {
                    this.avg_gradeField = value;
                    this.RaisePropertyChanged("avg_grade");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string index {
            get {
                return this.indexField;
            }
            set {
                if ((object.ReferenceEquals(this.indexField, value) != true)) {
                    this.indexField = value;
                    this.RaisePropertyChanged("index");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string surname {
            get {
                return this.surnameField;
            }
            set {
                if ((object.ReferenceEquals(this.surnameField, value) != true)) {
                    this.surnameField = value;
                    this.RaisePropertyChanged("surname");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IStudent", CallbackContract=typeof(WcfServiceClient2.ServiceReference1.IStudentCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IStudent {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStudent/getStudentByIndex")]
        void getStudentByIndex(string index);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStudent/getStudentByIndex")]
        System.Threading.Tasks.Task getStudentByIndexAsync(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudent/getAllStudents", ReplyAction="http://tempuri.org/IStudent/getAllStudentsResponse")]
        string getAllStudents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudent/getAllStudents", ReplyAction="http://tempuri.org/IStudent/getAllStudentsResponse")]
        System.Threading.Tasks.Task<string> getAllStudentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudent/addStudent", ReplyAction="http://tempuri.org/IStudent/addStudentResponse")]
        bool addStudent(WcfServiceClient2.ServiceReference1.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudent/addStudent", ReplyAction="http://tempuri.org/IStudent/addStudentResponse")]
        System.Threading.Tasks.Task<bool> addStudentAsync(WcfServiceClient2.ServiceReference1.Student student);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudent/removeStudent", ReplyAction="http://tempuri.org/IStudent/removeStudentResponse")]
        bool removeStudent(string index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudent/removeStudent", ReplyAction="http://tempuri.org/IStudent/removeStudentResponse")]
        System.Threading.Tasks.Task<bool> removeStudentAsync(string index);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStudentCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStudent/getStudentByIndexResult")]
        void getStudentByIndexResult(WcfServiceClient2.ServiceReference1.Student result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStudentChannel : WcfServiceClient2.ServiceReference1.IStudent, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StudentClient : System.ServiceModel.DuplexClientBase<WcfServiceClient2.ServiceReference1.IStudent>, WcfServiceClient2.ServiceReference1.IStudent {
        
        public StudentClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public StudentClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public StudentClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StudentClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StudentClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void getStudentByIndex(string index) {
            base.Channel.getStudentByIndex(index);
        }
        
        public System.Threading.Tasks.Task getStudentByIndexAsync(string index) {
            return base.Channel.getStudentByIndexAsync(index);
        }
        
        public string getAllStudents() {
            return base.Channel.getAllStudents();
        }
        
        public System.Threading.Tasks.Task<string> getAllStudentsAsync() {
            return base.Channel.getAllStudentsAsync();
        }
        
        public bool addStudent(WcfServiceClient2.ServiceReference1.Student student) {
            return base.Channel.addStudent(student);
        }
        
        public System.Threading.Tasks.Task<bool> addStudentAsync(WcfServiceClient2.ServiceReference1.Student student) {
            return base.Channel.addStudentAsync(student);
        }
        
        public bool removeStudent(string index) {
            return base.Channel.removeStudent(index);
        }
        
        public System.Threading.Tasks.Task<bool> removeStudentAsync(string index) {
            return base.Channel.removeStudentAsync(index);
        }
    }
}