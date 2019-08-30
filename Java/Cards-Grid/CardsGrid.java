import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import java.util.*;
import javafx.application.Application;
import javafx.stage.Stage;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.Scene;


public class CardsGrid extends Application {
	
	// overriding the start method in application class
	@Override
	public void start(Stage primaryStage)
	{
		// creating array list of 52 cards 
		ArrayList<Integer> cardList = new ArrayList<Integer>();
		for (int i = 1; i <= 52; i++)
		{
			cardList.add(i);
		}
		
		// shuffling all the numbers in array list
		Collections.shuffle(cardList);
		
		// creating horizontal pane and align in the center
		HBox hPane = new HBox(15);
		hPane.setPadding(new Insets(15,15,15,15));
		hPane.setAlignment(Pos.CENTER);
		
		// creating the first card image and add to horizontal pane in first row
		Image card1 = new Image("file:cards\\" + cardList.get(0) + ".png");
		ImageView cardView1 = new ImageView(card1);
		hPane.getChildren().add(cardView1);

		// creating the second card image and add to horizontal pane in first row
		Image card2 = new Image("file:cards\\" + cardList.get(1) + ".png");
		ImageView cardView2 = new ImageView(card2);
		hPane.getChildren().add(cardView2);
		
		// creating the third card image and add to horizontal pane in first row
		Image card3 = new Image("file:cards\\" + cardList.get(2) + ".png");
		ImageView cardView3 = new ImageView(card3);
		hPane.getChildren().add(cardView3);
		
		// creating vertical pane and align in the center
		VBox vPane = new VBox(15);
		vPane.setAlignment(Pos.CENTER);
		
		// creating the first joker image and add to vertical pane in second row with 45 degree rotation
		Image joker1 = new Image("file:cards\\joker1.png");
		ImageView jokerView1 = new ImageView(joker1);
		jokerView1.setRotate(45);
		vPane.getChildren().add(jokerView1);
		
		// creating the second joker image and add to vertical pane in third row at 90 degree rotation	
		Image joker2 = new Image("file:cards\\joker2.png");
		ImageView jokerView2 = new ImageView(joker2);
		jokerView2.setRotate(90);
		vPane.getChildren().add(jokerView2);
		
		// creating border pane and setting up top with horizontal pane having one row with three cards
		// and bottom with vertical pane having two rows with one card each
		BorderPane pane = new BorderPane();
		pane.setTop(hPane);
		pane.setBottom(vPane);
		
		// creating a scene and place it in stage
		Scene scene = new Scene(pane);
		primaryStage.setTitle("Cards in a Grid");
		primaryStage.setScene(scene);
		primaryStage.show();
		
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		launch(args);
	}

}
