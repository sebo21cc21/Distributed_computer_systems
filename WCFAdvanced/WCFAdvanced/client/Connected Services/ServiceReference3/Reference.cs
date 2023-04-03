﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace client.ServiceReference3 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference3.ISuperCalc", CallbackContract=typeof(client.ServiceReference3.ISuperCalcCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ISuperCalc {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISuperCalc/Factorial")]
        void Factorial(double n);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISuperCalc/Factorial")]
        System.Threading.Tasks.Task FactorialAsync(double n);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISuperCalc/DoSomething")]
        void DoSomething(int sec);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISuperCalc/DoSomething")]
        System.Threading.Tasks.Task DoSomethingAsync(int sec);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISuperCalcCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISuperCalc/FactorialResult")]
        void FactorialResult(double result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ISuperCalc/DoSomethingResult")]
        void DoSomethingResult(string result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISuperCalcChannel : client.ServiceReference3.ISuperCalc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SuperCalcClient : System.ServiceModel.DuplexClientBase<client.ServiceReference3.ISuperCalc>, client.ServiceReference3.ISuperCalc {
        
        public SuperCalcClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public SuperCalcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public SuperCalcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SuperCalcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public SuperCalcClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Factorial(double n) {
            base.Channel.Factorial(n);
        }
        
        public System.Threading.Tasks.Task FactorialAsync(double n) {
            return base.Channel.FactorialAsync(n);
        }
        
        public void DoSomething(int sec) {
            base.Channel.DoSomething(sec);
        }
        
        public System.Threading.Tasks.Task DoSomethingAsync(int sec) {
            return base.Channel.DoSomethingAsync(sec);
        }
    }
}
