using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using Newtonsoft.Json;
using Common;
using DataAccess.DTO;
using DataAccess.Factory;
using DataAccess.DAOImpl;
using Paygate.Utility;
using RabbitMQ.Client;


namespace APIRequestExport.Controllers
{
    public class MessageController : ApiController
    {
        const string exchange = "authentictions";

        [HttpGet]
        public string SendMsgRequest(string searchRequest, string signature)
        {
            string result = string.Empty;
            var objResponse = new Common.Response();

            if (string.IsNullOrEmpty(searchRequest) || string.IsNullOrEmpty(signature))
            {
                objResponse.Status = -1;
                return JsonConvert.SerializeObject(objResponse);
            }

            // Luu vao DB
            var searchInfo = JsonConvert.DeserializeObject<SearchRequest>(searchRequest);


            var requestInfo = new ReportExcel()
            {
                CreateTime = DateTime.Now,
                Param = searchInfo.Params,
                SPName = searchInfo.SPName,
                Status = 0,
                UserName = searchInfo.UserName
            };

            int requestID = AbstractDAOFactory.Instance().CreateExportSearchDAO().AddRequestExport(requestInfo);
            if (requestID <= 0) // Loi
            {
                objResponse.Status = -1;
                return JsonConvert.SerializeObject(objResponse);
            }

            searchInfo.RequestID = requestID; // Lay requestID de lam pass nen file
            // Da luu log db ok

            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };

                //The connection abstracts the socket connection, and takes care of protocol version negotiation and authentication and so on for us.
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        //1. declare and exchange were messages will be sent to
                        channel.ExchangeDeclare(exchange, "fanout");

                        //2. create a message, that can be anything since it is a byte array
                        string message = searchRequest;
                        bool sendSuccess = SendMessage(channel, message);

                        short statusSend = 2; // Gui bi loi
                        if (sendSuccess)
                        {
                            statusSend = 1; // Gui ok
                            objResponse.Status = 1; // Thanh cong
                            objResponse.Data = requestID.ToString();
                        }

                        int resultUpdate = AbstractDAOFactory.Instance().CreateExportSearchDAO().UpdateRequestExport(requestID, statusSend, string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Info("Loi khi gui request. Info: " + searchRequest
                    + Environment.NewLine + ex);
            }

            return JsonConvert.SerializeObject(objResponse); ;
        }

        private static bool SendMessage(IModel channel, string message)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(message);

                //3. send the message
                channel.BasicPublish(exchange, string.Empty, null, body);
                return true;
            }
            catch (Exception ex)
            {
                NLogLogger.Info("Loi khi send message: " + message
                    + Environment.NewLine + ex);

                return false;
            }
        }



        /// <summary>
        /// Nhan request cu the tu Client (Test luc dau, khong dung nua)
        /// Gui xuong message queue
        /// </summary>
        /// <param name="requestData"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetRequest(string fileName, int numberRows, string signature)
        {
            string result = string.Empty;

            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };

                //The connection abstracts the socket connection, and takes care of protocol version negotiation and authentication and so on for us.
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        //1. declare and exchange were messages will be sent to
                        channel.ExchangeDeclare(exchange, "fanout");

                        //2. create a message, that can be anything since it is a byte array
                        string message = string.Format("{0}|{1}", fileName, numberRows);
                        SendMessage(channel, message);
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Info("Xay ra loi khi gui request: " + ex.ToString());
            }
            return result;
        }


    }
}
