
# coding: utf-8

# In[1]:


"""
This is program for Soccer Player Management and Visualisation System.

The program is based on European Soccer Database which contains the records of players including
player's Id, Name, Age, Height and Weight in text file Players.txt.

This system has features to add new player, search details of particular player and finally visualise data
of player in histogram.
"""

# import matplotlib for displaying data in histogram
import matplotlib.pyplot as plot

# Globally defining list variables to store all the data from file like id, name, age, height, weight
# and whole list data
players_list = []
players_id_list = []
players_name_list = []
players_age_list = []
players_height_list = []
players_weight_list = []


# function to get all data from txt file and store in list.
# Also it call write function to rewrite the file for new formatting.
def read_data():
    # open text file for read operation
    players_file = open("Players.txt", 'r')
    # reads line by line in text file
    players_file.readline()
    # reading all the lines one by one using for loop in text file data
    for line in players_file:
        # removing all the pre and post spaces and splitting all the data by from internal space
        line_list = (line.strip()).split()
        # stores separated like id, age, height, weight in their respective variables
        player_id = line_list[0]
        player_weight = line_list[-1]
        player_height = line_list[-2]
        player_age = line_list[-3]
        player_name = ''
        # using for loop for name by removing non digits and . from name
        for name in line:
            if not name.isdigit() and name != '.':
                player_name = player_name + name
        # removes all the pre and post spaces from name
        player_name = player_name.strip()
        # storing all the data as a nested list in main players list to use that data for search and visualise purpose
        players_list.append([player_id, player_name, player_age, player_height, player_weight])
        # storing all the data in respective lists seperately stored in variables,using append method
        players_id_list.append(player_id)
        players_name_list.append(player_name)
        players_age_list.append(player_age)
        players_height_list.append(player_height)
        players_weight_list.append(player_weight)
    # closing the text file
    players_file.close()
    # write all the data again in text file with new formatting to use again for adding new player data
    write_data(players_list)
    return players_list


# This function rewrites the whole file to create new formatting and stores the basic data.
# This will be called only once so next time to add new data, it can be added to the file with append method.
def write_data(players_list):
    # opens text file to write the data
    write_players_file = open("Players.txt", 'w')
    # writes first line with headings
    write_first_line = "{:15} {:35} {:15} {:15} {:15} \n".format("Player ID", "Player Name", "Age", "Height(cm)", "Weight(kg)")
    write_players_file.write(write_first_line)
    # get all the data line wise from main players list and writes in text file as a line one by one with formatting
    for line in players_list:
        # stroring all the data in respective variables
        write_player_id = line[0]
        write_player_name = line[1]
        write_player_age = line[2]
        write_player_height = line[3]
        write_player_weight = line[4]
        # creating new file to write in text file according to proper format
        new_line = '{:15} {:35} {:15} {:15} {:15} \n'.format(write_player_id, write_player_name, write_player_age, write_player_height, write_player_weight)
        # writes all the data in text file.
        write_players_file.write(new_line)
    # file is closed after write operation
    write_players_file.close()


# This function adds the new player data using append method according to proper formatself.
# so that whole file is not rewritten again and again for every new player added
def append_data(new_player_data):
    # opens file for append purpose
    append_players_file = open("Players.txt", 'a')
    # stores all the new data in respective variables
    append_player_id = new_player_data[0]
    append_player_name = new_player_data[1]
    append_player_age = new_player_data[2]
    append_player_height = new_player_data[3]
    append_player_weight = new_player_data[4]
    # creates a new line according to similar file format
    new_line = '{:15} {:35} {:15} {:15} {:15} \n'.format(append_player_id, append_player_name, append_player_age, append_player_height, append_player_weight)
    # append new line data at the end of file
    append_players_file.write(new_line)
    # closes file after appending the new data in file
    append_players_file.close()


# checking if the input string in digit or not
def is_number(s):
    try:
        float(s)
        return True
    except ValueError:
        pass
    return False


# function to add player to text file
def add_player():
        # asks user to input all the data one by one
        add_player_id = input("Please enter the player ID: ")
        add_player_name = input("Please enter the player name: ")
        add_player_age = input("Please enter the age: ")
        add_player_height = input("Please enter the height: ")
        add_player_weight = input("Please enter the weight: ")
        # checking if the player with new id already exists or not
        if add_player_id in players_id_list:
            print("Player id already exists! Please try with different player id.")
        # checking if age, height and weight is digit number or not
        elif (not is_number(add_player_age)) or (not is_number(add_player_height)) or (not is_number(add_player_weight)):
            print("Only digit is allowed for age, height and weight. Please try again.")
        # if every condition is ok, then data of new player is approved
        else:
            # printing out details of new player
            print("\nThank You!\n")
            print("The details of the player you entered are as follows:")
            print(f"Player ID: {add_player_id}")
            print(f"Player Name: {add_player_name}")
            print(f"Age: {add_player_age}")
            print(f"Height: {add_player_height}")
            print(f"Weight: {add_player_weight}")
            print("The record has been successfully added to the Player.txt file.")
            # creating new list with new player data to append in respective lists and main players list as well.
            new_player_data = [add_player_id, add_player_name, add_player_age, add_player_height, add_player_weight]
            players_list.append([add_player_id, add_player_name, add_player_age, add_player_height, add_player_weight])
            players_id_list.append(add_player_id)
            players_name_list.append(add_player_name)
            players_age_list.append(add_player_age)
            players_height_list.append(add_player_height)
            players_weight_list.append(add_player_weight)
            # calling append_data method to add this new player's data at the end of text file
            append_data(new_player_data)


