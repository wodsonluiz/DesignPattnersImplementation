using System;

namespace State
{
    /// <summary>
    /// State
    /// </summary>
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;
        public decimal Balance { get; protected set; }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }

    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount} ");
            Balance += amount;

            if(Balance >= 1000)
            {
                BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance} ");
            Balance -= amount;

            if(Balance < 0)
            {
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    public class OverdrawnState : BankAccountState
    {
        public OverdrawnState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }
        
        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount} ");
            Balance += amount;

            if(Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, cannot withdraw, balance {Balance}");
        }
    }

    public class GoldState : BankAccountState
    {
        public GoldState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount} + 10% bounus: {amount/10} ");
            Balance += amount + (amount/10);
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from balance {Balance} ");

            Balance -= amount;

            if(Balance < 1000 && Balance >= 0)
            {
                BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
            }

            if(Balance < 0)
            {
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }
    }

    /// <summary>
    /// Context
    /// </summary>
    public class BankAccount
    {
        public BankAccountState BankAccountState { get; set; }
        public decimal Balance { get { return BankAccountState.Balance; } }

        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }

        public void Deposit(decimal amount)
        {
            BankAccountState.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            BankAccountState.Withdraw(amount);
        }
    }
    
}