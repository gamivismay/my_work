public class Student {
	
	// declaring default variables
	private String studentName;
    private long studentId;
    private double quizMarks;
    private double assignment1Marks;
    private double assignment2Marks;
    private double assignment3Marks;
    private double examMarks;
    private double result;
    private String grade;

    // declaring constructor with arguments
    public Student(long studentId,String studentName, double quizMarks, double assignment1Marks, double assignment2Marks, double assignment3Marks,double examMarks,double result, String grade) 
    {
        this.studentName = studentName;
        this.studentId = studentId;
        this.quizMarks = quizMarks;
        this.assignment1Marks = assignment1Marks;
        this.assignment2Marks = assignment2Marks;
        this.assignment3Marks = assignment3Marks;
        this.examMarks = examMarks;
        this.result = result;
        this.grade = grade;
    }
     
    // get method to get student name
    public String getStudentName() {
        return studentName;
    }
     
    // get method to get student id
    public long getStudentId() {
        return studentId;
    }
    
    // get method to get quiz marks
    public double getQuizMarks() {
        return quizMarks;
    }
    
    // get method to get assignment 1 marks
    public double getAssignment1Marks() {
        return assignment1Marks;
    }

    // get method to get assignment 2 marks
    public double getAssignment2Marks() {
        return assignment2Marks;
    }
    
    // get method to get assignment 3 marks
    public double getAssignment3Marks() {
        return assignment3Marks;
    }
    
    // get method to get exam marks
    public double getExamMarks() {
        return examMarks;
    }
    
    // get method to get result
    public double getResult() {
        return result;
    }
    
    // get method to get grade
    public String getGrade() {
        return grade;
    }
}
