using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.TableHandler
{
    public class Employee
    {
        public uint Em_ID {  get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
    }
}
