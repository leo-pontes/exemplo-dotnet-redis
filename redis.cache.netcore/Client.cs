using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Cache
{
    public class Client
    {
        public Guid key { get; private set; }
        public string Name { get; set; }
        public string Document { get; set; }

        public Client()
        {
            key = Guid.NewGuid();
        }
    }
}
