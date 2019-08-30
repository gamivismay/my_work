import java.io.*;
import java.net.*;
import java.util.Date;
import java.util.StringTokenizer;
import java.util.Vector;
import javafx.application.Application;
import javafx.application.Platform;
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

public class Server extends Application {
	
	// creating text area to display all the messages
	TextArea textArea = new TextArea();
	
	// number of clients joined in conversation
	private int clientNo = 0;
	
	// Vector to store active clients 
    static Vector<HandleAClient> clientList = new Vector<>(); 
    
	@Override 
	public void start(Stage stage) 
	{
		// creating flowpane to store all the components
		FlowPane flowpane = new FlowPane();
		flowpane.setAlignment(Pos.CENTER);
		flowpane.setPadding(new Insets(20,20,20,20));
		flowpane.setHgap(25);
		flowpane.setVgap(25);
      
		// creating vertical box 
		VBox vbox = new VBox();
		vbox.setAlignment(Pos.CENTER);
		vbox.setPadding(new Insets(20,20,20,20));
		vbox.setSpacing(20);
		
		// creating scene and adding flowpane to it
		Scene scene = new Scene(flowpane, 600, 480);
      
		// creating heading label
		Label welcomeLabel = new Label("Server Application");
		welcomeLabel.setFont(Font.font(STYLESHEET_CASPIAN, FontWeight.BOLD, FontPosture.REGULAR, 22));
		
		// setting properties to text area
		textArea.setMinWidth(500);
		textArea.setMinHeight(350);
		textArea.setPadding(new Insets(10,10,10,10));
		textArea.setEditable(false);
		
		// creating scroll pane to store text area
		ScrollPane container = new ScrollPane();
		container.setMaxWidth(500);
		container.setMinHeight(350);
		container.setContent(textArea);
		
		// creates new thread for new connection
		new Thread( () -> 
		{
			try 
			{
				// Create a server socket
				ServerSocket serverSocket = new ServerSocket(8000);
				textArea.appendText("MultiThreadServer started at " + new Date() + '\n');
    
				while (true) 
				{
					// looks for a new connection request
					Socket socket = serverSocket.accept();
    
					// increase client number
					clientNo++;
					
					Platform.runLater( () -> 
					{
						// display thread to client status
						textArea.appendText("Assigning and Starting new thread for client " + clientNo + " at " + new Date() + '\n');
						
						// looks for client's host name, and IP address
						InetAddress inetAddress = socket.getInetAddress();
						textArea.appendText("Client " + clientNo + "'s host name is " + inetAddress.getHostName() + "\n");
						textArea.appendText("Client " + clientNo + "'s IP Address is " + inetAddress.getHostAddress() + "\n");
					});
          
					// Create data input and output streams
		            DataInputStream inputFromClient = new DataInputStream(socket.getInputStream());
		            DataOutputStream outputToClient = new DataOutputStream(socket.getOutputStream());
		            
					// Create and start a new thread for the connection
					HandleAClient handleAClient = new HandleAClient(socket, "Client " + clientNo, inputFromClient, outputToClient);
		            clientList.add(handleAClient);	// adds new client to client s list
		            new Thread(handleAClient).start();
				}
			}
			catch(IOException ex) 
			{
				System.err.println(ex);
			}
		}).start();
    
		// adds components to flowpane
		flowpane.getChildren().add(welcomeLabel);
		flowpane.getChildren().add(container);
		
		// sets scene in stage
		stage.setTitle("Server Application");
		stage.setScene(scene);	// adding scene to insert stage
		stage.setResizable(false);
		stage.show();
  	}
	
	
	// Define the thread class for handling new connection
	class HandleAClient implements Runnable 
	{
		// declaring default variables
		private Socket socket; 
		private String name; 
		DataInputStream inputFromClient; 
	    DataOutputStream outputToClient; 
	    
		// Construct a thread
		public HandleAClient(Socket socket, String name, DataInputStream inputFromClient, DataOutputStream outputToClient) 
		{
			this.socket = socket;
			this.name = name;
			this.inputFromClient = inputFromClient;
			this.outputToClient = outputToClient;
		}

		// Run a thread 
		public void run() 
		{
			try 
			{
				// using while loop to continuously serve the client
				while (true) 
				{
					// receive message from the client
					String received = inputFromClient.readUTF();
					
					// separates whole message from #
					StringTokenizer stringTokenizer = new StringTokenizer(received, "#"); 
		            if(stringTokenizer.hasMoreTokens())
		            {
						// stores message and client's name in variables
		                String messageToSend = stringTokenizer.nextToken(); 
		                String recipient = stringTokenizer.nextToken(); 
					
						// handles individual client from client's list
		                for (HandleAClient handler : Server.clientList)  
		                { 
		                	// if the recipient is found, write on its 
		                	// output stream 
		                	if (handler.name.equals(recipient))  
		                	{ 
								// writes message back to specific client
		                		handler.outputToClient.writeUTF(messageToSend+"#"+this.name); 
		                		break; 
		                	} 
		                }
		                Platform.runLater(() -> 
		                {
							// adds message to text area 
		                	textArea.appendText("Message received from " + this.name + " : " + messageToSend + '\n');
		                });
		            }
				}
			}
			catch(IOException ex) 
			{
				ex.printStackTrace();
			}	
		}
	}
  
	public static void main(String[] args) 
	{
		launch(args);
	}
}
