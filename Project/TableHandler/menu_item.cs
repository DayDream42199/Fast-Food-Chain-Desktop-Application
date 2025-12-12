using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class Menu_item
    {
        public uint Menu_id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Path { get; set; }
        public uint Category_ID { get; set; }
    }
}
