using System;
using System.IO;
using System.Net;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Podaj format (XML lub JSON): ");
                    string format = Console.ReadLine().ToLower();
                    Console.WriteLine("Podaj metodę (GET, POST, ...): ");
                    string method = Console.ReadLine();
                    Console.WriteLine("Podaj URI: ");
                    string uri = Console.ReadLine();

                    HttpWebRequest req = WebRequest.Create(uri) as HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = method.ToUpper();

                    if (format == "xml")
                        req.ContentType = "text/xml";
                    else if (format == "json")
                        req.ContentType = "application/json";
                    else
                    {
                        Console.WriteLine("Nieprawidłowe dane!");
                        return;
                    }

                    switch (method.ToUpper())
                    {
                        case "GET":
                            break;
                        case "POST":
                            Console.WriteLine("Wklej zawartosc XMLa lub JSONa (w jednej linii!)");
                            string data = Console.ReadLine();
                            byte[] buffer = Encoding.UTF8.GetBytes(data);
                            req.ContentLength = buffer.Length;
                            Stream postData = req.GetRequestStream();
                            postData.Write(buffer, 0, buffer.Length);
                            postData.Close();
                            break;
                        default:
                            break;
                    }

                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
                    string responseString = responseStream.ReadToEnd();
                    responseStream.Close();
                    resp.Close();
                    Console.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Czy chcesz kontynuować? (t/n)");
            }
            while (Console.ReadLine().ToUpper() == "T");
        }
    }
}
