using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class CardItem
    {
        public ulong order_id { get; set; }
        public ulong card_id { get; set; }
        public required string item_name { get; set; }
        public uint quantity { get; set; }
        public required string status { get; set; }
    }
}
