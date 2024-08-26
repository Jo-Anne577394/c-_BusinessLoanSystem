using System;
using System.Text.RegularExpressions;

namespace PRG2781_Project
{
    public class CreateLoans
    {
        //Jo-Anne van der Wath(577394)
        //Henry Roux(577440)
        //Leonard Vermeer(577309)


        public CreateLoans()
        {
            PersonalLoan companyName = new PersonalLoan(1, "", "", 1, 1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(companyName.CompanyName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the current prime interest rate (%): ");
            bool primeContinue = true;
            double primeInterestRate = 0;
            while (primeContinue)
            {
                if (double.TryParse(Console.ReadLine(), out primeInterestRate))    //The prime interest rate may in certain circumstances be negative
                {
                    primeContinue = false;
                }
                else
                {
                    Console.SetCursorPosition(0, 2); //Cursor will be set at column 0 and row 2 (starting with index 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please make sure to only enter a number (e.g. 5) for the prime interest rate (%)");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int j = 0; j < Console.WindowWidth; j++)
                        Console.Write(" "); //Clear the incorrect input
                    Console.SetCursorPosition(0, 3);
                }
            }

            Loan[] loans = new Loan[5];

            for (int i = 0; i < loans.Length; i++)
            {
                Console.Clear();
                int consoleLineCount = 0;
                bool consoleErrorMessage = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(companyName.CompanyName);
                Console.ForegroundColor = ConsoleColor.White;
                consoleLineCount++;
                Console.WriteLine($"Loan {i + 1}:");
                consoleLineCount++;

                Console.WriteLine("Enter loan type:\n1. Business\n2. Personal ");
                consoleLineCount += 3;
                bool typeContinue = true;
                int loanType = 1;
                while (typeContinue)
                {
                    int.TryParse(Console.ReadLine(), out loanType);
                    if (loanType == 1 || loanType == 2)
                    {
                        typeContinue = false;
                        consoleLineCount++; //We only want to count the line once the program continues and we have valid data (for the readline)
                    }
                    else
                    {
                        consoleLineCount = ShowErrorMessage("Please choose between 1. Business or 2. Personal", consoleLineCount, consoleErrorMessage);
                        consoleErrorMessage = true;
                    }
                }

                if (consoleErrorMessage)
                { //Only once we've collected valid data we want to keep the error message and continue the program
                    consoleLineCount++;
                    consoleErrorMessage = false;
                }

                Console.Write("\nEnter loan number: ");
                consoleLineCount += 2;
                int loanNumber = 1;
                bool loanContinue = true;
                while (loanContinue)
                {
                    if (!int.TryParse(Console.ReadLine(), out loanNumber))
                    {
                        consoleLineCount = ShowErrorMessage("Please enter a valid loan number", consoleLineCount, consoleErrorMessage);
                        consoleErrorMessage = true;
                    }
                    else
                    {
                        loanContinue = false;
                        consoleLineCount++;
                    }
                }

                if (consoleErrorMessage)
                {
                    consoleLineCount++;
                    consoleErrorMessage = false;
                }

                string lastName = "";
                string firstName = "";

                Console.WriteLine("Enter customer's last name: ");
                consoleLineCount++;
                while (string.IsNullOrWhiteSpace(lastName) || !IsValidName(lastName))
                {
                    lastName = Console.ReadLine();
                    if (!IsValidName(lastName))
                    {
                        consoleLineCount = ShowErrorMessage("Please enter a valid last name with only letters, spaces, apostrophes, or hyphens.", consoleLineCount, consoleErrorMessage);
                        consoleErrorMessage = true;
                    }
                }
                consoleLineCount++;

                if (consoleErrorMessage)
                {
                    consoleLineCount++;
                    consoleErrorMessage = false;
                }

                Console.WriteLine("Enter customer's first name: ");
                consoleLineCount++;
                while (string.IsNullOrWhiteSpace(firstName) || !IsValidName(firstName))
                {
                    firstName = Console.ReadLine();
                    if (!IsValidName(firstName))
                    {
                        consoleLineCount = ShowErrorMessage("Please enter a valid first name with only letters, spaces, apostrophes, or hyphens.", consoleLineCount, consoleErrorMessage);
                        consoleErrorMessage = true;
                    }
                }
                consoleLineCount++;

                if (consoleErrorMessage)
                {
                    consoleLineCount++;
                    consoleErrorMessage = false;
                }

                Console.WriteLine("Enter loan amount: ");
                consoleLineCount++;
                bool amountContinue = true;
                double loanAmount = 1;
                while (amountContinue)
                {
                    double.TryParse(Console.ReadLine(), out loanAmount);
                    if (loanAmount >= 100000 || loanAmount <= 0)
                    {
                        consoleLineCount = ShowErrorMessage("Please enter a loan amount between R1 and R100 000", consoleLineCount, consoleErrorMessage);
                        consoleErrorMessage = true;
                    }
                    else
                    {
                        amountContinue = false;
                        consoleLineCount++;
                    }
                }

                if (consoleErrorMessage) { consoleLineCount++; }

                Console.WriteLine("\nEnter loan term\n1. Short-Term (1 year)\n2. Medium-Term (3 years)\n3. Long-Term (5 years)");
                consoleLineCount += 5;
                int loanTerm = 1;
                string loanTermTest = Console.ReadLine();
                if (loanTermTest == "")
                {
                    loanTerm = 1;
                }
                else { int.TryParse(loanTermTest, out loanTerm); }
                
                if (loanTerm == 2)
                {
                    loanTerm = 3;
                }
                else if (loanTerm == 3) { loanTerm = 5; }

                if (loanType == 1)
                {
                    loans[i] = new BusinessLoan(loanNumber, lastName, firstName, loanAmount, loanTerm, primeInterestRate);
                }
                else if (loanType == 2)
                {
                    loans[i] = new PersonalLoan(loanNumber, lastName, firstName, loanAmount, loanTerm, primeInterestRate);
                }
            }

            Console.Clear();
            Console.WriteLine(companyName.CompanyName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------------Loan Details--------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            int loanCount = 0;
            foreach (Loan loan in loans)
            {
                loanCount += 1;
                Console.WriteLine($"Loan {loanCount}");
                DateTime dueDate = DateTime.Today.AddDays(loan.Term * 365);

                Console.WriteLine(loan);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Total Amount Owed by " + dueDate.ToShortDateString() + ": R" + loan.CalculateTotalAmountOwed());
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }

        private static bool IsValidName(string text)
        { //Can test both first NAME and last NAME
            if (Regex.IsMatch(text, "^[A-Za-z\\s'-]+$"))
            {
                return true;
            }
            else { return false; }
        }

        private static int ShowErrorMessage(string message, int consoleLineCount, bool consoleErrorMessage)
        {
            if (consoleErrorMessage)
            {
                Console.SetCursorPosition(0, consoleLineCount); //In line with error message to overwrite
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message); //Overwrite
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, consoleLineCount + 1);
            }
            else
            {
                //If the error message hasn't been shown before we just need to display it
                Console.SetCursorPosition(0, consoleLineCount); //(Overwrite the incorrect input)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return consoleLineCount;
        }
    }
}
