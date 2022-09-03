using System;
using Classes;

namespace MySuperBank
{
  class Program
  {
    static void Main(string[] args) {
    
      var account =new BankAccount("Alex",1000);
      Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
     }
  }
}
