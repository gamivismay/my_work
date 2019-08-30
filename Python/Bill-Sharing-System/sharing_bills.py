"""
Purpose of this program is to simplify sharing bills between roommates
"""

all_contributors = {'item_id':[],'bill_no':[],'item_amount':[], 'vismay':[], 'jigar':[], 'harshil':[], 'pratik':[],'dhruv':[],'savan':[],'naresh':[]}

def read_bills(file_name):
    line_list = []
    clear_data()

    session_list = open(file_name,"r")
    session_list.readline()
    print("{:9} | {:15} | {:12} | {:8} | {:7} | {:9} | {:8} | {:7} | {:7} | {:8}".format("Item_id", "Bill_no", " Item_amount","  Vismay", "  Jigar", "  Harshil", "  Pratik", "  Dhruv", "  Savan", "  Naresh"))
    print("{:9} | {:15} | {:12} | {:8} | {:7} | {:9} | {:8} | {:7} | {:7} | {:8}".format("---------", "---------------", "------------","--------", "-------", "---------", "--------", "-------", "-------", "--------"))

    index = 0
    for line in session_list:
        line_list = (line.strip()).split()
        all_contributors['item_id'].append(line_list[0])
        all_contributors['bill_no'].append(line_list[1])
        all_contributors['item_amount'].append(float(line_list[2]))
        all_contributors['vismay'].append(float(line_list[3]))
        all_contributors['jigar'].append(float(line_list[4]))
        all_contributors['harshil'].append(float(line_list[5]))
        all_contributors['pratik'].append(float(line_list[6]))
        all_contributors['dhruv'].append(float(line_list[7]))
        all_contributors['savan'].append(float(line_list[8]))
        all_contributors['naresh'].append(float(line_list[9]))
        print("{:9} | {:15} | {:12.2f} | {:8.2f} | {:7.2f} | {:9.2f} | {:8.2f} | {:7.2f} | {:7.2f} | {:8.2f}".format(str(all_contributors['item_id'][index]), all_contributors['bill_no'][index], all_contributors['item_amount'][index], all_contributors['vismay'][index], all_contributors['jigar'][index], all_contributors['harshil'][index], all_contributors['pratik'][index], all_contributors['dhruv'][index], all_contributors['savan'][index], all_contributors['naresh'][index]))
        index += 1
    return all_contributors

def append_bills(file_name):
    append_new_line = open(file_name,"a")
    for item in all_contributors['item_id']:
        index = all_contributors['item_id'].index(item)
        new_line = "{:9} {:15} {:12} {:8} {:7} {:9} {:8} {:7} {:7} {:8} \n".format(str(all_contributors['item_id'][index]), all_contributors['bill_no'][index], all_contributors['item_amount'][index], all_contributors['vismay'][index], all_contributors['jigar'][index], all_contributors['harshil'][index], all_contributors['pratik'][index], all_contributors['dhruv'][index], all_contributors['savan'][index], all_contributors['naresh'][index])
        append_new_line.write(new_line)
    append_new_line.close()

def write_bills(file_name):
    session_file_create = open(file_name, 'w')
    # writting first line in new session file
    write_new_line = "{:9} {:15} {:12} {:8} {:7} {:9} {:8} {:7} {:7} {:8} \n".format("item_id", "bill_no", " item_amount", "  vismay", "  jigar", "  harshil", "  pratik", "  dhruv", "  savan", "  naresh")
    session_file_create.write(write_new_line)
    session_file_create.close()

def select_bill():
    line_list = []
    session_list = open("all-session.txt","r")
    session_list.readline()
    print("{:5} {:15}".format("Session_id", "Name"))
    index = 0
    for line in session_list:
        line_list.append(line.strip())
        print("{:5} {:15}".format(str(index), line_list[index]))
        index += 1
    option = input("Select session id to add or display its data: ")
    return line_list[int(option)]

def clear_data():
    all_contributors['item_id'] = []
    all_contributors['bill_no'] = []
    all_contributors['item_amount'] = []
    all_contributors['vismay'] = []
    all_contributors['jigar'] = []
    all_contributors['harshil'] = []
    all_contributors['pratik'] = []
    all_contributors['dhruv'] = []
    all_contributors['savan'] = []
    all_contributors['naresh'] = []

