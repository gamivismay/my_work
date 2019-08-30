import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Font;
import javafx.scene.text.FontPosture;
import javafx.scene.text.FontWeight;
import javafx.stage.Stage;
import java.sql.*;


public class UpdateData extends Application {
	
	// initializing database variables
	Connection connection = null;
    Statement statement = null;
    String DATABASE_NAME = "students_records";
    String DATABASE_CONNECTION_STRING = "jdbc:mysql://localhost:3306/" + DATABASE_NAME + "?autoReconnect=true&useSSL=false";
	String CONNECTION_ACCOUNT = "root";
    String CONNECTION_PASSWORD = "root";
    String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";

	// initializing default variables
    long studentId = 0;
    String studentName = "";
    String grade = "";
    double quizMarks = 0;
    double assignment1Marks = 0;
    double assignment2Marks = 0;
    double assignment3Marks = 0;
    double examMarks = 0;
    double result = 0;
    
    @Override
    public void start(Stage updateStage) {
     
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
        Label welcomeLabel = new Label("Update student details");
        welcomeLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.BOLD, FontPosture.REGULAR, 22));
        
        // setting student id label and text field with default properties       
        Label studentIdLabel = new Label("Student ID (must be 8 digits)");
        ComboBox<String> studentIdCheck = new ComboBox<String>();
        studentIdCheck.setEditable(false);  // to set ID value fixed
        studentIdCheck.setMinWidth(150);
        
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
        gridPane.add(studentIdCheck,1,1);
        gridPane.add(studentNameText,1,2);
        gridPane.add(quizMarksText,1,3);
        gridPane.add(assignment1MarksText,1,4);
        gridPane.add(assignment2MarksText,1,5);
        gridPane.add(assignment3MarksText,1,6);
        gridPane.add(examMarksText,1,7);
        
        // setting insert and back button
        Button updateButton = new Button("UPDATE");
        updateButton.setMinWidth(100);
        updateButton.setStyle(
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
        
        // getting id data from database and setting to combo box 
        try
        {
        	Class.forName(JDBC_DRIVER);
        	connection=DriverManager.getConnection(DATABASE_CONNECTION_STRING, CONNECTION_ACCOUNT, CONNECTION_PASSWORD);
        	PreparedStatement preparedStatement = connection.prepareStatement("select * from java2");
        	ResultSet resultSet = preparedStatement.executeQuery();
        	while(resultSet.next())
        	{  
        		studentIdCheck.getItems().add((resultSet.getString(1))); 
        	}
        	connection.close();
        }  
        catch(Exception ex)
        { 
        	System.out.println("ex = "+ex); 
        }
        
        // setting event handler to combo box to retrieve data according to id selected
        studentIdCheck.setOnAction(e ->  
        {
        	studentId = Integer.parseInt(studentIdCheck.getValue().toString());
            try
        	{
        		Class.forName(JDBC_DRIVER);
        		connection=DriverManager.getConnection(DATABASE_CONNECTION_STRING, CONNECTION_ACCOUNT, CONNECTION_PASSWORD);
        		PreparedStatement preparedStatement = connection.prepareStatement("select * from java2 where ID=?");
        		preparedStatement.setLong(1,studentId);
        		ResultSet resultSet = preparedStatement.executeQuery();
        		// getting all the data according to id and storing in respective text fields.
        		while(resultSet.next())
        		{
        			studentNameText.setText(resultSet.getString(2));
        			quizMarksText.setText(resultSet.getString(3));
        			assignment1MarksText.setText(resultSet.getString(4));
        			assignment2MarksText.setText(resultSet.getString(5));
        			assignment3MarksText.setText(resultSet.getString(6));
        			examMarksText.setText(resultSet.getString(7));
        		}  
        		connection.close();
        	}  
        	catch(Exception ex)
        	{ 
        		System.out.println("ex = "+ex); 
        	}
        });  
        
        // setting event handler to update button to update the data
        updateButton.setOnAction((event) -> 
        {    
        	try 
            {
        		// getting values from text fields and converting in appropriate format
                studentName = studentNameText.getText();
                quizMarks = Double.parseDouble(quizMarksText.getText());
                assignment1Marks = Double.parseDouble(assignment1MarksText.getText());
                assignment2Marks = Double.parseDouble(assignment2MarksText.getText());
                assignment3Marks = Double.parseDouble(assignment3MarksText.getText());
                examMarks = Double.parseDouble(examMarksText.getText());
                
                // validating each input values
                if(quizMarks < 0 || quizMarks > 100)
                {
                    throw new Exception("Quiz Marks");
                }
                else if(assignment1Marks < 0 || assignment1Marks > 100)
                {
                    throw new Exception("Assignment1 Marks");
                }
                else if(assignment2Marks < 0 || assignment2Marks > 100)
                {
                    throw new Exception("Assignment2 Marks");
                }
                else if(assignment3Marks < 0 || assignment3Marks > 100)
                {
                    throw new Exception("Assignment3 Marks");
                }
                else if(examMarks < 0 || examMarks > 100)
                {
                    throw new Exception("Exam Marks");
                }
                
                // calculating total result    
                result =(quizMarks * 0.05) + (assignment1Marks * 0.15) + (assignment2Marks * 0.2) + (assignment3Marks * 0.10) + (examMarks * 0.5);
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
                	//Register JDBC driver
                	Class.forName(JDBC_DRIVER);

                	//Opening a connection
                	connection = DriverManager.getConnection(DATABASE_CONNECTION_STRING, CONNECTION_ACCOUNT, CONNECTION_PASSWORD);
                	statement = connection.createStatement();
                	statement.executeUpdate("USE students_records");
                
                	// updating data into Database table according to student id
                	PreparedStatement preparedStatement = connection.prepareStatement("update java2 set "
                			+ "studentName=?,"
                			+ "quiz=?,"
                			+ "A1=?,"
                			+ "A2=?,"
                			+ "A3=?,"
                			+ "Exam=?,Results=?,Grade=? where ID=?");
                	preparedStatement.setString(1,studentName);
                	preparedStatement.setDouble(2,quizMarks);
                	preparedStatement.setDouble(3,assignment1Marks);
                	preparedStatement.setDouble(4,assignment2Marks);
                	preparedStatement.setDouble(5,assignment3Marks);
                	preparedStatement.setDouble(6,examMarks);
                	preparedStatement.setDouble(7,result);
                	preparedStatement.setString(8,grade);
                	preparedStatement.setLong(9,studentId);
                	preparedStatement.executeUpdate();
                	connection.close();
                	
                	// dialog is displayed with updated student details
                	Alert alert = new Alert(Alert.AlertType.INFORMATION);
                    alert.setTitle("Student Record Updated");
                    alert.setHeaderText(null);
                    alert.setContentText("Record Data is:\nID = "+studentId+
                			"\nStudent Name = "+studentName+
                			"\nQuiz Marks = "+quizMarks+
                			"\nAssignment1 Marks = "+assignment1Marks+
                			"\nAssignment2 Marks = "+assignment2Marks+
                			"\nAssignment3 Marks = "+assignment3Marks+
                			"\nExam Marks = "+examMarks+
                			"\nResult = "+result+
                			"\nGrade = "+grade );
                    alert.showAndWait();
                }  
                catch (Exception ex) 
                { 
                	ex.printStackTrace(); 
                }
                
                // clearing all the text fields
                studentNameText.setText("");
                quizMarksText.setText("");
                assignment1MarksText.setText("");
                assignment2MarksText.setText("");
                assignment3MarksText.setText("");
                examMarksText.setText("");
                studentIdCheck.setValue("0");
            }  
            
        	// catches exceptions
            catch (NumberFormatException e) 
            { 
            	Alert alert = new Alert(Alert.AlertType.ERROR);
                alert.setTitle("INPUT ERROR");
                alert.setHeaderText(null);
                alert.setContentText("Invalid Inputs! Please Try Again");
                alert.showAndWait();
                studentNameText.setText("");
                quizMarksText.setText("");
                assignment1MarksText.setText("");
                assignment2MarksText.setText("");
                assignment3MarksText.setText("");
                examMarksText.setText("");
            }   
            catch(Exception ex)
            {
            	Alert alert = new Alert(Alert.AlertType.ERROR);
                alert.setTitle("INPUT ERROR");
                alert.setHeaderText(null);
                alert.setContentText("Invalid "+ex.getMessage()+". Please Try Again");
                alert.showAndWait();
                studentNameText.setText("");
                quizMarksText.setText("");
                assignment1MarksText.setText("");
                assignment2MarksText.setText("");
                assignment3MarksText.setText("");
                examMarksText.setText("");
            }
        });  
        
        // setting event handler for back button
        backButton.setOnAction((event) -> 
        {
            GradeProcessing home = new GradeProcessing();
            home.start(updateStage);
        });  
        
        // adding grid pane and two buttons to flow pane
        flowPane.getChildren().add(gridPane);
        flowPane.getChildren().add(updateButton);
        flowPane.getChildren().add(backButton);
        
        // creating scene and adding flow pane to it
        Scene scene = new Scene(flowPane, 500, 470);
        updateStage.setTitle("Grade Processing System - Update Record");
        updateStage.setScene(scene);	// adding scene to insert stage
        updateStage.setResizable(false);
        updateStage.show();
    }  
}
