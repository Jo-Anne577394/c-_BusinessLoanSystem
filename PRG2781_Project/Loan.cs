using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    public abstract class Loan : ILoanConstants
    {
        private string customerLastname, customerFirstname;
        private double loanAmount, interestRate;
        private int loanNumber, term;

        public int LoanNumber { get => loanNumber; set => loanNumber = value; }
        public string CustomerLastname { get => customerLastname; set => customerLastname = value; }
        public string CustomerFirstname { get => customerFirstname; set => customerFirstname = value; }
        public double LoanAmount { get => loanAmount; set => loanAmount = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public int Term { get => term; set => term = value; }

        public int ShortTerm => 1;
        public int MediumTerm => 3;
        public int LongTerm => 5;
        public string CompanyName => "Unique Building Services Loan Company ";
        public double MaxLoanAmount => 100000;

        public Loan(int loanNumber, string customerLastname, string customerFirstname, double loanAmount, int term)
        {
            LoanNumber = loanNumber;
            CustomerLastname = customerLastname;
            CustomerFirstname = customerFirstname;

            if (loanAmount > MaxLoanAmount)
                throw new ArgumentException("Loan amount cannot exceed the maximum limit.");

            LoanAmount = loanAmount;

            if (term == ShortTerm || term == MediumTerm || term == LongTerm)
            {
                Term = term;
            }
            else { Term = ShortTerm; }
        }

        public override string ToString()
        {
            return $"Loan Number: {LoanNumber}\n" +
               $"Customer: {CustomerLastname} {CustomerFirstname}\n" +
               $"Loan Amount: R{LoanAmount}\n" +
               $"Interest Rate: {InterestRate}%\n" +
               $"Term: {Term} years";
        }

        public abstract double CalculateTotalAmountOwed();        
    }
}
