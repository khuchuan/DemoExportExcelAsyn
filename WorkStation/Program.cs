using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkStation
{
    class Program
    {
        const string exchange = "authentictions";
        static void Main(string[] args)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        //1. declare and exchange were messages will be sent to
                        channel.ExchangeDeclare(exchange, "fanout");

                        //2. create a non-durable, exclusive, autodelete queue with a generated name
                        var result = channel.QueueDeclare();

                        //3. bind to the exclusive queue created above
                        channel.QueueBind(result.QueueName, exchange, string.Empty);

                        //4. now get message from queue
                        var consumer = new QueueingBasicConsumer(channel);
                        channel.BasicConsume(result.QueueName, true, consumer);

                        Console.WriteLine("[*] Waiting for messages." + "To exit press CTRL+C");

                        while (true)
                        {
                            var ea = consumer.Queue.Dequeue();
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            string fileName = message.Split('|')[0];
                            int numberRows = Convert.ToInt32(message.Split('|')[1]);

                            ExportExcel(fileName, numberRows);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        private static void ExportExcel(string fileName, int records)
        {
            List<Transaction> listData = new List<Transaction>();
            int maxRecode = records; // 500000;
            for (int i = 0; i < maxRecode; i++)
            {
                Transaction tranInfo = new Transaction
                {
                    CreateTime = DateTime.Now,
                    CustomerAddress = "23 Tay Son, Dong Da, Ha Noi",
                    CustomerPhone = "0981234567",
                    Description = "Đơn hàng thanh toán online",
                    CustomerName = "Nguyễn Văn A",
                    ID = i,
                    MerchantName = "Kids Plaza",
                    ProductName = "Xe đạp trẻ em",
                    ProducValue = 300000,
                    UpdateTime = DateTime.Now
                };
                listData.Add(tranInfo);
            }

            CreateExcelFile cls = new CreateExcelFile();
            string path = @"C:\Users\Huankc\Downloads\" + fileName + DateTime.Now.ToString("yyyyMMddHHmm") + ".xlsx";
            CreateExcelFile.CreateExcelDocument<Transaction>(listData, path);
        }        

    }
}
