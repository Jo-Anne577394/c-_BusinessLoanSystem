using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2781_Project
{
    public interface ILoanConstants
    {
        int ShortTerm { get; }
        int MediumTerm { get; }
        int LongTerm { get; }
        string CompanyName { get; }
        double MaxLoanAmount { get; }
    }
}
