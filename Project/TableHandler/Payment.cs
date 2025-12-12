using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class Payment
    {
        public ulong Payment_ID {  get; set; }
        public ulong Order_ID { get; set; }
        public string Payment_Type { get; set; }
        public decimal Total {  get; set; }
        public DateTime Timestamp { get; set; }
    }
}
