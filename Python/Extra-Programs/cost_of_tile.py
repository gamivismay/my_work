"""
Calculate the total cost of tile it would take to cover a floor plan of width and height,
using a cost entered by the user
"""

# defining function to calculate cost of tile for specific width and height
def cost_of_tile(width,height,cost):
    # calculating total cost of W X H floor
    total_cost = width * height * cost
    return total_cost

# defining main function to run the program logic
def main():
    # getting and storing width from user input
    width = float(input("Enter the width: "))
    # getting and storing height from user input
    height = float(input("Enter the height: "))
    # getting and storing cost from user input
    cost = float(input("Enter the cost of tile: "))
    print(cost_of_tile(width, height, cost))

main()
