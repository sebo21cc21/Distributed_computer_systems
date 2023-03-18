using mojKalkulator.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WcfServiceClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Krok 1: Utworzenie instancji WCF proxy. 
            //CalculatorClient myClient = new CalculatorClient();
            // Krok 2: Wywolanie kolejnych operacji uslugi. 
            CalculatorClient client1 = new
            CalculatorClient("WSHttpBinding_ICalculator");
            CalculatorClient client2 = new
            CalculatorClient("BasicHttpBinding_ICalculator");
            //CalculatorClient client3 = new CalculatorClient("myEndpoint3");

            Console.WriteLine("Addition");

            //double result = myClient.Add(1, 2);
            double result = client1.Add(1, 2);
            Console.WriteLine(result);

            //result = myClient.Sub(1, 2);
            result = client2.Sub(1, 2);
            Console.WriteLine("Substraction");
            Console.WriteLine(result);

            //result = myClient.Multiply(1, 2);
            //result = client3.Multiply(1, 2);
            Console.WriteLine("Multiplication");
            Console.WriteLine(result);

            result = client1.Summarize(2);
            Console.WriteLine("Client1 First Summarize");
            Console.WriteLine(result);
            result = client1.Summarize(2);
            Console.WriteLine("Client1 Second Summarize");
            Console.WriteLine(result);

            result = client2.Summarize(2);
            Console.WriteLine("Client2 First Summarize");
            Console.WriteLine(result);
            result = client2.Summarize(2);
            Console.WriteLine("Client2 Second Summarize");
            Console.WriteLine(result);

            //result = client3.Summarize(2);
            Console.WriteLine("Client3 First Summarize");
            Console.WriteLine(result);
            //result = client3.Summarize(2);
            Console.WriteLine("Client3 Second Summarize");
            Console.WriteLine(result);
            // Krok 3: Zamknięcie klienta zamyka polaczenie i zasoby.
            //myClient.Close();
        }
    }
}