"""
Develop a converter to convert a decimal number to binary or a binary number to its decimal equivalent.
"""

# defining function to convert from decimal to binary
def decimal_to_binary(num):
    # returns binary number by builtint function
    return bin(num)

# defining function to convert from binary to decimal
def binary_to_decimal(num):
    # returns decimal number by builtin function
    return int(num,2)

# defining main function to define the program logic
def main():
    # getting input from user
    num = int(input("Enter decimal number to convert into binary: "))
    # converting that number to binary by calling function
    binary_value = decimal_to_binary(num)
    print("Binary value for {} is {}.".format(num, binary_value))
    print("Decimal value for {} is {}.".format(str(binary_value), binary_to_decimal(binary_value)))

# calling main function to run the program
main()
