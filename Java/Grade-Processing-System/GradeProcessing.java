import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Font;
import javafx.scene.text.FontPosture;
import javafx.scene.text.FontWeight;
import javafx.stage.Stage;

public class GradeProcessing extends Application {
	
	
	@Override
	public void start(Stage homeStage)
	{
		// creating grid pane with default properties
		GridPane gridPane = new GridPane();
        gridPane.setAlignment(Pos.CENTER);
        gridPane.setVgap(20);
        
        // setting choose option label with properties
        Label optionLabel = new Label("Choose one option");
        optionLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.BOLD, FontPosture.REGULAR, 22));
        
        // setting insert button and its properties
        Button insertButton = new Button("INSERT RECORD");
        insertButton.setAlignment(Pos.CENTER);
        insertButton.setMinWidth(200);
        insertButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        
        // setting search button and its properties
        Button searchButton = new Button("SEARCH RECORD");
        searchButton.setAlignment(Pos.CENTER);
        searchButton.setMinWidth(200);
        searchButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        
        // setting update button and its properties
        Button updateButton = new Button("UPDATE RECORD");
        updateButton.setAlignment(Pos.CENTER);
        updateButton.setMinWidth(200);
        updateButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
        
        // adding label and three buttons to grid pane
        gridPane.add(optionLabel,0,0);
        gridPane.add(insertButton,0,1);
        gridPane.add(searchButton,0,2);
        gridPane.add(updateButton,0,3);
        
        
        // event handler to handle the click event on all the buttons 
        EventHandler<ActionEvent> handler = e -> 
        { 
        	// gets insert button event
            if(e.getSource() == insertButton)
            { 
            	// calls insert stage
            	InsertData insert = new InsertData(); 
            	insert.start(homeStage);  
            }
            // gets search button event
            else if(e.getSource() == searchButton)
            { 
            	// calls search stage
            	SearchData search = new SearchData(); 
            	search.start(homeStage);  
            }
            // gets update button event
            else if(e.getSource() == updateButton)
            { 
            	// calls update stage
            	UpdateData update = new UpdateData(); 
            	update.start(homeStage);  
            }
        };
        // sets all buttons on action 
        insertButton.setOnAction(handler);
        searchButton.setOnAction(handler);
        updateButton.setOnAction(handler);
        
        // creating scene and adding grid pane to it
        Scene scene = new Scene(gridPane, 350, 250);
        homeStage.setTitle("Grade Processing System - Home");	
        homeStage.setScene(scene);	// adds scene to home stage
        homeStage.setResizable(false);
        homeStage.show();
	}
	
	public static void main(String[] args) 
	{
        launch(args);
	} 
}
