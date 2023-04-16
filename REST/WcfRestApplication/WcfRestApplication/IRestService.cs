using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestApplication
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/products")]
        List<Product> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/products",
            ResponseFormat = WebMessageFormat.Json)]
        List<Product> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/products/{id}",
            ResponseFormat = WebMessageFormat.Xml)]
        Product getByIdXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/products/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        Product getByIdJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/products",
            Method = "POST",
            RequestFormat = WebMessageFormat.Xml)]
        string addXml(Product item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/products",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string addJson(Product item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/products",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Xml)]
        string updateXml(Product item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/products",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json)]
        string updateJson(Product item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/products/{id}", Method = "DELETE")]
        string deleteXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/products/{id}",
            Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json)]
        string deleteJson(string id);
    }


    [DataContract]
    public class Product
    {
        [DataMember(Order = 0)]
        public int ID { get; set; }

        [DataMember(Order = 1)]
        public string name { get; set; }

        [DataMember(Order = 2)]
        public double weight { get; set; }

        [DataMember(Order = 3)]
        public double price { get; set; }
    }
}
