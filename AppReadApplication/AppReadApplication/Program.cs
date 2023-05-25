using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReadApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string message = "";
         

            //input the name
            Console.WriteLine("Please enter your first name");
            firstName = Console.ReadLine();

            var configConnection = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 15672
            };

            using (var connection = configConnection.CreateConnection())
                using (var virtualConnection = connection.CreateModel())
            {
                virtualConnection.QueueDeclare(queue: "",
                                            durable: true,
                                            autoDelete: false,
                                            arguments: null,
                                            exclusive: false);

                message = "Hello my name is " + firstName + "";
                var body = Encoding.UTF8.GetBytes(message);

                virtualConnection.BasicPublish(exchange: "",
                    routingKey: "",
                    basicProperties: null,
                    body: body);
                Console.WriteLine("You have successfully sent the message");
            }

        }
    }
}