# defining function to add new session
def add_new_session():

    session_list = []

    # creating new file for new session
    new_session_file_name = input("Please enter file name: ") + ".txt"

    # reading file containing all bills name
    read_session_list = open("all-session.txt", "r")
    read_session_list.readline()
    for line in read_session_list:
        l = line.strip()
        session_list.append(l)

    if new_session_file_name in session_list:
        return True
    else:
        write_bills(new_session_file_name)

        # adding this new session file's name in session's file list
        all_session_filelist = open("all-session.txt", "a")
        all_session_filelist.write(new_session_file_name + "\n")
        all_session_filelist.close()
        return False

def add_new_bill():
    clear_data()
    start_index = 1
    loop = True
    while loop:
        option = input("Please choose function to perform: \na. Add new bill \nb. Finish and finalize bills (only after adding all the bills) \n")
        if option == 'a':
            bill_no = input("Enter bill number (strictly do not put any space): ")
            add = True
            while add:
                amount = input("Enter the item amount (press q to quit adding items to this bill): ")
                if amount == 'q':
                    add = False
                    break
                else:
                    contributor = input("Enter name of contributors separated by comma (,): ")
                    names_list = contributor.split(',')
                    amount_per_head = round(float(amount)/len(names_list),2)
                    all_contributors['item_amount'].append(round(float(amount),2))
                    all_contributors['bill_no'].append(bill_no)
                    all_contributors['item_id'].append(start_index)
                    for name in all_contributors.keys():
                        if name in names_list:
                            all_contributors[name].append(amount_per_head)
                        elif name not in names_list and name != 'item_amount' and name != 'bill_no' and name != 'item_id':
                            all_contributors[name].append(0.00)
                    start_index += 1

        elif option == 'b':
            file_name = select_bill()
            append_bills(file_name)
            print("Total of all bills have been finalised.")
            clear_data()
            loop = False
            break


def edit_bills():
    loop = True
    while loop:
        option = input("Please choose function to perform: \na. Edit bill \nb. Quit \n")
        if option == 'a':
            clear_data()
            file_name = select_bill()
            read_bills(file_name)
            option = input("Select item_id for the item_amount to be edited: ")
            amount = input("Enter new amount: ")
            contributor = input("Enter name of contributors separated by comma (,): ")
            names_list = contributor.split(',')
            amount_per_head = round(float(amount)/len(names_list),2)
            index = all_contributors['item_id'].index(option)
            all_contributors['item_amount'][index] = round(float(amount),2)
            for name in all_contributors.keys():
                if name in names_list:
                    all_contributors[name][index] = amount_per_head
                elif name not in names_list and name != 'item_amount' and name != 'bill_no' and name != 'item_id':
                    all_contributors[name][index] = 0.00
            write_bills(file_name)
            append_bills(file_name)
            print("Item has been changed. Please read bills to check the changes.")
            clear_data()
        elif option == 'b':
            clear_data()
            loop = False
            break


def main():
    print("Program to calculate bills. (vismay,jigar,harshil,pratik,dhruv,savan,naresh)")
    loop = True

    while loop:
        option = input("Choose option from (1 to 3): \n1. Create new bill session \n2. Create new bills \n3. Read old bills \n4. Edit bills \n5. Quit \n")
        if option == "1":
            exists = add_new_session()
            if exists:
                print("File already exists. Please go for another option")
            else:
                print("Bill session created. Start adding bills to session.")
        elif option == "2":
            add_new_bill()
        elif option == "3":
            file_name = select_bill()
            contributors_details = read_bills(file_name)
            print("{:9} | {:15} | {:12} | {:8} | {:7} | {:9} | {:8} | {:7} | {:7} | {:8}".format('none', 'Total', round(sum(contributors_details['item_amount']),2), round(sum(contributors_details['vismay']),2), round(sum(contributors_details['jigar']),2), round(sum(contributors_details['harshil']),2), round(sum(contributors_details['pratik']),2), round(sum(contributors_details['dhruv']),2), round(sum(contributors_details['savan']),2), round(sum(contributors_details['naresh']),2)))
        elif option == "4":
            edit_bills()
        elif option == "5":
            loop = False
            print("Program ends. Good Bye!")

main()
