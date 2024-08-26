using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    public class BusinessLoan : Loan
    {
        public BusinessLoan(int loanNumber, string customerLastname, string customerFirstname, double loanAmount, int term, double primeInterestRate) : base(loanNumber, customerLastname, customerFirstname, loanAmount, term)
        {
            InterestRate = primeInterestRate + 1.0;
        }

        public override double CalculateTotalAmountOwed()
        {
            return LoanAmount * (1 + (InterestRate / 100) * Term);
        }
    }
}
