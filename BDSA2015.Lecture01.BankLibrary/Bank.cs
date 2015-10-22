using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture01.BankLibrary
{
    public class Bank
    {
        public int Balance { get; private set; }

        public Bank()
        {
        }

        public Bank(int balance)
        {
            Balance = balance;
        }

        public void Deposit(int value)
        {
            checked
            {
                Balance += value;
            }
        }
    }
}
