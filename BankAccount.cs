using System;

namespace Classes;

public class BankAccount{
    private static int accountNumberSeed =1234567890;
    public string Number {get;}
    public string Owner {get;set;}
    public decimal Balance{
        get{
            decimal balance =0;
            foreach(var item in allTranscations){
                balance +=item.Amount;
            }
            return balance;
        }
    }

    //constructor ---->initialize//
    public BankAccount(string name,decimal initialBalance){
        this.Owner = name;

         MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

        this.Number =accountNumberSeed.ToString();
        accountNumberSeed++;
    }

    private List<Transcation> allTranscations = new List<Transcation>();

    public void MakeDeposit(decimal amount,DateTime date,string note){
        if(amount <=0){
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");
        }
        var deposit = new Transcation(amount,date,note);
        allTranscations.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount,DateTime date,string note){
        if(amount <=0){
            throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrawal must be positivie");
        }
        if(Balance - amount <0){
            throw new InvalidOperationException("No sufficient funds for this withdrawal!");
        }
        var withdrawal = new Transcation(-amount,date,note);
        allTranscations.Add(withdrawal);
    }

    public string GetAccountHistrory(){
        var report = new System.Text.StringBuilder();

        decimal balance =0;

        report.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach(var item in allTranscations){
            balance +=item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return report.ToString();
    }
}