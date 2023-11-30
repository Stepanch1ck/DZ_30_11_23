using System;
using System.Collections.Generic;

namespace BankAccount
{
    public enum AccountType
    {
        Debit,
        Credit
    }
    public class Account
    {
        internal int accountNumber;
        internal decimal Balance { get; set; }
        internal AccountType Type { get; set; }

        internal Account(int accountnumber, decimal balance, AccountType type)
        {
            this.accountNumber = accountnumber;
            this.Balance = balance;
            this.Type = type;
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Сумма снятия превышает баланс");
            }

            Balance -= amount;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Transfer(Account otherAccount, decimal amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("Сумма перевода превышает баланс");
            }

            Withdraw(amount);
            otherAccount.Deposit(amount);
        }
        public override string ToString()
        {
            return $"Номер счета: {accountNumber}, баланс: {Balance}, тип счета: {Type}";
        }
        private int number;
        private double balance;

        public Account(int number, double balance)
        {
            this.number = number;
            this.balance = balance;
        }

        public int GetNumber()
        {
            return number;
        }

        public double GetBalance()
        {
            return balance;
        }

        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                Account otherAccount = (Account)obj;
                return number == otherAccount.number && balance == otherAccount.balance;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Account account1, Account account2)
        {
            return account1.Equals(account2);
        }

        public static bool operator !=(Account account1, Account account2)
        {
            return !account1.Equals(account2);
        }

    }
}
