"""
Practice Program - 3
This program is to calculate fibonacci sequence upto the nth number which is input by user
"""

# defining function to calculate fibonacci sequence
def fibonacci_seq(num):
    # declaring list with two initial value which will be fixed for fibonacci sequence
    fib_seq_list = [0,1]

    # using for loop to loop till the number user entered
    for i in range(2,num+1):
        # adding each value to the list using append method
        fib_seq_list.append(fib_seq_list[i-1] + fib_seq_list[i-2])
    #returning the result value list
    return fib_seq_list

# defining main function to run the program logic
def main():
    # getting user input
    num = int(input("Please enter the number till you want to calculate fibonacci sequence: "))
    # calling fibonacci_seq function byu passing user input value as argument and returning the value
    print(fibonacci_seq(num))

# calling main function
main()
