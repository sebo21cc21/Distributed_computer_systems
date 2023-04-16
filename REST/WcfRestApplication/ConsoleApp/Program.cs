using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static readonly string uri = "http://localhost:51727/Service1.svc/";
        static void Menu()
        {
            Console.WriteLine("Wybierz czynność:");
            Console.WriteLine("1 - wyświetlenie listy produktów");
            Console.WriteLine("2 - wyświetlenie pojedynczego produktu");
            Console.WriteLine("3 - dodanie nowego produktu");
            Console.WriteLine("4 - edycja danych produktu");
            Console.WriteLine("5 - usunięcie produktu");
        }

        static string AskFormat()
        {
            Console.WriteLine("Format odpowiedzi (domyślny: XML): ");
            string format = Console.ReadLine();
            return format.ToLower();
        }

        static void EncodeRequest(HttpWebRequest req, string reqContent)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(reqContent);
            req.ContentLength = buffer.Length;
            Stream postData = req.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();
        }

        static string EncodeResponse(HttpWebResponse resp)
        {
            Encoding enc = Encoding.GetEncoding(1252);
            StreamReader responseStream = new StreamReader(resp.GetResponseStream(), enc);
            string responseString = responseStream.ReadToEnd();
            responseStream.Close();
            resp.Close();
            return responseString;
        }

        static string CreateRequestContent(string id, string format)
        {
            Console.WriteLine("Nazwa: ");
            string name = Console.ReadLine();
            Console.WriteLine("Waga: ");
            string weight = Console.ReadLine();
            Console.WriteLine("Cena: ");
            string price = Console.ReadLine();

            string requestContent;

            if (format.ToLower() == "json")
            {
                requestContent = "{";
                if (id != "")
                    requestContent += $"\"ID\":\"{id}\",";
                if (name != "")
                    requestContent += $"\"name\":\"{name}\",";
                if (weight != "")
                    requestContent += $"\"weight\":{weight},";
                if (price != "")
                    requestContent += $"\"price\":{price}";
                requestContent += "}";
            }
            else
            {
                requestContent = "<Product xmlns=\"http://schemas.datacontract.org/2004/07/WcfRestApplication\">";
                if (id != "")
                    requestContent += $"<ID>{id}</ID>";
                if (name != "")
                    requestContent += $"<name>{name}</name>";
                if (weight != "")
                    requestContent += $"<weight>{weight}</weight>";
                if (price != "")
                    requestContent += $"<price>{price}</price>";
                requestContent += "</Product>";
            }

            return requestContent;
        }

        static void GetAll(string format)
        {
            HttpWebRequest req;
            
            if (format == "json")
                req = WebRequest.Create(uri + "json/products") as HttpWebRequest;
            else
                req = WebRequest.Create(uri + "products") as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            string response = EncodeResponse(resp);
            Console.WriteLine(response);
        }

        static void GetById(string id, string format)
        {
            HttpWebRequest req;

            if (format == "json")
                req = WebRequest.Create(uri + "json/products/" + id) as HttpWebRequest;
            else
                req = WebRequest.Create(uri + "products/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            string response = EncodeResponse(resp);
            Console.WriteLine(response);
        }

        static void Add(string format)
        {
            HttpWebRequest req;

            if (format == "json")
            {
                req = WebRequest.Create(uri + "json/products") as HttpWebRequest;
                req.ContentType = "text/json";
            }
            else
            {
                req = WebRequest.Create(uri + "products") as HttpWebRequest;
                req.ContentType = "text/xml";
            }
            req.KeepAlive = false;
            req.Method = "POST";

            string requestContent = CreateRequestContent("", format);
            EncodeRequest(req, requestContent);
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            string response = EncodeResponse(resp);
            Console.WriteLine(response);
        }

        static void Update(string id, string format)
        {
            HttpWebRequest req;

            if (format == "json")
            {
                req = WebRequest.Create(uri + "json/products") as HttpWebRequest;
                req.ContentType = "text/json";
            }
            else
            {
                req = WebRequest.Create(uri + "products") as HttpWebRequest;
                req.ContentType = "text/xml";
            }
            req.KeepAlive = false;
            req.Method = "PUT";

            string requestContent = CreateRequestContent(id, format);
            EncodeRequest(req, requestContent);
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            string response = EncodeResponse(resp);
            Console.WriteLine(response);
        }

        static void Delete(string id, string format)
        {
            HttpWebRequest req;

            if (format == "json")
                req = WebRequest.Create(uri + "json/products/" + id) as HttpWebRequest;
            else
                req = WebRequest.Create(uri + "products/" + id) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = "DELETE";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            string response = EncodeResponse(resp);
            Console.WriteLine(response);
        }
        
        static void Main()
        {
            string id;
            string format;

            do
            {
                try
                {
                    Menu();
                    string option = Console.ReadLine();
              
                    switch(option)
                    {
                        case "1":
                            format = AskFormat();
                            GetAll(format);
                            break;

                        case "2":
                            Console.WriteLine("Podaj ID produktu: ");
                            id = Console.ReadLine();
                            format = AskFormat();
                            GetById(id, format);
                            break;

                        case "3":
                            format = AskFormat();
                            Add(format);
                            break;

                        case "4":
                            Console.WriteLine("Podaj ID produktu: ");
                            id = Console.ReadLine();
                            format = AskFormat();
                            Update(id, format);
                            break;

                        case "5":
                            Console.WriteLine("Podaj ID produktu: ");
                            id = Console.ReadLine();
                            format = AskFormat();
                            Delete(id, format);
                            break;

                        default:
                            break;

                    }
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
