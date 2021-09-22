using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportBank
{
    class SupportBank
    {

        public List<Transaction> Transactions { get; set; }
        public List<Account> Accounts { get; set; }

        public SupportBank()
        {
            Transactions = SupportBank.GetTransactions("./Transactions2014.csv");
            Accounts = GetAccounts();
        }

        public static List<Transaction> GetTransactions(string fileName) => File.ReadAllLines(fileName)
                                                                                    .Skip(1)
                                                                                    .Select(row => row.Split(","))
                                                                                    .Select(row => new Transaction(Convert.ToDateTime(row[0]), row[1], row[2], row[3], Convert.ToDecimal(row[4])))
                                                                                    .ToList(); // We could have an Enumerable by deleting this line

        public List<Account> GetAccounts()
        {
            Dictionary<string, Account> nameToAccount = new Dictionary<string, Account>();

            foreach ((string fromUser, string toUser, decimal amount) in Transactions)
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
                nameToAccount[fromUser].Balance = nameToAccount[fromUser].Balance + amount;
                nameToAccount[toUser].Balance = nameToAccount[toUser].Balance + amount;
            }

            return nameToAccount.Values.ToList();
        }

        void ListAllAccounts()
        {
            Accounts.ForEach(Console.WriteLine);
        }

        void ListAccountTransactions(string name)
        {
            List<Transaction> filteredTransactions = Transactions.Where(transaction => transaction.FromUser.Equals(name) || transaction.ToUser.Equals(name)).ToList();
            filteredTransactions.ForEach(Console.WriteLine);
        }

        static void Main(string[] args)
        {
            SupportBank bank = new SupportBank(); // Now just using the args passed in
            bank.ListAccountTransactions("Todd");
        }
    }
}

// Gonna push to git :)