import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.StringTokenizer;
import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ScrollPane;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontPosture;
import javafx.scene.text.FontWeight;
import javafx.scene.text.TextAlignment;
import javafx.stage.Stage;

public class Client extends Application {
	// declaring input and output stream
	DataOutputStream toServer = null;
	DataInputStream fromServer = null;
	
	public void start(Stage stage) 
	{
		// creating flowpane to store all the components with default properties
		FlowPane flowpane = new FlowPane();
		flowpane.setAlignment(Pos.CENTER);
		flowpane.setPadding(new Insets(20,20,20,20));
		flowpane.setHgap(25);
        flowpane.setVgap(25);
        
		// creating vertical box with default properties
		VBox vbox = new VBox();
		vbox.setAlignment(Pos.CENTER);
		vbox.setPadding(new Insets(20,20,20,20));
		vbox.setSpacing(20);
		
		// creating scene with default properties and adding flowpane to it
		Scene scene = new Scene(flowpane, 550, 580);
        
		// creating heading label with default properties
		Label welcomeLabel = new Label("Chat Application");
		welcomeLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.BOLD, FontPosture.REGULAR, 22));
		
		// creating recipient name label with default properties
		Label clientNameLabel = new Label("Recipient Name \n(Client 1, Client 2....Client n)");
		clientNameLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.LIGHT, FontPosture.REGULAR, 15));
		clientNameLabel.setMinWidth(450);
		clientNameLabel.setTextAlignment(TextAlignment.LEFT);
		
		// creating textfield for recipient name
		TextField clientNameField = new TextField();
		clientNameField.setMinWidth(450);
		clientNameField.setPadding(new Insets(10,10,10,10));
		
		// creating conversation label 
		Label conversationLabel = new Label("Conversation");
		conversationLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.LIGHT, FontPosture.REGULAR, 15));
		conversationLabel.setMinWidth(450);
		conversationLabel.setTextAlignment(TextAlignment.LEFT);
		
		// creating text area to display all the conversation details and is kept not editable
		TextArea chatBox = new TextArea();
		chatBox.setMinWidth(400);
		chatBox.setPadding(new Insets(10,10,10,10));
		chatBox.setEditable(false);
		
		// creating scroll pane to set text area in it
		ScrollPane container = new ScrollPane();
		container.setMaxWidth(450);
		container.setContent(chatBox);
		
		// creating horizontal box to set components
		HBox hbox = new HBox();
		hbox.setAlignment(Pos.CENTER);
		hbox.setSpacing(20);
		hbox.minWidth(450);
		
		// creating message label
		Label chatMessageLabel = new Label("Message");
		chatMessageLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.LIGHT, FontPosture.REGULAR, 15));
		chatMessageLabel.setMinWidth(450);
		chatMessageLabel.setTextAlignment(TextAlignment.LEFT);
		
		// creating message text field with default properties
		TextField chatMessageField = new TextField();
		chatMessageField.setMinWidth(350);
		chatMessageField.setPadding(new Insets(10,10,10,10));
		
		// setting insert and back button
        Button sendButton = new Button("Send");
        sendButton.setMinWidth(80);
        sendButton.setPadding(new Insets(10,10,10,10));
        sendButton.setStyle(
        		"-fx-background-color: linear-gradient(#61a2b1, #2A5058);" +
        		"-fx-background-radius: 30;" +
        		"-fx-background-insets: 0;"+
        		"-fx-text-fill: white;"+
        		"-fx-effect: dropshadow( three-pass-box , rgba(0,0,0,0.6) , 5, 0.0 , 0 , 1 );"
        		);
	
		// using try catch block to connect to the server and creating input and out data stream
        try 
        {
        	// Create a socket to connect to the server
        	Socket socket = new Socket("localhost", 8000);
        	
        	// Create an input stream to receive data from the server
        	fromServer = new DataInputStream(socket.getInputStream());
	
        	// Create an output stream to send data to the server
        	toServer = new DataOutputStream(socket.getOutputStream());
        }
        catch (IOException ex) 
        {
			// writes error message in text area
        	chatBox.appendText(ex.toString() + '\n');
        }
        
        // adding event handler to send button to send message to server 
        sendButton.setOnAction(e -> 
        {
			// using try catch block to handle error while writing message
        	try
        	{
				// adds text message to text area
        		chatBox.appendText(chatMessageField.getText() + "\n");
	      		// Send message to the server and clears the field
	       		toServer.writeUTF(chatMessageField.getText() + "#" + clientNameField.getText());
	            toServer.flush();
	            chatMessageField.clear();
	        }
	        catch (IOException ex) 
	        {
	        	System.err.println(ex);
	        }        
        });
	
        // creating read message thread 
        Thread readMessage = new Thread(new Runnable()  
        { 
            @Override
            public void run() 
			{ 
                while (true) 
				{ 
                    try 
					{ 
                    	 // reads message sent to this client 
                		String message = fromServer.readUTF();
						// separates message from # to separate message and client name
                    	StringTokenizer stringTokenizer = new StringTokenizer(message, "#"); 
    		            if(stringTokenizer.hasMoreTokens())
    		            {
							// stores message and client name in variables
    		                String messageReceived = stringTokenizer.nextToken(); 
    		                String recipient = stringTokenizer.nextToken(); 
    					    chatBox.appendText(recipient + " : " + messageReceived + '\n');
    		            }
                    } 
					catch (IOException e) 
					{ 
                        e.printStackTrace(); 
                    } 
                } 
            } 
        }); 
        readMessage.start(); 
        
		// adds message text field and send button to hbox
        hbox.getChildren().add(chatMessageField);
        hbox.getChildren().add(sendButton);
     
		// adding all the components to flowpane
        flowpane.getChildren().add(welcomeLabel);
        flowpane.getChildren().add(clientNameLabel);
        flowpane.getChildren().add(clientNameField);
        flowpane.getChildren().add(conversationLabel);
        flowpane.getChildren().add(container);
        flowpane.getChildren().add(chatMessageLabel);
        flowpane.getChildren().add(hbox);
     
		// setting scene to stage with default properties
        stage.setTitle("Chat Application");
        stage.setScene(scene);	// adding scene to insert stage
        stage.setResizable(false);
        stage.show();
	}
	
	public static void main(String[] args) 
	{	
		launch(args);
	}

}
