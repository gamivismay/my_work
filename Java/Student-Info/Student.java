import java.util.ArrayList;

public class Student {
	
	// declaring data fields to store student name and student id
	String studentName;
	String studentId;
	
	// declaring no-arg/default constructor
	public Student()
	{
		
	}
	
	// creating get method to get student name
	public String getName()
	{
		return studentName;
	}
	
	// creating set method to change student name
	public void setName(String newStudentName)
	{
		studentName = newStudentName;
	}
	
	// creating get method to get student id
	public String getId()
	{
		return studentId;
	}

	// creating set method to change student id
	public void setId(String newId)
	{
		studentId = newId;
	}
	
	// creating a method to represents string format of student id with student name
	public String toString()
	{
		String newStudentId = getId();
		String newStudentName = getName();
		return newStudentId + " " + newStudentName;
	}
	
	// creating method to validate student id input by user that should contain exact 6 digits in string format
	public boolean isValidId(String newId)
	{
		// checking if student id is exact 6 digits
		if (newId.length() == 6 && newId.matches("[0-9]+"))
		{
			return true;
		}	
		else
		{
			return false;
		}
	}
	
	// creating method to check if student id input by user, already exists in text file or not
	// this method takes two arguments, array list that contains student details and student id given by user
	public boolean IdExists(ArrayList<String> studentList, String id)
	{
		// using for loop in each student data in array list to match the id 
		for(String str:studentList)
		{
			if(str.contains(id))
			{
				return false;
			}
		}
		return true;
	}

}
