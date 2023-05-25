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
            string connection;
            string channel;

            //input the name
            Console.WriteLine("Please enter your first name");
            firstName = Console.ReadLine();

            connection = new ConnectionFactory()
            {

            }


        }
    }
}
