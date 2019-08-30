"""
Calculate the monthly payments of a fixed term mortgage over given Nth terms at a given interest rate.
Also figure out how long it will take the user to pay back the loan.
"""

# defining function to calculate mortgage payments per month according to the values passes
def calculate_payments(monthly_term, interest_rate, loan_value):
    # calculating monthly interest rate
    monthly_rate = interest_rate/100/12
    # storing values in single named variable to easily write the formula
    p = loan_value
    n = monthly_term
    r = monthly_rate
    # formula to calculate monthly mortgage payment
    monthly_payments = p*((r*((1+r)**n))/(((1+r)**n)-1))
    return monthly_payments

# defining main function to run to program logic
def main():
    # getting input from user
    monthly_term = int(input("Enter mortgage term (in months): "))
    interest_rate = float(input("Enter interest rate: "))
    loan_value = float(input("Enter loan value: "))
    print("Monthly payment for a $%.2f loan amount over a period of %s months at interest rate of %.2f%% is: $%.2f " % (loan_value, monthly_term,interest_rate,calculate_payments(monthly_term,interest_rate,loan_value)))

# calling main function to run the program
main()
