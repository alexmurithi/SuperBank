using System;

namespace Classes;

public class Transcation{
    public decimal Amount {get;}
    public DateTime Date {get;}
    public string Notes {get;}

    public Transcation(decimal amount, DateTime date, string note){
        Amount =amount;
        Date =date;
        Notes =note;
    }
}