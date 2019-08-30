
# coding: utf-8

# <p>This is a program to calculate final marks of studends called as Automatic Grading of Students.</p>
# <p>Lecturer needs to add marks for assignment1, assignment2 and final exam marks.</p>
# <p>This program will then calculate the final marks automatically by calculating weighted marks and bonus marks.</p>
# <p>Weighted marks of assignment1, assignment2 and final exam are calculated from 20%, 30% and 50% respectively.</p>
# <p>There are also a bonus marks added to the final marks according to criteria, that if total weighted marks is less than 50, bonus marks will be 0.</p>
# <p>if total weighted marks is between 50 to 70, bonus marks will be 10% of every marks above 50.</p>
# <p>if total weighed marks is between 70 to 90, bonus marks will be 2 marks plus 15% of every marks above 70.</p>
# <p>if total weighted marks is between 90 to 100, bonus marks will be 5 marks plus 20% of every marks above 90.</p>
# <p>if final marks is more than 100 then it will rounded up to 100 as maximum possible marks is 100.</p>
# <p>lecturer can add more than one student.</p>

# In[3]:


# displays the welcome message with specific style
print("---------------------------------------------------------------")
print("The Innovation University of Australia (IUA) Grade System")
print("---------------------------------------------------------------")
print("")

# function to check if input marks is integer, and is between 0 to 100
# if it doesnot satisfy these two criteria then it will show warning message and will ask to give input again
def check_marks(message):
    while True:
        try:
            marks_input = int(input(message))
            if marks_input > 100 or marks_input < 0:
                print("Marks should be between 0 to 100 integer. Please try again by giving valid marks.")
                continue
        except ValueError:
            print("Marks should be in integer only. Please try again with positive integer value between 0 to 100.")
            continue
        else:
            return marks_input
            break


# In[4]:


# function to calculate weighted marks of assignment1, assignment2 and final exams out of
# 20%, 30% and 50% respectively
def calculate_weighted_marks(assignment, assignment_marks):
    if assignment == "assignment1":
        weighted_marks = assignment_marks * 20/100
    elif assignment == "assignment2":
        weighted_marks = assignment_marks * 30/100
    elif assignment == "final_exam":
        weighted_marks = assignment_marks * 50/100
    return float(weighted_marks)


# In[ ]:


# function to calculate bonus marks according to above mentioned conditions
def calculate_bonus_marks(marks):
    count = 0
    # checks if mark is between 0 to 50 then bonus marks will be 0
    if marks in range(0,51):
        extra_marks = 0
    # checks if marks are in between 51 to 70 then bonus marks, 10% of every marks above 50 will be added
    elif marks in range(51,71):
        extra_marks =  ((marks-50) * 10)/100
    # checks if marks are in between 71 to 90 then bonus marks, 2 plus 15% of every marks above 70 will be added
    elif marks in range(71,91):
        extra_marks = 2 + (((marks-70) * 15)/100)
    # checks if marks are in between 91 to 100 then bonus marks, 5 plus 20% of every marks above 90 will be added
    elif marks in range(91,101):
        extra_marks = 5 + (((marks-90) * 20)/100)
    else:
        print("wrong input")
    return float(extra_marks)


# In[ ]:


# function to calculate final marks
def calculate_final_marks():
    # getting student id number as input from lecturer
    student_id = input("Please enter the student ID: ")

    # getting student name as input from lecturer
    student_name = input("Please enter the student Name: ")

    print("")
    print("Please enter all marks out of 100.")
    # getting marks input of assignments and final exam with check if input is integer and is less than 100
    assignment1_marks = check_marks("Please enter the marks for Assignment 1: ")
    assignment2_marks = check_marks("Please enter the marks for Assignment 2: ")
    exam_marks = check_marks("Please enter the marks for the Final Exam: ")

    print("")
    print("Thank You!")
    print("")

    # calculating weighted marks for assignments by calling function to calculate weighted marks
    weighted_mark1 = calculate_weighted_marks("assignment1", assignment1_marks)
    weighted_mark2 = calculate_weighted_marks("assignment2", assignment2_marks)
    total_weighted_marks = (weighted_mark1 + weighted_mark2)
    print("Weighted mark for Assignment 1: {}".format(round(weighted_mark1,1)))
    print("Weighted mark for Assignment 2: {}".format(round(weighted_mark2,1)))
    print("Total weighted mark of the assignments: {}".format(round(total_weighted_marks,1)))

    print("")

    # calculating weighted marks for final exam by calling function to calculate weighted marks
    weighted_final_marks = calculate_weighted_marks("final_exam", exam_marks)
    total_subject_marks = (total_weighted_marks + weighted_final_marks)
    print("Weighted mark for the Final Exam is: {}".format(round(weighted_final_marks,1)))
    print("Total weighted mark for the subject: {}".format(round(total_subject_marks,1)))

    print("")

    # calculation bonus marks by calling fucntion to calculate bonus marks
    bonus_marks = calculate_bonus_marks(int(total_subject_marks))
    final_marks = (bonus_marks + total_subject_marks)
    # assigning final marks as 100 as maximum possible marks
    # if final marks is more than 100 after adding bonus marks
    if final_marks > 100:
        final_marks = 100.0
    print("Bonus mark: {}".format(round(bonus_marks,1)))
    print("Total mark with bonus: {}".format(round(final_marks,1)))
    print("")


# In[2]:


# function for Grade system logic
def grade_system():
    loop = True
    # calculates marks of another student till lecturer wants to
    while loop == True:
        calculate_final_marks()
        calculate_again = input("Do you want to enter marks for another student (Y/N)? ")
        print("")
        # checking if lecturer wants to continue calculating marks for another student
        if calculate_again == "Y" or calculate_again == "y":
            continue
        elif calculate_again == "N" or calculate_again == "n":
            print("Goodbye.")
            loop = False
        else:
            print("Wrong input. Please choose out of (Y/N) only.")
            print("")
            calculate_again = input("Do you want to enter marks for another student (Y/N)? ")
            print("")
            if calculate_again == "Y" or calculate_again == "y":
                continue
            elif calculate_again == "N" or calculate_again == "n":
                print("Goodbye.")
                loop = False


# call to run the grade system
grade_system()

