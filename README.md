# c#-_BusinessLoanSystem

The project is to create a C# Console application that tracks construction loans for a company called Unique Building Services Loan Company. The application should calculate the total amount owed at the due date for each loan and include the following classes:

Loan: An abstract class that represents a loan with properties like loan number, customer name, loan amount, interest rate, and term.
LoanConstants: An interface class that defines constants for loan terms and company information.
BusinessLoan: A class that extends Loan and sets the interest rate for business loans.
PersonalLoan: A class that extends Loan and sets the interest rate for personal loans.
CreateLoans: An application that creates an array of loans, prompts the user for input, and stores the created loans in the array.
