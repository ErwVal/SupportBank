using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of Transaction objects from CSV.
            List<Transaction> transactions = File.ReadAllLines("./Transactions2014.csv")
                                           .Skip(1)
                                           .Select(row => row.Split(","))
                                           .Select(row => new Transaction(Convert.ToDateTime(row[0]), row[1], row[2], row[3], Convert.ToDecimal(row[4])))
                                           .ToList(); 
            
            // Make HashSet/List of Accounts
            // Iterate through transactions

            // If FromUser or ToUser do not have account, create one.
            // FromUser + amount to net
            // ToUser - amount from net
        }
    }
}
