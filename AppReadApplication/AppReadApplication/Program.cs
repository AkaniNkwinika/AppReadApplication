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

            //Promp the user to enter their firstname
            Console.WriteLine("Please enter your first name");
            firstName = Console.ReadLine();

            //Configure the connection to RabbitMQ
            var configConnection = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 15672
            };

            //Establish the connection
            using (var connection = configConnection.CreateConnection())
                using (var virtualConnection = connection.CreateModel())
            {
                virtualConnection.QueueDeclare(queue: "",
                                            durable: true,
                                            autoDelete: false,
                                            arguments: null,
                                            exclusive: false);

                //Create message to the queue
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