# function to search a player if it exists in Players.txt file
def search_player():
    # asking user to input player id to search
    player_search_id = input("Please enter the player ID you want to search: ")
    print("\nThank You!\n")
    # checking if player with input user id is available in file or not
    if player_search_id in players_id_list:
        # if player is found, then all the details is displayed
        player_index = players_id_list.index(player_search_id)
        print("One player has been found:")
        print("Player ID: {}".format(players_list[player_index][0]))
        print("Player name: {}".format(players_list[player_index][1]))
        print("Age: {}".format(players_list[player_index][2]))
        print("Height: {}".format(players_list[player_index][3]))
        print("Weight: {}".format(players_list[player_index][4]))
    # notifying user that not data has been found with this player id
    else:
        print("No player found with this id.")


# Displaying histogram from matplotlib for three attributes age, height and weight
def display(attribute_list, attribute_name, units):
    # giving title to histogram
    plot.title("Histogram of " + attribute_name)
    # giving label to x-axis
    plot.xlabel(attribute_name + ' ' + units)
    # giving label to y-axis
    plot.ylabel("Frequency")
    # provide data to plot and bins for the Histogram
    plot.hist(attribute_list, bins=range(int(min(attribute_list)), int(max(attribute_list))))
    # show the histogram
    plot.show()


# function to visualise the data from the file
def visualise_data():
    print("1. Age \n2. Height \n3. Width")
    # asking for user input to one attribute out of three
    visualise_option = input("Please select the attribute you want to visualise: ")
    # checking one out of three option and displays details accordingly
    if visualise_option == '1':
        print("Displaying histogram for age..")
        # displaying histogram for age attribute by calling display method
        display(list(map(int, players_age_list)), "Age", "(years)")
    elif visualise_option == '2':
        print("Displaying histogram for height..")
        # displaying histogram for height attribute by calling display method
        display(list(map(int, players_height_list)), "Height", "(Centimeters)")
    elif visualise_option == '3':
        print("Displaying histogram for weight..")
        # displaying histogram for weight attribute by calling display method
        display(list(map(float, players_weight_list)), "Weight", "(Kilograms)")
    else:
        # displaying message if no data is found
        print("No Data Found. Please try again.")


# main function to run the program logic
def player_system():
    # calling read_data method to read data from file, storing in lists and rewrite file again with format
    read_data()
    system_on = True
    # using while loop to contiue program untill user quits it manually
    while system_on:
        # displaying startup messages
        print("="*64)
        print("Welcome to the Soccer Player Management and Visualisation System")
        print("<A>dd details of a player.\n<S>earch student details for a player.\n<V>isualise student details.\n<Q>uit.")
        print("="*64)
        # asking user input for which feature user wants to use from add, search, visualise or quit
        user_option = (input("Please select an option from the above: ")).upper()
        # checking which feature user chose
        # going further operation for add new player feature
        if user_option == "A":
            add_again = "Y"
            # using while loop to continue adding new players untill user cancels it
            while add_again == "Y":
                # calling add_player method that takes input player's detail from user and adds in list and Players.txt file
                add_player()
                # asking again if user wants to add another player or stop adding player
                add_again = (input("Do you want to enter details for another player (Y/N)? ")).upper()
        # going for search feature
        elif user_option == "S":
            search_again = "Y"
            # using while loop to continue searching player details untill user cancels it
            while search_again == "Y":
                # calling search_player method that takes input player's id from user and search in Players.txt file
                search_player()
                # asking again if user wants to search another player or stop searching player
                search_again = (input("Do you want to search for another player (Y/N)? ")).upper()
        # going for visualise feature
        elif user_option == "V":
            visualise_again = "Y"
            # using while loop to continue visualising player details untill user cancels it
            while visualise_again == "Y":
                # calling visualise_data method that takes input player's attribute from user and visualise in histogram
                visualise_data()
                # asking again if user wants to visualise another attribute or stop visualising attributes
                visualise_again = (input("Do you want visualise for another attribute (Y/N)? ")).upper()
        # quits the program by choosing quit option
        elif user_option == "Q":
            print("Program ends here.")
            system_on = False
        else:
            continue


# calling player_system method to start program
player_system()

