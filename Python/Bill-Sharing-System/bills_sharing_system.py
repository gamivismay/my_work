
# coding: utf-8

# <h1>Bills Sharing System</h1>

# <h4>Purpose of this system is to calculate bills sharing amount per head between roommates.</h4>

# In[1]:


# import necessary libraries
import numpy as np
import pandas as pd
from os import listdir
from IPython import display
import ipywidgets as widgets
from tabulate import tabulate


# In[2]:


# global variable declaration
names = []


# In[78]:


# calculating bills starts here - option 1
def calculate_bills():
    global names
    calculate_again = "True"
    print("Choose bill file to start calculating bills.")
    file_name = select_bill()
    print(f"Calculating bills for: {file_name}")
    open_file = open("bills/" + file_name ,'r')
    names = ((open_file.readline()).strip()).split(',')[2:]
        
    while calculate_again:
        bill_no = input("Enter bill name: ")
        item_amount = float(input("Enter item amount: "))
        print("Please select names of contributors in this item.")
        label = widgets.Label()
        checkbox_dict = {description: widgets.Checkbox(description=description, value=False, indent=False) for description in names}
        checkbox = [checkbox_dict[description] for description in names]     
        selected_contributors = []    
        print(f"Before selection: {selected_contributors})
        hbox = widgets.HBox(checkbox, layout={'overflow': 'scroll'})
        vbox = widgets.VBox([hbox, label])
        display(vbox)
        item_option = input("Do you want to enter another item? (Y/N): ").upper()
        if item_option == 'Y':
            selected_contributors = [checkbox[i].description for i in range(0,len(checkbox)) if checkbox[i].value == True]
            label.value = str(selected_contributors)[1:-1]
            print(f"After selection: {selected_contributors}")
        elif item_option == 'N':
            calculate_again = False
            break 
                


# In[79]:


calculate_bills()


# In[77]:


selected_contributors


# In[61]:


from IPython.display import display
import ipywidgets as widgets

def f(x):
    return 'value of checkbox is: ' + str(x)

w = widgets.Checkbox(value=True, description='Updated?')
interact(f,x=w)


# In[68]:


def select_contributors():
    label = widgets.Label()
    checkbox_dict = {description: widgets.Checkbox(description=description, value=False, indent=False) for description in names}
    checkbox = [checkbox_dict[description] for description in names]     
    selected_contributors = []    
    hbox = widgets.HBox(checkbox, layout={'overflow': 'scroll'})
    vbox = widgets.VBox([hbox, label])
    display(vbox)
    selected_contributors = [checkbox[i].description for i in range(0,len(checkbox)) if checkbox[i].value == True]
    label.value = str(selected_contributors)[1:-1]
    print(label.value)
        


# In[69]:


select_contributors()


# In[71]:


selected_contributors


# In[6]:


def add_contributors():
    global names
    names_choice = input("Enter contributor's names seperarted with comma (e.g. vismay, gami): ").split(',')
    names = [name.strip() for name in names_choice]
    return names


# In[7]:


# create a new file for bill session every month
def create_file(file_name, names):
    header_line = "Bill_No,Item_amount," + ",".join(names) + "\n"
    new_file = open("bills/" + file_name + ".csv",'w')
    new_file.write(header_line)
    new_file.close()


# In[8]:


# select any one bill out of all
def select_bill():
    bills_list = pd.DataFrame(listdir("bills/"), columns=["bills"])
    print(tabulate(bills_list, headers='keys', tablefmt = 'orgtbl'))
    bill_no = int(input("Please enter index number of bill to read its data: "))
    bill_name = bills_list.iloc[bill_no]['bills']
    return bill_name


# In[9]:


# read data from bill file
def read_bills():
    read_bill_name = select_bill()
    file_data_set = pd.read_csv("bills/" + read_bill_name)
    print(tabulate(file_data_set, headers='keys', tablefmt='rst'))
    return file_data_set


# In[10]:


# writes data to bill file
def write_bills(file_name):
    write_data = open(file_name,'w')
    write_data.write()
    write_data.close()


# In[11]:


# append data to bill file
def append_bills(file_name):
    append_data = open('','w')
    append_data.write()
    append_data.close()


# In[ ]:


# Main logic 
global names
print("Welcome to Bills calculating system.")

select_again = True
while select_again:
    option = int(input("1. Create New File \n2. Calculate Bills \n3. Read Bills \n4. Edit Bills \n5. Quit \nChoose any one option:"))
    if option == 1:
        file_name = input("Please enter file name: ")
        add_contributors()
        create_file(file_name, names)
        print("New file {} created.".format(file_name))
    elif option == 2:
        calculate_bills()
    elif option == 3:
        read_bills()
    elif option == 4:
        pass
    else:
        print("Session complete..!")
        break
        select_again = False

