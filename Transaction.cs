using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace SupportBank
{
    class Transaction
    {
        // Counter to create individual ids for each transaction.
        private static int counter = 0;

        // Features
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Narrative { get; set; } 
        public decimal Amount { get; set; }

        public Transaction(DateTime date, string fromUser, string toUser, string narrative, decimal amount)
        => (Id, Date, FromUser, ToUser, Narrative, Amount) = (++counter, date, fromUser, toUser, narrative, amount);

        public override string ToString()
        {
            return "On the " + Date.ToString("dd MMMM, yyyy") + ", " + FromUser + " lent " + ToUser + " £" + Amount + " for " + Narrative + ".";
        }

        public void Deconstruct(out string fromUser, out string toUser, out decimal amount) 
        {
            fromUser = FromUser;
            toUser = FromUser;
            amount = Amount;
        }
    }
}