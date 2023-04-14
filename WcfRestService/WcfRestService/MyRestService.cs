using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfRestService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyRestService : IRestService
    {
        private static List<Book> books;

        public MyRestService()
        {
            books = new List<Book>()
            {
                new Book {ID = 1, title = "Pan Tadeusz", author = "Adam Mickiewicz", pages = 334, price = 29.50},
                new Book {ID = 2, title = "Lalka", author = "Bolesław Prus", pages = 860, price = 36.99},
                new Book {ID = 3, title = "Wesele", author = "Stanisław Wyspiański", pages = 210, price = 21.37},
                new Book {ID = 4, title = "Ferdydurke", author = "Witold Gombrowicz", pages = 295, price = 29.00},
                new Book {ID = 5, title = "Rok 1984", author = "George Orwell", pages = 236, price = 28.84},
            };
        }

        public List<Book> getAllXml()
        {
            return books;
        }

        public List<Book> getAllJson()
        {
            return getAllXml();
        }

        public Book getByIdXml(string id)
        {
            int intId = int.Parse(id);
            int idx = books.FindIndex(book => book.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            return books.ElementAt(idx);
        }

        public Book getByIdJson(string id)
        {
            return getByIdXml(id);
        }

        public string addXml(Book item)
        {
            if (item == null)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = books.Last().ID + 1;
            int idx = books.FindIndex(book => book.ID == newIdx);
            if (idx == -1)
            {
                item.ID = newIdx;
                books.Add(item);
                return "Added book with ID = " + item.ID;
            }
            else
                throw new WebFaultException<string>("409: Conflict", System.Net.HttpStatusCode.Conflict);
        }

        public string addJson(Book item)
        {
            return addXml(item);
        }

        public string deleteXml(string id)
        {
            int intId = int.Parse(id);
            int idx = books.FindIndex(book => book.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            books.RemoveAt(idx);
            return "Removed book with ID = " + id;
        }

        public string deleteJson(string id)
        {
            return deleteXml(id);
        }
    }
}
