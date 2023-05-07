using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDSample
{
    public class AccountManagement
    {
        public int Deposite(Account account,int amount)
        {
            account.BankAccountBalance = account.BankAccountBalance - amount;

            return account.BankAccountBalance;
        }
    }
}
