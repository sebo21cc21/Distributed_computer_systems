using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceContract2;

namespace WcfServiceHost2
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:10000/studentservice");
            // Krok 2 Utworz instancje serwisu.
            ServiceHost myHost = new ServiceHost(typeof(StudentService), baseAddress);
            // Krok 3 Dodaj endpoint.
            WSDualHttpBinding myBinding = new WSDualHttpBinding();
            ServiceEndpoint endpoint1 = myHost.AddServiceEndpoint(
                                            typeof(IStudent),
                                            myBinding,
                                            "endpoint1");
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
