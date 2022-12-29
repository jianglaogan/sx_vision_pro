using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;


namespace rest
{

    [DataContract(Namespace = "http://www.hikvision.com")]
    public class RemoteResult
    {
        [DataMember(Order = 0)]
        private string code { get; set; }
        [DataMember(Order = 1)]
        private string message { get; set; }
        [DataMember(Order = 2)]
        private string reqCode { get; set; }
        [DataMember(Order = 3)]
        private object data { get; set; }


        public RemoteResult(string code, string message, string reqCode)
        {
            this.code = code;
            this.message = message;
            this.reqCode = reqCode;
            this.data = "调用成功";
        }

        public string Code
        {
            set { code = value; }
            get { return code; }
        }
        public object Data
        {
            set { data = value; }
            get { return data; }
        }

        public string Message
        {
            set { message = value; }
            get { return message; }
        }

        public string ReqCode
        {
            set { reqCode = value; }
            get { return reqCode; }
        }


    }
}
