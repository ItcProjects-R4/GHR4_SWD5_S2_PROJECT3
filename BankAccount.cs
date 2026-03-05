using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mimiproject
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string OwnerName { get; set; }

        public decimal Balance { get; protected set; }

        public BankAccount(int accountNumber, string ownerName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;

            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.");
            }

            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }

            Balance += amount;
            Console.WriteLine($"[Deposit] ${amount} added. New Balance: ${Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds! Withdrawal amount exceeds balance.");
            }

            Balance -= amount;
            Console.WriteLine($"[Withdraw] ${amount} withdrawn. New Balance: ${Balance}");
        }

        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber} | Owner: {OwnerName} | Balance: ${Balance}");
        }
    }
}
