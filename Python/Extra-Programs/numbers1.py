import random

# GET USER GUESS
def get_guess():
    return input("What is your guess ?")


# GENERATE COMPUTER CODE
def generate_code():
    digits = [str(num) for num in range(5)]
    random.shuffle(digits)
    return digits[:3]

# GUESS CLUES
def generate_clues(user_code, computer_code):
    if user_code == computer_code:
        return "CODE CRACKED"

    clues = []

    for ind,num in enumerate(user_code):
        if num == computer_code[ind]:
            clues.append("Match")
        elif num in computer_code:
            clues.append("Close")

    if clues == []:
        return "Nope"
    else:
        return clues

# RUN GAME LOGIC
print("Welcome Code Breaker! Let's see if you can guess my 3 digit number!")
secretCode = generate_code()
print("Code has been generated, please guess a 3 digit number")

clue_report = []

while clue_report != "CODE CRACKED":

    # Ask for guess
    guess = get_guess()

    # Give the clues
    clue_report = generate_clues(guess,secretCode)
    print("Here is the result of your guess:")
    for clue in clue_report:
        print(clue)
