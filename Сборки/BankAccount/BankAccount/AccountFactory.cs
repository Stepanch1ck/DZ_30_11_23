using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
    public class AccountFactory
    {
        private static readonly Dictionary<int, Account> _accounts = new Dictionary<int, Account>();
        public AccountFactory()
        {
        }

        public Account CreateAccount(int accountNumber, decimal balance, AccountType type)
        {
            Account account = new Account(accountNumber, balance, type);
            _accounts.Add(accountNumber, account);
            return account;
        }

        public Account CreateAccount(decimal balance, AccountType type)
        {
            return CreateAccount(UniqueBankAccount(), balance, type);
        }
        public Account CreateAccount( AccountType type)
        {
            return CreateAccount(UniqueBankAccount(), 0, type);
        }
        public static int UniqueBankAccount()
        {
            int ID = 1;
            while (_accounts.ContainsKey(ID))
            {

                ID++;
            }
            return ID;
        }

        public void CloseAccount(int accountNumber)
        {
            if (_accounts.ContainsKey(accountNumber))
            {
                _accounts.Remove(accountNumber);
            }
        }
        public static bool IsBankAccountClosed(int accountNumber) 
        {
            return !_accounts.ContainsKey(accountNumber);
        }
    }
}
