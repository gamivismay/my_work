import java.util.*;
import java.io.*;

public class TestStudent {
	public static void main(String[] args) throws IOException
	{
		// creating object for class student to do different operations
		Student student1 = new Student();
		
		// using scanner class to get input from user
		Scanner userInput = new Scanner(System.in);
		
		// reading data from text file
		File studentFile = new File("students.txt");

		
		// using scanner class to read data from text file 
		Scanner getStudentDetails = new Scanner(studentFile);
		
		// creating array list that takes and stores all the data from text file in specific format
		ArrayList<String> studentList = new ArrayList<String>();
		
		// using while loop to read each line in text file
		while(getStudentDetails.hasNext())
		{
			// removes pre and post spaces from the line and separates data by space in middle
			String[] studentDetails = ((getStudentDetails.nextLine()).trim()).split("\\s+");
			// storing student id from text file in student id variable
			String studentId = studentDetails[0];
			String studentName = "";
			// using for loop to get student name
			for(String s:studentDetails)
			{
				if (s.matches("[a-zA-Z]+"))
				{
					studentName = studentName + " " + s;	
				}
			}
			// setting student name
			student1.setName(studentName);
			// setting student id
			student1.setId(studentId);
			// adding each student details in array list in string representation format defined in 
			// student class by calling tostring method
			studentList.add(student1.toString());
		}
		
		// writes all the data stored in array list to text file with new formatting by calling writeStudents method
		writeStudents(studentList);
		
		boolean loop = true;
		
		// using while loop to start the program and asks user options until user quit the program manually
		while(loop)
		{
			// starts the program by displaying options to customer
			System.out.print("Welcome to student details program..! \n");
			System.out.print("1: Display the students list \n2. Search a student \n3. Add a new student \n4. Quit \nChoose option from above: ");
			// stores user input in variable
			String option = userInput.nextLine();
			System.out.println("\n");
			// checking if user chose option 1, that is to display students list
			if(option.equals("1"))
			{
				// displays student list by using for loop
				for(String str: studentList)
				{
					System.out.println(str);
				}
				System.out.println("\n");
			}
			// checking if user chose option 2 that is to display student details with student id input by user
			else if(option.equals("2"))
			{
				// asking user to input student id that needs to be searched
				System.out.print("Enter student id you want to search for: ");
				String searchId = userInput.nextLine();
				// using for loop to get all data in array list
				for(String str:studentList)
				{
					// checking if id is valid and matches the requirement and is inside the student details
					if(str.contains(searchId) && student1.isValidId(searchId))
					{
						// if found, displays the student details with that id
						System.out.println(str);
						System.out.println("\n");
						break;
					}
					else
					{
						continue;
					}
				}
			}
			// checking if user chose option 3 that is to add new student data
			else if(option.equals("3"))
			{
				String cont = "Y";
				
				// using while to continue adding students until user says no
				while(cont.equals("Y"))
				{
					String id; 
					String name;
					// getting new student id
					System.out.print("Input student id(should be 6 digits only): ");
					id = userInput.nextLine();
					// getting new student name
					System.out.print("Input student name: ");
					name = " " + userInput.nextLine();
					{
						// checking if id formatting is valid by calling isvalidid method from student class
						if(student1.isValidId(id) == false)
						{
							System.out.println("Student id is not valid id. Please write 6 digits only for student id.");
							continue;
						}
						else
						{
							// checking if id exists by calling idexists method from student class
							if(student1.IdExists(studentList, id) == false)
							{
								System.out.println("Student with this id already exists. Please try again with different id");			
								continue;
							}
							// if both the criteria are approved then goes further else ends
							else
							{
								// setting new student name
								student1.setName(name);
								// setting new student id
								student1.setId(id);
								// adding new student details to array list
								studentList.add(student1.toString());
								// writes all the students details from array list to text file
								writeStudents(studentList);
								// asking user if want to add another student
								System.out.print("Student data added successfully. Do you want to add another student?(Y/N): ");
								String ans = (userInput.nextLine()).toUpperCase();
								// if user chooses yes then continues the whole process again
								if(ans.equals("Y"))
								{
									continue;
								}
								// if user says no then option 3 ends here and breaks the loop
								else
								{
									System.out.println("Thank You");
									cont = "N";
									break;
								}
							}	
						}
					}
				}	
			}
			// if user chose option 4 or any unknown option typed by user then program quits and breaks out of loop
			else
			{
				System.out.println("Thank you. Program ends here.");
				loop = false;
				break;
			}
		}
		
	}
	
	// creating write method to write data from array list to text file
	// it takes one arguments, array list with student details
	public static void writeStudents(ArrayList<String> studentList) throws IOException
	{
		// calling file writer method to open the file and write the data in it
		FileWriter writer = new FileWriter("students.txt");
		for(String str: studentList)
		{
			// writes each student details line by line with consistent formatting
			writer.write(str);
			writer.write("\n");
		}
		writer.close();
		
	}
	
}
