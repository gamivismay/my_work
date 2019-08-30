"""
Practice Program-4
Have the user enter a number and find all Prime Factors (if there are any) and display them.
"""

# defining prime_factorization function to find all the prime numbers
def prime_factorization(num):
    # declaring empty list to store all prime factors
    prime_factors = []
    # using loop to loop from 1 to the number entered by user
    for i in range(1,num+1):
        # setting counter to 0
        count = 0
        # checking if number entered is divisbile by each number from the range
        if num%i == 0:
            # using another loop to check if the number is prime number or not by checking if it is only
            # divisble by itself and one
            for j in range(1,num+1):
                if i%j == 0 and i%1 == 0:
                    count += 1
            if count == 2:
                # if the number is factor of the number entered and also is the prime number
                # then its added to empty list of prime_factors
                prime_factors.append(i)
    # return value of function which is a list of prime factors
    return prime_factors

# defining main function to run the logic of the program
def main():
    # getting input from user
    num = int(input("Please enter the number: "))
    # printing out the out if the another function when value passed as argument
    print(prime_factorization(num))

# calling main function to run the program
main()
