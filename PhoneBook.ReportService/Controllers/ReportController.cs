using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace PhoneBook.ReportService.Controllers
{

    [EnableCors("WebSiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private string QueueName = "risement-phonebook-reportreq";
        private ConnectionFactory factory = new ConnectionFactory();

        public ReportController()
        {
            factory = new ConnectionFactory();
            factory.HostName = "amqps://cdrxtokv:MKa99Z0ZrIAFuLNpm8-SynAS2rmfLwfJ@goose.rmq2.cloudamqp.com/cdrxtokv";
        }

        [HttpGet]
        [Route("locstats")]
        public bool PersonLocationQueue()
        {
            // Queue'ya iletilecek Rapor tanımlama bilgileri
            Model.QueueRequest qReq = new Model.QueueRequest();
            qReq.ReportMethod = "locstats";
            return AddToQueue(qReq);
        }

        [HttpGet]
        [Route("persondetails/{uuid}")]
        public bool PersonDetailsQueue(Guid uuid)
        {
            // Queue'ya iletilecek Rapor tanımlama bilgileri
            Model.QueueRequest qReq = new Model.QueueRequest();
            qReq.ReportMethod = "persondetails";
            qReq.Parameters.Add("uuid", uuid.ToString("D"));
            return AddToQueue(qReq);
        }

        private bool AddToQueue(Model.QueueRequest qReq)
        {
            try
            {
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string bodyMessage = Newtonsoft.Json.JsonConvert.SerializeObject(qReq);
                byte[] bodyMsgBytes = Encoding.UTF8.GetBytes(bodyMessage);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: QueueName,
                                     basicProperties: null,
                                     body: bodyMsgBytes);
                return true;
            }
            catch (Exception)
            {
                // TODO: error message
                return false;
            }
        }

    }
}
