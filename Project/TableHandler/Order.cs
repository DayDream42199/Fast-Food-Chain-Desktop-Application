using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class Order
    {
        public ulong Order_ID { get; set; }
        public string Order_Name { get; set; }
        public uint Quantity { get; set; }
        public uint Menu_ID { get; set; }

    }
}
