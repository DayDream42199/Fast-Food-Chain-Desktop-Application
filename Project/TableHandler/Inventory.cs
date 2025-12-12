using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class Inventory
    {
        public ulong Inventory_ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } //categories
        public uint Quantity { get; set; }
        public string Batch_Number { get; set; }
        public DateTime Expiry_date { get; set; }
        public string Shelf_location { get; set; }
        public uint Menu_ID { get; set; }

    }
}
