using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Account
    {
        private static int counter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Net { get; set; }

        public Account(string name, decimal net)
        {
            Id = ++counter;
            Name = name;
            Net = net;
        }
    }
}