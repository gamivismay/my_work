# display the game board
import random
# from IPython.display import clear_output this is import library to clear output which runs only in notebook

def display_board(board):

    # clear_output() this method is useful when you run this program in notebook
    print(board[7] + "|" + board[8] + "|" + board[9])
    print("-----")
    print(board[4] + "|" + board[5] + "|" + board[6])
    print("-----")
    print(board[1] + "|" + board[2] + "|" + board[3])

# choosing player from player1 and player2 randomly to start the game
def choose_player():
    num = random.randint(0,1)

    if num == 0:
        choice = "player1"
    else:
        choice = "player2"

    return choice

# choosing random player and asking to give input from X or O
def marker_choice():
    marker = ""

    while marker != "X" and marker != "O":
        marker = input("player1, Choose from X or O: ").upper()

    if marker == "X":
        return ('X', 'O')
    else:
        return ('O', 'X')

# now placing player's input into game board along with position
def place_marker(board, marker, position):
    board[position] = marker


# This function checks is any player has won the game
def check_win(board, mark):
    return (board[1] == board[2] == board[3] == mark or
    board[4] == board[5] == board[6] == mark or
    board[7] == board[8] == board[9] == mark or
    board[1] == board[4] == board[7] == mark or
    board[2] == board[5] == board[8] == mark or
    board[3] == board[6] == board[9] == mark or
    board[1] == board[5] == board[9] == mark or
    board[3] == board[5] == board[7] == mark)

# check blank space
def space_check(board, position):
     return board[position] == " "

# check if any of the positions are available
def full_board_check(board):

    for i in range(1,10):
        if space_check(board, i):
            return False
    return True

# get player position and check if it is empty
def check_position(board):
    position = 0

    while position not in range(1,10) and not space_check(board, position):
        position = int(input("Choose your position: (1-9) "))

    return position

# check if player wants to play game again
def replay():
    choice = input("Play again? yes or no")
    return choice == "yes"

# game logic
def game_logic():

    print("Welcome to the tic tac toe game.")

    while True:

        board = [" "] * 10

        player1_marker, player2_marker = marker_choice()
        player = choose_player()
        print("{} will go first.".format(player))

        play_game = input("Ready to play? y or n?")

        if play_game == 'y':
            game_on = True
        else:
            game_on = False

        while game_on:
            if player == "player1":
                display_board(board)

                position = check_position(board)
                place_marker(board, player1_marker, position)

                if check_win(board, player1_marker):
                    display_board(board)
                    print("Player1 has won the game..!")
                    game_on = False
                else:
                    if full_board_check(board):
                        display_board(board)
                        print("Tie Game")
                        game_on=False
                    else:
                        player = "player2"

            else:
                display_board(board)

                position = check_position(board)
                place_marker(board, player2_marker, position)

                if check_win(board, player2_marker):
                    display_board(board)
                    print("Player2 has won the game..!")
                    game_on = False
                else:
                    if full_board_check(board):
                        display_board(board)
                        print("Tie Game")
                        game_on=False
                    else:
                        player = "player1"

        if not replay():
            break

game_logic()
