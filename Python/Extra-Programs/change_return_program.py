"""
The user enters a cost and then the amount of money given.
The program will figure out the change and the number of quarters, dimes, nickels, pennies needed for the change.

Quarter= 25 cents
Dime= 10 cents
Nickel= 5 cents
Penny= 1 cent
"""

# defining function to calculate the change after the given value of cost and money given
def calculate_change(cost, money):
    return money-cost

# defining function to calculate quarter required for change
def calculate_quarter(change_left):
    # calculating quarter required
    quarter = int((change_left * 100) / 25)
    # calculating change left after getting quarter value
    change_left = change_left - (quarter*0.25)
    # return two values, quarter and change left after quarter
    return quarter, change_left

# defining function to calculate dime required for change
def calculate_dime(change_left):
    # calculating dime required
    dime = int((change_left * 100) / 10)
    #calculating change left after getting dime value
    change_left = change_left - (dime * 0.10)
    # return two values, dime and change left after dime
    return dime, change_left

# defining function to calculate nickel required for change
def calculate_nickel(change_left):
    # calculating nickel required
    nickel = int(change_left * 100 / 5)
    # calculating change_left after getting nickel value
    change_left = change_left - (nickel * 0.05)
    # return two value, nickel and change left after nickel
    return nickel, change_left

# defining function to calculate penny required for change
def calculate_penny(change_left):
    return int(change_left * 100)

# defining main function to define the program logic
def main():
    # getting cost value from user input
    cost = float(input("Enter the cost: $ "))
    # getting given money value from user input
    money = float(input("Enter the money: $ "))
    # calculating change left by calling calculate_change function
    change_left = calculate_change(cost,money)
    print("Change left is ${}".format(round(change_left,2)))
    print("="*15)
    # getting and storing value for quarter and change left after quarter
    quarter,change_left = calculate_quarter(change_left)
    # getting and storing value for dime and change left after dime
    dime, change_left = calculate_dime(change_left)
    # getting and storing value for nickel and change left after nickel
    nickel, change_left = calculate_nickel(change_left)
    # getting and storing value for penny
    penny = calculate_penny(change_left)
    print("Quarter: %3d " % quarter)
    print("Dime: %6d " % dime)
    print("Nickel: %4d " % nickel)
    print("Penny: %5d " % penny)

# calling main function to run the program
main()
