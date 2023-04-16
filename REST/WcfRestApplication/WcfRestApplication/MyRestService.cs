using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestApplication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyRestService : IRestService
    {
        private static List<Product> products;

        public MyRestService()
        {
            products = new List<Product>()
            {
                new Product {ID = 1, name = "Masło", weight = 1.59, price = 10.50},
                new Product {ID = 2, name = "Mleko", weight = 1.01, price = 3.99},
                new Product {ID = 3, name = "Chleb", weight = 0.59, price = 5.00},
                new Product {ID = 4, name = "Woda mineralna", weight = 6.34, price = 10.49},
                new Product {ID = 5, name = "Cukier", weight = 1.01, price = 4.51},
            };
        }

        public List<Product> getAllXml()
        {
            return products;
        }

        public List<Product> getAllJson()
        {
            return getAllXml();
        }

        public Product getByIdXml(string id)
        {
            int intId = int.Parse(id);
            int idx = products.FindIndex(product => product.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            return products.ElementAt(idx);
        }

        public Product getByIdJson(string id)
        {
            return getByIdXml(id);
        }

        public string addXml(Product item)
        {
            if (item == null || item.name == "" || item.weight < 0 || item.price < 0)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int newIdx = products.Last().ID + 1;
            int idx = products.FindIndex(product => product.ID == newIdx);
            if (idx == -1)
            {
                item.ID = newIdx;
                products.Add(item);
                return "Added product with ID = " + item.ID;
            }
            else
                throw new WebFaultException<string>("409: Conflict", System.Net.HttpStatusCode.Conflict);
        }

        public string addJson(Product item)
        {
            return addXml(item);
        }

        public string updateXml(Product item)
        {
            if (item == null || item.ID == 0 || item.name == "" || item.weight < 0 || item.price < 0)
                throw new WebFaultException<string>("400: Bad Request", System.Net.HttpStatusCode.BadRequest);
            int idx = products.FindIndex(product => product.ID == item.ID);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            else
            {
                Product productToUpdate = products.ElementAt(idx);
                productToUpdate.name = item.name;
                productToUpdate.weight = item.weight;
                productToUpdate.price = item.price;
                return "Updated product with ID = " + item.ID;
            }

        }

        public string updateJson(Product item)
        {
            return updateXml(item);
        }

        public string deleteXml(string id)
        {
            int intId = int.Parse(id);
            int idx = products.FindIndex(product => product.ID == intId);
            if (idx == -1)
                throw new WebFaultException<string>("404: Not Found", System.Net.HttpStatusCode.NotFound);
            products.RemoveAt(idx);
            return "Removed product with ID = " + id;
        }

        public string deleteJson(string id)
        {
            return deleteXml(id);
        }
    }
}
