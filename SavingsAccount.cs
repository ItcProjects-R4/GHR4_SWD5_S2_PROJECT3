using System;

namespace mimiproject
	{
		public class SavingsAccount : BankAccount
		{
			private decimal interestRate;  
			private decimal minimumBalance; 

			public decimal InterestRate
			{
				get { return interestRate; }
				set
				{
					if (value < 0 || value > 100)
						throw new ArgumentException("Interest rate must be between 0% and 100%");
					interestRate = value;
				}
			}

			public decimal MinimumBalance
			{
				get { return minimumBalance; }
				set
				{
					if (value < 0)
						throw new ArgumentException("Minimum balance cannot be negative");
					minimumBalance = value;
				}
			}

			public SavingsAccount(int accountNumber, string ownerName, decimal initialBalance, decimal interestRate, decimal minimumBalance = 100)
				: base(accountNumber, ownerName, initialBalance)
			{
				InterestRate = interestRate;
				this.inimumBalance = minimumBalance;
			}

			public override void Withdraw(decimal amount)
			{
				if (amount <= 0)
					throw new ArgumentException("Withdrawal amount must be greater than zero.");

				if (Balance - amount < minimumBalance)
					throw new InvalidOperationException($"Cannot withdraw ${amount}. Minimum balance of ${minimumBalance} must be maintained. Current balance: ${Balance}");

				base.Withdraw(amount);
			}

			public void AddInterest()
			{
				decimal interestAmount = Balance * (interestRate / 100); 
				Balance += interestAmount;
				Console.WriteLine($"[Interest Added] ${interestAmount:F2} added. New Balance: ${Balance}");
			}

			public override void DisplayAccountInfo()
			{
				Console.WriteLine("[Savings Account]");
				Console.WriteLine($"Account Number: {AccountNumber}");
				Console.WriteLine($"Owner: {OwnerName}");
				Console.WriteLine($"Balance: ${Balance:F2}");
				Console.WriteLine($"Interest Rate: {interestRate}%");
				Console.WriteLine($"Minimum Balance: ${minimumBalance}");
			}
		}
	}
}