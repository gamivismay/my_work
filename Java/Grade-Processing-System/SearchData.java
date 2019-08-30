import javafx.application.Application;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.FlowPane;
import javafx.stage.Stage;
import java.sql.*;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.HBox;

public class SearchData extends Application {
	
	// declaring obserevable arraylist to hold the student data
    private final ObservableList<Student> studentRecords =	FXCollections.observableArrayList();
 
    // initializing database variables
 	Connection connection = null;
    String DATABASE_NAME = "students_records";
    String DATABASE_CONNECTION_STRING = "jdbc:mysql://localhost:3306/" + DATABASE_NAME + "?autoReconnect=true&useSSL=false";
	String CONNECTION_ACCOUNT = "root";
    String CONNECTION_PASSWORD = "root";
    String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
    
    @SuppressWarnings({ "rawtypes", "unchecked" })
	@Override
    public void start(Stage searchStage) {
     
        // creating flow pane with default properties
        FlowPane flowPane = new FlowPane();
        flowPane.setAlignment(Pos.CENTER);
        flowPane.setHgap(25);
        flowPane.setVgap(25);

        // creating scene amnd adding flow pane to it
    	Scene scene = new Scene(flowPane, 800, 500);
        
        // creating horizontal box with default properties
        HBox hbox = new HBox();
        hbox.setSpacing(10);
        
        // creating welcome label
        Label welcomeLabel = new Label("Search Item: (ID, Name, Marks, Grade)");
        
        // creating search text field
        TextField searchText = new TextField();
        searchText.setMaxWidth(100);
        
        // creating search button text field
        Button searchButton = new Button("SEARCH");
        searchButton.setMinWidth(100);
        searchButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        
        // creating back button
        Button backButton = new Button("BACK");
        backButton.setMinWidth(100); 
        backButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        
        // adding all components to hbox
        hbox.getChildren().add(welcomeLabel);
        hbox.getChildren().add(searchText);
        hbox.getChildren().add(searchButton);
        hbox.getChildren().add(backButton);
        
        // creating table view and setting its default properties with respect to scene
        TableView tableView = new TableView();
        tableView.setEditable(false);
        tableView.setMaxWidth(scene.getWidth()-50);
        tableView.setMaxHeight(scene.getHeight()-hbox.getHeight()-50);
        
        // creating student id column with default properties 
        TableColumn studentIdColumn = new TableColumn("Student ID");
        studentIdColumn.setMinWidth(100);
        
        // creating student name column with default properties 
        TableColumn studentNameColumn = new TableColumn("Student Name");
        studentNameColumn.setMinWidth(80);
        
        // creating quiz marks column with default properties
        TableColumn quizMarksColumn = new TableColumn("Quiz");
        quizMarksColumn.setMinWidth(80);
        
        // creating assignment 1 marks column with default properties
        TableColumn assignment1MarksColumn = new TableColumn("A1");
        assignment1MarksColumn.setMinWidth(75);
        
        // creating assignment 2 marks column with default properties
        TableColumn assignment2MarksColumn = new TableColumn("A2");
        assignment2MarksColumn.setMinWidth(75);
        
        // creating assignment 3 column with default properties
        TableColumn assignment3MarksColumn = new TableColumn("A3");
        assignment3MarksColumn.setMinWidth(75);
        
        // creating exam marks column with default properties
        TableColumn examMarksColumn = new TableColumn("Exam");
        examMarksColumn.setMinWidth(80);
        
        // creating result column with default properties
        TableColumn resultColumn = new TableColumn("Results");
        resultColumn.setMinWidth(80);
        
        // creating grade column with default properties
        TableColumn gradeColumn = new TableColumn("Grade");
        gradeColumn.setMinWidth(80);
        
        // assigning column values
        studentIdColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("studentId"));
        studentNameColumn.setCellValueFactory(new PropertyValueFactory<Student,String>("studentName"));
        quizMarksColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("quizMarks"));
        assignment1MarksColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("assignment1Marks"));
        assignment2MarksColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("assignment2Marks"));
        assignment3MarksColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("assignment3Marks"));
        examMarksColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("examMarks"));
        resultColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("result"));
        gradeColumn.setCellValueFactory(new PropertyValueFactory<Student, String>("grade"));
        
        // adding all the columns to the table view
        tableView.getColumns().addAll(studentNameColumn,studentIdColumn,quizMarksColumn,assignment1MarksColumn,assignment2MarksColumn,assignment3MarksColumn,examMarksColumn,resultColumn,gradeColumn);
        tableView.setItems(studentRecords);
        
        // setting event handler to search button
        searchButton.setOnAction((event) -> 
        {
            // clearing student records
        	studentRecords.clear();
        
        	// getting search id value
        	String searchItem = searchText.getText();
        	String query="";
        
        	// getting data from database according to search id 
        	try
        	{
        		Class.forName(JDBC_DRIVER);
        		connection = DriverManager.getConnection(DATABASE_CONNECTION_STRING, CONNECTION_ACCOUNT, CONNECTION_PASSWORD);
        		PreparedStatement preparedStatement = null;
        
        		// checks if search term is alphabetical and searches based on name and grade
        		if(searchItem.matches("[a-zA-Z]+"))  
        		{
        			// getting data from database based on condition
        			query = "SELECT * FROM java2 WHERE StudentName=? or Grade=?";
        			preparedStatement = connection.prepareStatement(query);
        			preparedStatement.setString(1,searchItem);
        			preparedStatement.setString(2,searchItem);
        		}            
        		// checks if search term is numerical with 8 digits length and searches based on id
        		else if(searchItem.matches("[0-9]+") && searchItem.length()==8)  
        		{
        			// getting data from database based on condition
        			query = "SELECT * FROM java2 WHERE ID=?";
        			preparedStatement = connection.prepareStatement(query);
        			preparedStatement.setLong(1,Long.parseLong(searchItem));
        		}
        		// checks if search term is numerical with any length and searcher based on marks
        		else if(searchItem.matches("[-+]?([0-9]*\\.[0-9]+|[0-9]+)"))
        		{
        			// checks if marks are between 0 and 100
        			if(Double.parseDouble(searchItem)>=0 || Double.parseDouble(searchItem)<=100) 
        			{
            			// getting data from database based on condition
        				query = "SELECT * FROM java2 WHERE Quiz=? or A1=? or A2=? or A3=? or Exam=? or Results=?";
        				preparedStatement = connection.prepareStatement(query);
        				preparedStatement.setDouble(1,Double.parseDouble(searchItem));
        				preparedStatement.setDouble(2,Double.parseDouble(searchItem));
        				preparedStatement.setDouble(3,Double.parseDouble(searchItem));
        				preparedStatement.setDouble(4,Double.parseDouble(searchItem));
        				preparedStatement.setDouble(5,Double.parseDouble(searchItem));
        				preparedStatement.setDouble(6,Double.parseDouble(searchItem));
        			} 
        		}
        		// gives input error otherwise
        		else 
        		{
        			Alert alert = new Alert(Alert.AlertType.ERROR);
        			alert.setTitle("INPUT ERROR");
        			alert.setHeaderText(null);
       				alert.setContentText("Invalid Value! Please Try Again");
       				alert.showAndWait();
       				searchText.setText(""); 
       			}
        		
        		// executing query
        		ResultSet resultSet = preparedStatement.executeQuery();
        		// using while loop to iterate through the records 
        		while(resultSet.next()) 
        		{
        			// getting values from records and adding it to 
        			long studentId = Long.parseLong(resultSet.getString(1));
        		    String studentName = resultSet.getString(2);
        		    double quizMarks = Double.parseDouble(resultSet.getString(3));
        		    double assignment1Marks = Double.parseDouble(resultSet.getString(4));
        		    double assignment2Marks = Double.parseDouble(resultSet.getString(5));
        		    double assignment3Marks = Double.parseDouble(resultSet.getString(6));
        		    double examMarks = Double.parseDouble(resultSet.getString(7));
        		    double result = Double.parseDouble(resultSet.getString(8));
        		    String grade = resultSet.getString(9);
        		    
        			// creates student object and add to student records list
        			Student student = new Student(studentId, studentName, quizMarks, assignment1Marks, assignment2Marks, assignment3Marks, examMarks, result, grade);
            		studentRecords.add(student);
            	}  
        		connection.close();       
        	}  
        	catch(Exception ex)
        	{ 
        		ex.printStackTrace(); 
        	}
        });  //Closing of Search Button Event
        
        // setting event handler for back button
        backButton.setOnAction((event) -> 
        {
            GradeProcessing home = new GradeProcessing();
            home.start(searchStage);
        });  
        
        // adding hbox and table to flowpane
        flowPane.getChildren().add(hbox);
        flowPane.getChildren().add(tableView);
        
        // setting stage
        searchStage.setTitle("Grade Processing System - Search Record");
        searchStage.setScene(scene);	// adding scene to search stage
        searchStage.setResizable(false);
        searchStage.show(); 
    }  
}
