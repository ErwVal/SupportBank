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
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Narrative { get; set; }
        public decimal Amount { get; set; }

        public Transaction(DateTime date, int fromUserId, int toUserId, string narrative, decimal amount)
        => (Id, Date, FromUserId, ToUserId, Narrative, Amount) = (++counter, date, fromUserId, toUserId, narrative, amount);
    }
}