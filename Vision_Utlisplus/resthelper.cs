using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Vision_Utlis
{
    class resthelper
    {
        //private CallBackRequest call = null;



        /// <summary>
        /// 用post方式请求json格式的资源，获取应答
        /// </summary>
        /// <param name="req">请求数据</param>
        /// <param name="URI">ip+端口+请求约定+接口名</param>
        /// <returns></returns>
        /// 
        public String restResource_post(String req, String URI)
        {
            //TODO　获取参数，调用提求， 如果是用MQ， 可从MQ的消息中获取

            // Create the web request
            try
            {
                string postData = req; // json.Serialize(paramTask);

                byte[] dataArray = Encoding.Default.GetBytes(postData);
                HttpWebRequest request = WebRequest.Create(URI) as HttpWebRequest;
                request.Method = "post";
                // request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json";
                request.ContentLength = dataArray.Length;
                request.ProtocolVersion = HttpVersion.Version10;
                Stream dataStream = null;
                try
                {
                    dataStream = request.GetRequestStream();
                }
                catch (Exception e)
                {
                    //form.getResponseText().Text = e.Message;
                    return null;//连接服务器失败
                }

                //发送请求
                dataStream.Write(dataArray, 0, dataArray.Length);
                dataStream.Close();
                // Get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    // Console application output
                    String s = reader.ReadToEnd();
                    String result = HttpUtility.UrlDecode(s);
                    //form.getResponseText().Text = result;

                    Console.WriteLine(result);
                    //Console.ReadLine();
                    return result;
                }

            }
            catch (Exception e1)
            {
                //form.getResponseText().Text = e1.Message;
                return null;//连接服务器失败
            }

        }



        /// <summary>
        /// 用get方式请求json格式的资源，获取应答
        /// </summary>
        /// <param name="req">请求数据</param>
        /// <param name="URI">ip+端口+请求约定+接口名</param>
        /// <returns></returns>
        public String restResource_get(String req, String URI)
        {
            //TODO　获取参数，调用提求， 如果是用MQ， 可从MQ的消息中获取

            // Create the web request
            try
            {
                string postData = req; // json.Serialize(paramTask);

                byte[] dataArray = Encoding.Default.GetBytes(postData);
                HttpWebRequest request = WebRequest.Create(URI) as HttpWebRequest;
                request.Method = "get";
                // request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json";
                request.ContentLength = dataArray.Length;
                request.ProtocolVersion = HttpVersion.Version10;
                Stream dataStream = null;
                try
                {
                    dataStream = request.GetRequestStream();
                }
                catch (Exception e)
                {
                    //form.getResponseText().Text = e.Message;
                    return null;//连接服务器失败
                }

                //发送请求
                dataStream.Write(dataArray, 0, dataArray.Length);
                dataStream.Close();
                // Get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    // Console application output
                    String s = reader.ReadToEnd();
                    String result = HttpUtility.UrlDecode(s);
                    //form.getResponseText().Text = result;

                    Console.WriteLine(result);
                    //Console.ReadLine();
                    return result;
                }

            }
            catch (Exception e1)
            {
                //form.getResponseText().Text = e1.Message;
                return null;//连接服务器失败
            }

        }


        /// <summary>
        /// rest做服务端接收客户端的请求
        /// </summary>
        /// <param name="URI">ip+端口+请求约定+接口名</param>
        /// <param name="call">需要接收客户端数据的相应参数</param>
        /// <returns></returns>
        private void pubRestful(string URL , CallBackRequest call)
        {
            //CallBackRequest callBackRequest = new CallBackRequest();
            //callBackRequest.CooX = "6923263";

            MesRestService demoService = new MesRestService(call);
            Uri baseAddress = new Uri(URL);
            WebServiceHost _serviceHost = new WebServiceHost(demoService, baseAddress);
            //如果不设置MaxBufferSize,当传输的数据特别大的时候，很容易出现“提示: 413 Request Entity Too Large”错误信息,最大设置为20M
            WebHttpBinding binding = new WebHttpBinding
            {
                TransferMode = TransferMode.Buffered,
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
                MaxBufferPoolSize = 2147483647,
                ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max,
                Security = { Mode = WebHttpSecurityMode.None }
            };
            _serviceHost.AddServiceEndpoint(typeof(IMesRestService), binding, baseAddress);

            _serviceHost.Opened += delegate
            {
                //textBox1.AppendText("Web服务已开启...");
            };

            _serviceHost.Open();

            //textBox1.Text = "Web服务已开启...";
            //_serviceHost.Close();
        }

    }
}
