using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract1;

namespace WcfServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Krok 1 Utworz URI dla bazowego adresu serwisu.
            Uri baseAddress = new Uri("http://localhost:8080/ICalculator");
            // Krok 2 Utworz instancje serwisu.
            ServiceHost myHost = new
            ServiceHost(typeof(MyCalculator), baseAddress);
            // Krok 3 Dodaj endpoint.
            WSHttpBinding myBinding = new WSHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(
            typeof(ICalculator),
            myBinding,
            "endpoint1");
            BasicHttpBinding binding2 = new BasicHttpBinding();
            ServiceEndpoint endpoint2 = myHost.AddServiceEndpoint(
             typeof(ICalculator),
             binding2, "endpoint2");
            ServiceEndpoint endpoint3 = myHost.Description.Endpoints.Find(
             new Uri("http://localhost:8080/ICalculator/endpoint3"));
            // Krok 4 Ustaw właczenie metadanych.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost.Description.Behaviors.Add(smb);
            try
            {
                // Krok 5 Uruchom serwis.
                myHost.Open();
                Console.WriteLine("Serwis jest uruchomiony.");
                Console.WriteLine("Nacisnij <ENTER> aby zakonczyc.");
                Console.WriteLine();
                Console.ReadLine(); // aby nie kończyć natychmiast: 
                Console.WriteLine("\n---> Endpointy:");
                Console.WriteLine("\nService endpoint {0}:", endpoint1.Name);
                Console.WriteLine("Binding: {0}", endpoint1.Binding.ToString());
                Console.WriteLine("ListenUri: {0}", endpoint1.ListenUri.ToString());
                myHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Wystapil wyjatek: {0}", ce.Message);
                myHost.Abort();
            }
        }
    }
}