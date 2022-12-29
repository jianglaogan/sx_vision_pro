using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;



namespace rest
{

    [ServiceContract(Name = "MesRestService")]
    public interface IMesRestService
    {
        //准备取待加工料接口
        [OperationContract]
        //[WebInvoke(UriTemplate = Routing.AgvCallback, Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat=WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

        [WebGet(UriTemplate = Routing.test_AgvCallback,/* Method = "POST",*/ RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

        string test_agvCallback(string name);

        [WebInvoke(UriTemplate = Routing.AgvCallback, Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]

        string agvCallback(CallBackRequest request);
    }


    public static class Routing
    {
        public const string AgvCallback = "/agvCallback";



        public const string test_AgvCallback = "/test_agvCallback/{name}";



    }



}
