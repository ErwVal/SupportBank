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

        public static List<Transaction> GetTransactions(string fileName) => File.ReadAllLines(fileName)
                                                                                    .Skip(1)
                                                                                    .Select(row => row.Split(","))
                                                                                    .Select(row => new Transaction(Convert.ToDateTime(row[0]), row[1], row[2], row[3], Convert.ToDecimal(row[4])))
                                                                                    .ToList(); // We could have an Enumerable by deleting this line

        public static List<Account> GetAccounts(List<Transaction> transactions)
        {
            Dictionary<string, Account> nameToAccount = new Dictionary<string, Account>();

            foreach ((string fromUser, string toUser, decimal amount) in transactions)
            {
                // Check if account exists:
                 if (!nameToAccount.ContainsKey(fromUser)) 
                 {
                     nameToAccount.Add(fromUser, new Account(fromUser));
                 }

                 if (!nameToAccount.ContainsKey(toUser)) 
                 {
                     nameToAccount.Add(toUser, new Account(toUser));
                 }

                // Update balance
                nameToAccount[fromUser].Balance += amount;
                nameToAccount[toUser].Balance -= amount;
            }

            return nameToAccount.Values.ToList();
        }

        static void Main(string[] args)
        {
            List<Transaction> transactions = Program.GetTransactions("./Transactions2014.csv");
            List<Account> accounts = Program.GetAccounts(transactions);
            
        }
    }
}
