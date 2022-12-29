using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
//using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using SQLPublicClass;
using System.Data.Common;

namespace rest
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MesRestService : IMesRestService
    {

        private CallBackRequest request { get; set; }


        public MesRestService(CallBackRequest request)
        {
            this.request = request;
        }

        //客户端返回通知
        public string agvCallback(CallBackRequest request)
        {

            string jsonStr_test = JsonConvert.SerializeObject(request);  //序列化：对象=>JSON字符串

            JObject json1 = (JObject)JsonConvert.DeserializeObject(jsonStr_test);

            //json解析示例

            //解析的参数值JValue
            //reqcode = (string)json1["reqCode"];


            #region//解析客户端通知
            //if (gentask_request_qingtocun.taskFlag == "1qingto_cun")
            //{
            //    if (taskCode == gentask_request_qingtocun.taskCode /*&& json_data_respond != data*/ && currentPositionCode == "1G3")
            //    {
            //        result = new RemoteResult("0", "成功", reqcode);
            //        form.setAgvstatus().Text = "小车走出清料位1qingto_cun";
            //        Log.addLog("小车走出清料位1qingto_cun");
            //    }
            //    else if (taskCode == gentask_request_qingtocun.taskCode && currentPositionCode == gentask_request_qingtocun.qingtocun_area /*&& method == "end"*/)
            //    {
            //        result = new RemoteResult("0", "成功", reqcode);
            //        form.setAgvstatus().Text = "小车走出存放区1qingto_cun," + gentask_request_qingtocun.qingtocun_area + "搬运完成";
            //        Log.addLog("小车走出存放区,搬运完成1qingto_cun");

            //        //从任务单号表中清理此任务
            //        string sql10 = "delete from " + taskcodeHistory + " where Flag = 'qingwan' ";
            //        dr = db1.ExecuteReader(db1.GetSqlStringCommond(sql10));

            //        gentask_request_qingtocun.taskFlag = "";//清空标志位
            //        gentask_request_qingtocun.task_end = "1";
            //    }
            //    else if (taskCode != gentask_request_qingtocun.taskCode)
            //    {
            //        result = new RemoteResult("1", "失败", reqcode);
            //        form.set_txtRCSreposend_state().Text = "任务单号不一致1qingto_cun";
            //        Log.addLog("任务单号不一致1qingto_cun");
            //    }
            //    else
            //    {
            //        result = new RemoteResult("1", "失败", reqcode);
            //        form.setAgvstatus().Text = "小车走出错误位置位置1qingto_cun!!!";
            //        form.set_txtRCSreposend_state().Text = "小车走出位置有误,请检查1qingto_cun!!!";
            //        Log.addLog("小车走出位置有误,请检查1qingto_cun!!!");
            //    }
            //}
            #endregion


            RemoteResult result = new RemoteResult("0", "成功", "我给的信息");

            //string jsonStr = serializer.Serialize(result);  //序列化：对象=>JSON字符串

            string jsonStr = JsonConvert.SerializeObject(result);  //序列化：对象=>JSON字符串
            return jsonStr;
        }




        //测试接口
        public string test_agvCallback(string name)//从这里解析调度发来的请求
        {

            //string txtReq = "{\r\n" +
            //      "	\"reqCode\": \"468513\",\r\n" +
            //      "	\"reqTime\": \"\",\r\n" +
            //      "	\"clientCode\": \"\",\r\n" +
            //      "	\"tokenCode\": \"\",\r\n" +
            //      "	\"interfaceName\": \"genAgvSchedulingTask\",\r\n" +
            //      "	\"taskTyp\": \"F01\",\r\n" +
            //      "	\"sceneTyp\": \"\",\r\n" +
            //      "	\"ctnrTyp\": \"\",\r\n" +
            //      "	\"ctnrCode\": \"\",\r\n" +
            //      "	\"wbCode\": \"\",\r\n" +
            //      "	\"positionCodePath\": [{\r\n" +
            //      "			\"positionCode\": \"p01\",\r\n" +
            //      "			\"type\": \"00\"\r\n" +
            //      "		},\r\n" +
            //      "		{\r\n" +
            //      "			\"positionCode\": \"x02\",\r\n" +
            //      "			\"type\": \"02\"\r\n" +
            //      "		}\r\n" +
            //      "	],\r\n" +
            //      "	\"podCode\": \"100001\",\r\n" +
            //      "	\"podDir\": \"0\",\r\n" +
            //      "	\"podTyp\": \"\",\r\n" +
            //      "	\"materialLot\": \"\",\r\n" +
            //      "	\"priority\": \"1\",\r\n" +
            //      "	\"agvCode\": \"\",\r\n" +
            //      "	\"taskCode\": \"\",\r\n" +
            //      "	\"data\": \"\"\r\n" +
            //      "}\r\n" +
            //      "";

            //string jsonStr = JsonConvert.SerializeObject(txtReq);  //序列化：对象=>JSON字符串
            return name;
        }



    }
}
