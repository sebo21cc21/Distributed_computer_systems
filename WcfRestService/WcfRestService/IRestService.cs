using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfRestService
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/books")]
        List<Book> getAllXml();

        [OperationContract]
        [WebGet(UriTemplate = "/json/books",
            ResponseFormat = WebMessageFormat.Json)]
        List<Book> getAllJson();

        [OperationContract]
        [WebGet(UriTemplate = "/books/{id}",
            ResponseFormat = WebMessageFormat.Xml)]
        Book getByIdXml(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/json/books/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        Book getByIdJson(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books",
            Method = "POST",
            RequestFormat = WebMessageFormat.Xml)]
        string addXml(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string addJson(Book item);

        [OperationContract]
        [WebInvoke(UriTemplate = "/books/{id}", Method = "DELETE")]
        string deleteXml(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/json/books/{id}", 
            Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json)]
        string deleteJson(string id);
    }


    [DataContract]
    public class Book
    {
        [DataMember(Order = 0)]
        public int ID { get; set; }

        [DataMember(Order = 1)]
        public string title { get; set; }

        [DataMember(Order = 2)]
        public string author { get; set; }

        [DataMember(Order = 3)]
        public int pages { get; set; }

        [DataMember(Order = 4)]
        public double price { get; set; }
    }
}
