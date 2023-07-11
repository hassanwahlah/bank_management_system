using System;

public class BankAccount //base class
{
    public string Account_number;         //base class attributes
    public string Account_holder_name;
    public int Balance;

    public BankAccount(string account_number, string account_holder_name, int balance) // base class constructor
    {
        Account_number = account_number;
        Account_holder_name = account_holder_name;
        Balance = balance;
    }

    public virtual void Deposit(int deposit)   // base class deposit method
    {
        Balance = Balance + deposit;
        Console.WriteLine("Your account '" + Account_number + "' has been sucessfully deposited in your current account by Pkr " + deposit + ".");
    }

    public virtual void Withdraw(int withdraw)   // base class virtual method
    {
        Balance = Balance - withdraw;
        Console.WriteLine("Your account '" + Account_number + "' has been withdrawal by Pkr " + withdraw + ".");
    }

    public void DisplayAccountInfo()   // base class display output
    {
        Console.WriteLine("Account Information \nAccount Number: " + Account_number + "\nName: " + Account_holder_name +"\nBalance: " + Balance);
    }
}

public class SavingsAccount : BankAccount  // SavingAccount(child) inherited from BankAccount(base)
{
    public int interestRate;   // attribute


    // constructor
    public SavingsAccount(string account_number, string account_holder_name, int balance) : base(account_number, account_holder_name, balance)
    {
    }

    public override void Deposit(int deposit)   // child class overriden method
    {
        deposit = deposit + (10*deposit)/100;
        Balance = Balance + deposit;
        Console.WriteLine("Your account '" + Account_number + "' has been sucessfully deposited in your saving account including 10% interestRate total deposited amount is " + deposit + ".");;
    }
}

public class CheckingAccount : BankAccount  // CheckingAccount(child) class inherited by BanlAccount(base)
{
    public CheckingAccount(string account_number, string account_holder_name, int balance) : base(account_number, account_holder_name, balance)
    {
    }

    public override void Withdraw(int withdraw)  // overridden method
    {
        if(withdraw > Balance)
        {
            Console.WriteLine("Sorry the withdrawal amount exceeds the account balance.");
        }else
        {
            base.Withdraw(withdraw);
        }
    }
}

public class Bank  // bank class
{
    public List<BankAccount> B_Account;    // list
    
    public Bank()
    {
        B_Account = new List<BankAccount>();  // initializing list
    }

    public void AddAccount(BankAccount Account)  // method for adding account to list
    {
        B_Account.Add(Account);
    }

    public void DepositToAccount(string account_number, int deposit)  // method to deposit
    {
        foreach(var i in B_Account)
        {
            if(i.Account_number == account_number)
            {
                i.Deposit(deposit);
                break;
            }
        }
    }

    public void WithdrawFromAccount(string account_number, int withdraw)  // method to withdraw
    {
        foreach(var i in B_Account)
        {
            if(i.Account_number == account_number)
            {
                i.Withdraw(withdraw);
                break;
            }
        }
    }
}

namespace HelloWorld
{
  class Program
  {
    static void Main(string[] args)
    {
    Bank bank = new Bank(); // instance of Bank class
    SavingsAccount acc_1 = new SavingsAccount("02640000001", "Hassan", 50000);  // instance of SavingAccount class
    CheckingAccount acc_2 = new CheckingAccount("02640000002", "Ahmad", 27000);  // instance of CheckingAccount class
    bank.AddAccount(acc_1);  // adding account to bank
    bank.AddAccount(acc_2);  // adding account to bank
    
    
    bank.DepositToAccount("02640000001", 25000);      // deposit to account
    bank.WithdrawFromAccount("02640000001", 10000);  // withdraw from account
    Console.WriteLine();                           // next line
    acc_1.DisplayAccountInfo();                     // calling method to display account information
    Console.WriteLine();                           // next line

    bank.DepositToAccount("02640000002", 53000);       // deposit to account
    bank.WithdrawFromAccount("02640000002", 17000);   // withdraw from account
    Console.WriteLine();                           // next line
    acc_2.DisplayAccountInfo();                      // calling method to display account information
    }
  }
}