using StackExchange.Redis;
using System;
using System.Threading;

namespace redis.pubsub.netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionMultiplexer.Connect("127.0.0.1:6379");
            var publisher = connection.GetSubscriber();

            int orderNum = 1;
            while (true)
            {
                publisher.Publish("order", "{order: " + orderNum + ", price: R$ 35,00}");
                Console.WriteLine("{order: " + orderNum + ", price: R$ 35,00}");
                orderNum++;
                Thread.Sleep(2000);
            }
        }
    }
}
