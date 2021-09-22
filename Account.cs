using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Net { get; set; }

        public Account(int id, string name, decimal net)
        {
            Id = id;
            Name = name;
            Net = net;
        }
    }
}