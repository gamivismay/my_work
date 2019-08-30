import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Font;
import javafx.scene.text.FontPosture;
import javafx.scene.text.FontWeight;
import javafx.stage.Stage;
import java.sql.*;


public class InsertData extends Application {

	// initializing default database variables
    Connection connection = null;
    Statement statement = null;
    String DATABASE_NAME = "students_records";
    String TEST_CONNECTION_STRING = "jdbc:mysql://localhost:3306/?autoReconnect=true&useSSL=false";
    String DATABASE_CONNECTION_STRING = "jdbc:mysql://localhost:3306/" + DATABASE_NAME + "?autoReconnect=true&useSSL=false";
	String CONNECTION_ACCOUNT = "root";
    String CONNECTION_PASSWORD = "root";
    String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
    		
	public void start(Stage insertStage)
	{
		// creating flow pane with default properties
        FlowPane flowPane = new FlowPane();
        flowPane.setAlignment(Pos.CENTER);
        flowPane.setHgap(25);
        flowPane.setVgap(25);
        
        // creating grid pane with default Properties
        GridPane gridPane = new GridPane();
        gridPane.setPadding(new Insets(5,5,5,5));
        gridPane.setHgap(30);
        gridPane.setVgap(20);
        
        // setting choose option label with properties
        Label welcomeLabel = new Label("Enter student details");
        welcomeLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.BOLD, FontPosture.REGULAR, 22));
        
        // setting student id label and text field with default properties       
        Label studentIdLabel = new Label("Student ID (must be 8 digits)");
        TextField studentIdText = new TextField();
        
        // setting student name label and text field with default properties
        Label studentNameLabel = new Label("Student Name");
        TextField studentNameText = new TextField();

        // setting student quiz marks label and text field with default properties
        Label quizMarksLabel = new Label("Quiz Marks (Enter 0-100)");
        TextField quizMarksText = new TextField();
        
        // setting student assignment1 marks label and text field with default properties
        Label assignment1MarksLabel = new Label("Assignment1 Marks (Enter 0-100)");
        TextField assignment1MarksText = new TextField();
        
        // setting student assignment2 marks label and text field with default properties
        Label assignment2MarksLabel = new Label("Assignment2 Marks (Enter 0-100)");
        TextField assignment2MarksText = new TextField();
        
        // setting student assignment3 marks label and text field with default properties
        Label assignment3MarksLabel = new Label("Assignment3 Marks (Enter 0-100)");
        TextField assignment3MarksText = new TextField();
        
        // setting student Exam marks label and text field with default properties
        Label examMarksLabel = new Label("Exam Marks (Enter 0-100)");
        TextField examMarksText = new TextField();
        
        // adding all labels and text fields into grid pane
        gridPane.add(welcomeLabel,0,0);
        gridPane.add(studentIdLabel,0,1);
        gridPane.add(studentNameLabel,0,2);
        gridPane.add(quizMarksLabel,0,3);
        gridPane.add(assignment1MarksLabel,0,4);
        gridPane.add(assignment2MarksLabel,0,5);
        gridPane.add(assignment3MarksLabel,0,6);
        gridPane.add(examMarksLabel,0,7);
        gridPane.add(studentIdText,1,1);
        gridPane.add(studentNameText,1,2);
        gridPane.add(quizMarksText,1,3);
        gridPane.add(assignment1MarksText,1,4);
        gridPane.add(assignment2MarksText,1,5);
        gridPane.add(assignment3MarksText,1,6);
        gridPane.add(examMarksText,1,7);
        
        
        // setting insert and back button
        Button insertButton = new Button("INSERT");
        insertButton.setMinWidth(100);
        insertButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        Button backButton = new Button("BACK");
        backButton.setMinWidth(100);
        backButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        
        // setting event handler for insert button
        insertButton.setOnAction((event) -> 
        {
        	// initializing necessary variables to store user input data
            long studentId = 0;
            String studentName = ""; 
            String grade = "";
            double quizMarks = 0;
            double assignmennt1Marks = 0;
            double assignmennt2Marks = 0;
            double assignmennt3Marks = 0;
            double examMarks = 0;
            double result = 0;
            
            // using try catch to handle any error or invalid inputs
            try 
            {
                // getting values from text fields and converting in appropriate format
                studentId = Integer.parseInt(studentIdText.getText());
                studentName = studentNameText.getText();
                quizMarks = Double.parseDouble(quizMarksText.getText());
                assignmennt1Marks = Double.parseDouble(assignment1MarksText.getText());
                assignmennt2Marks = Double.parseDouble(assignment2MarksText.getText());
                assignmennt3Marks = Double.parseDouble(assignment3MarksText.getText());
                examMarks = Double.parseDouble(examMarksText.getText());
                
                // validating each input values
                if(studentIdText.getText().length()!=8)
                {
                    throw new Exception("ID");
                }
                else if(quizMarks < 0 || quizMarks > 100)
                {
                    throw new Exception("Quiz Marks");
                }
                else if(assignmennt1Marks < 0 || assignmennt1Marks > 100)
                {
                    throw new Exception("Assignment1 Marks");
                }
                else if(assignmennt2Marks < 0 || assignmennt2Marks > 100)
                {
                    throw new Exception("Assignment2 Marks");
                }
                else if(assignmennt3Marks < 0 || assignmennt3Marks > 100)
                {
                    throw new Exception("Assignment3 Marks");
                }
                else if(examMarks < 0 || examMarks > 100)
                {
                    throw new Exception("Exam Marks");
                }
                
                // calculating total result  
                result =(quizMarks * 0.05) + (assignmennt1Marks * 0.15) + (assignmennt2Marks * 0.2) + (assignmennt3Marks * 0.10) + (examMarks * 0.5);
                result = Math.round(result*100)/100.00;
            
                // calculating Grades with conditions of grades
                if(result>=85)
                {
                    grade = "HD";
                }
                else if(result>=75 && result<85)
                {
                    grade = "DI";
                }
                else if(result>=65 && result<75)
                {
                    grade = "CR";
                }
                else if(result>=50 && result<65)
                {
                    grade = "PS";
                }
                else
                {
                    grade = "FL";
                }
                
                // using try catch to handle database error        
                try
                {
                	// Register JDBC driver
                	Class.forName(JDBC_DRIVER);

                	// opening a connection
                	System.out.println("Connecting to database...");
                	connection = DriverManager.getConnection(TEST_CONNECTION_STRING, CONNECTION_ACCOUNT, CONNECTION_PASSWORD);
      
                	// checking if Database already exists
                	String dataBaseName = DATABASE_NAME;
                	String catalogs = "";
                	ResultSet resultSet = null;
                	
                	if(connection != null) 
                	{
                		resultSet = connection.getMetaData().getCatalogs();
                	}
                	
                	while(resultSet.next()) 
                	{
                		catalogs = resultSet.getString(1);
                		if(dataBaseName.equals(catalogs))
                		{
                			break;
                		}
                		else
                		{
                			continue;
                		}
                	}  
                	
                	// if database is found
                	if(dataBaseName.equals(catalogs)) 
                	{
                		// uses database if it exists
                		System.out.println("Database Exists");
                		statement = connection.createStatement();
                		statement.executeUpdate("USE students_records");
                	}
                	else 
                	{
                		System.out.println("Database not found");
                		// creates a new database if it doesn't exists already
                		System.out.println("New Database is being created...");
                		statement = connection.createStatement();
                		statement.executeUpdate("CREATE DATABASE students_records");
                		statement.executeUpdate("USE students_records");
                		System.out.println("Database creation successful...");
          
                		// connects to database and creates a new table 
                		connection = DriverManager.getConnection(DATABASE_CONNECTION_STRING, CONNECTION_ACCOUNT, CONNECTION_PASSWORD);
                		statement.executeUpdate("CREATE TABLE Java2 ("
                				+ "ID INT(10) NOT NULL,"  
                				+ "StudentName VARCHAR(20)," 
                				+ "Quiz DOUBLE(8,2),"  
                				+ "A1 DOUBLE(8,2),"
                				+ "A2 DOUBLE(8,2),"
                				+ "A3 DOUBLE(8,2),"
                				+ "Exam DOUBLE(8,2),"
                				+ "Results DOUBLE(8,2),"
                				+ "Grade VARCHAR(20))"
                				);
                		System.out.println("Table Created");
                	}  
      
                	// inserting user input data into table 
                	PreparedStatement preparedStatement = connection.prepareStatement("insert into Java2 values(?,?,?,?,?,?,?,?,?)");
                	preparedStatement.setLong(1,studentId);
                	preparedStatement.setString(2,studentName);
                	preparedStatement.setDouble(3,quizMarks);
                	preparedStatement.setDouble(4,assignmennt1Marks);
                	preparedStatement.setDouble(5,assignmennt2Marks);
                	preparedStatement.setDouble(6,assignmennt3Marks);
                	preparedStatement.setDouble(7,examMarks);
                	preparedStatement.setDouble(8,result);
                	preparedStatement.setString(9,grade);
                	preparedStatement.executeUpdate();
                	connection.close();	// closes connection after inserting
                	
                	// dialog is displayed with student details
                	Alert alert = new Alert(Alert.AlertType.INFORMATION);
                    alert.setTitle("Student Record Inserted");
                    alert.setHeaderText(null);
                    alert.setContentText("Record Data is:\nID = "+studentId+
                			"\nStudent Name = "+studentName+
                			"\nQuiz Marks = "+quizMarks+
                			"\nAssignment1 Marks = "+assignmennt1Marks+
                			"\nAssignment2 Marks = "+assignmennt2Marks+
                			"\nAssignment3 Marks = "+assignmennt3Marks+
                			"\nExam Marks = "+examMarks+
                			"\nResult = "+result+
                			"\nGrade = "+grade );
                    alert.showAndWait();
                }  
                catch(Exception ex) 
                { 
                	ex.printStackTrace(); 
                }
            }  
            
            // catches exceptions
            catch (NumberFormatException e) 
            {
            	Alert alert = new Alert(Alert.AlertType.ERROR);
                alert.setTitle("INPUT ERROR");
                alert.setHeaderText(null);
                alert.setContentText("Invalid Inputs! Please Try Again");
                alert.showAndWait();
            }
            catch(Exception ex)
            { 
            	Alert alert = new Alert(Alert.AlertType.ERROR);
                alert.setTitle("INPUT ERROR");
                alert.setHeaderText(null);
                alert.setContentText("Invalid "+ex.getMessage()+". Please Try Again");
                alert.showAndWait();
            }
                
            // clearing all the text fields
            studentIdText.setText("");
            studentNameText.setText("");
            quizMarksText.setText("");
            assignment1MarksText.setText("");
            assignment2MarksText.setText("");
            assignment3MarksText.setText("");
            examMarksText.setText("");
        });  
        
        // setting event handler for back button
        backButton.setOnAction((event) -> 
        {
        	GradeProcessing home = new GradeProcessing();
        	home.start(insertStage);
        });  
        
        // adding grid pane and two buttons to flow pane
        flowPane.getChildren().add(gridPane);
        flowPane.getChildren().add(insertButton);
        flowPane.getChildren().add(backButton);
        
        // creating scene and adding flow pane to it
        Scene scene = new Scene(flowPane, 500, 470);
        insertStage.setTitle("Grade Processing System - Insert Record");
        insertStage.setScene(scene);	// adding scene to insert stage
        insertStage.setResizable(false);
        insertStage.show();
	}
}