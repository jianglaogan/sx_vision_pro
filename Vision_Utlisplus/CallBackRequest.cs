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
    public class CallBackRequest
    {
        [DataMember(Order = 0)]
        private string reqCode { get; set; }
        [DataMember(Order = 1)]
        private string reqTime { get; set; }
        [DataMember(Order = 2)]
        private string interfaceName { get; set; }
        [DataMember(Order = 3)]
        private string cooX { get; set; }
        [DataMember]
        private string cooY { get; set; }
        [DataMember]
        private string currentPositionCode { get; set; }
        [DataMember]
        private object data { get; set; }
        [DataMember]
        private string mapCode { get; set; }
        [DataMember]
        private string mapDataCode { get; set; }
        [DataMember]
        private string method { get; set; }
        [DataMember]
        private string podCode { get; set; }
        [DataMember]
        private string podDir { get; set; }
        [DataMember]
        private string robotCode { get; set; }
        [DataMember]
        private string taskCode { get; set; }
        [DataMember]
        private string wbCode { get; set; }

        //////////

        public string ReqCode
        {
            set { reqCode = value; }
            get { return reqCode; }
        }

        public object Data
        {
            set { data = value; }
            get { return data; }
        }

        public string ReqTime
        {
            set { reqTime = value; }
            get { return reqTime; }
        }

        //public string InterfaceName
        //{
        //    set { interfaceName = value; }
        //    get { return interfaceName; }
        //}

        public string CooX
        {
            set { cooX = value; }
            get { return cooX; }
        }

        public string CooY
        {
            set { cooY = value; }
            get { return cooY; }
        }

        public string CurrentPositionCode
        {
            set { currentPositionCode = value; }
            get { return currentPositionCode; }
        }

        public string MapCode
        {
            set { mapCode = value; }
            get { return mapCode; }
        }

        public string MapDataCode
        {
            set { mapDataCode = value; }
            get { return mapDataCode; }
        }

        public string Method
        {
            set { method = value; }
            get { return method; }
        }

        public string PodCode
        {
            set { podCode = value; }
            get { return podCode; }
        }

        public string PodDir
        {
            set { podDir = value; }
            get { return podDir; }
        }

        public string RobotCode
        {
            set { robotCode = value; }
            get { return robotCode; }
        }

        public string TaskCode
        {
            set { taskCode = value; }
            get { return taskCode; }
        }

        public string WbCode
        {
            set { wbCode = value; }
            get { return wbCode; }
        }

    }
}
