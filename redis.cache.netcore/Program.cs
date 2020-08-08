using ServiceStack.Redis;
using System;

namespace Redis.Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "localhost:6379";

            var client1 = new Client { Document = "298357285748975", Name = "Leonardo" };
            var client2 = new Client { Document = "347693863985683", Name = "Pontes" };

            var client3 = new Client { Document = "298357285748975", Name = "Leonardo" };
            var client4 = new Client { Document = "347693863985683", Name = "Pontes" };

            using (var redisClient = new RedisClient(host))
            {
                redisClient.Set<Client>(client1.key.ToString(), client1);
                redisClient.Set<Client>(client2.key.ToString(), client2);

                redisClient.Set<Client>(client1.key.ToString(), client1, new TimeSpan(0, 1, 0));
                redisClient.Set<Client>(client2.key.ToString(), client2, new TimeSpan(0, 1, 30));

                var clientX = redisClient.Get<Client>(client1.key.ToString());
            }

            Console.WriteLine("Hello World!");
        }
    }
}
