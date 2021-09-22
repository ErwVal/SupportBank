using System;

namespace SupportBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Account myAccount = new Account(1, "Alice M", 23.34m);
            Transaction transactionTest = new Transaction(DateTime.Today, 1, 2, "narrative", 55.50m);
            Console.WriteLine(transactionTest.Narrative);
            Console.WriteLine(myAccount.Name);
        }
    }
}
