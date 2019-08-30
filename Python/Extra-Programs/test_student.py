# importing necessary packages
import pandas as pd
import student as student

# delclare print statements
print("Welcome to student details program..!")
print("1. Display the student list.")
print("2. Search a student.")
print("3. Add a new student.")
print("4. Quit.")

# declare all variables
student_list = pd.read_csv('students.csv')
loop = True

# while loop to keep asking option untill user quits
while loop:
    user_choice = input("Choose option from above: ")

    if user_choice == "1":
        print(student_list)
        
    elif user_choice == "2":
        search_id = int(input("Enter student id to search: "))
        
        if search_id in [id_list for id_list in student_list['Id']]:
            search_student = student_list.loc[student_list['Id'] == search_id]
            print(search_student)
    
        else:
            print("Student id does not exist. Please try again.")

    elif user_choice == "3":
        valid_student = True
        print("Add below details to add new student.")
        
        while valid_student:
            new_student_name = input("Enter student name: ")
            new_student_id = int(input("Enter student id: "))
            
            if (len(str(new_student_id)) == 6) and (new_student_id not in [id_list for id_list in student_list['Id']]):
                new_student = student.Student(new_student_name, new_student_id)
                open_file = open('students.csv', 'a')
                open_file.write(f"{new_student_id},{new_student_name}")
                open_file.close()
                valid_student = False
                break
            
            else:
                print("student id already exisits or doesnot satisfy id criteria. Please try again.")        
        print(new_student)
                        
    else:
        print("Either user have quit the program or program is ended due to invalid response.")
        loop = False
        break
