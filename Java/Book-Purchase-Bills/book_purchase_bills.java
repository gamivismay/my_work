import java.util.*;

public class book_purchase_bills {
	
	public static void main(String[] args)
	{
		// DECLARING ALL THE NECESSARY VARIABLES
		int largeHardBookPrice = 0;
		int smallHardBookPrice = 0;
		int softCoverBookPrice = 0;
		int totalBill = 0;
		int finalTotalBill = 0;
		String continueBill = "y";
		
		// PRINTS OUT WELCOME MESSAGE AND BEGINS THE BILL CALCULATION
		System.out.println("Welcome to the annual book festival!");
		System.out.println();
		
		// METHOD TO TAKE INPUT FROM USER KEYBOARD
		Scanner userInput = new Scanner(System.in);
		
		// WHILE LOOP TO CONTINUE BILLING PROCESS IF UESER WANTS TO CALCULATE ANOTHER BILL
		while(!continueBill.equals("n") && continueBill.equals("y"))
		{
			// TAKES USER INPUT FOR LARGE HARDBACK BOOKS
			System.out.print("Enter the number of large print hardback books purchased: ");
			int largeHardBookQuantity = userInput.nextInt();

			// TAKES USER INPUT FOR SMALL HARDBACK BOOKS
			System.out.print("Enter the number of small print hardback books purchased: ");
			int smallHardBookQuantity = userInput.nextInt();
				
			// TAKES USER INPUT FOR SOFTCOVER BOOKS
			System.out.print("Enter the number of softcover books purchased: ");
			int softCoverBookQuantity = userInput.nextInt();
				
			// DECLARING NECESSARY VARIABLE REQUIRED FOR CALCULATION
			int largeHardBookCount = 0;
			int largeHardBookThreePair = 0;
			int smallHardBookCount = 0;
			int smallHardBookTwoPair = 0;
			int softCoverBookCount = 0;
			int softCoverBookFivePair = 0;
			
			// FOR LOOP TO CALCULATE BILL AMOUNT FOR LARGE HARDBACK BOOKS
			{
				for(int i = largeHardBookQuantity; i > 0; i--)
				{
					if(i%3 == 0)
					{
						largeHardBookThreePair = i / 3;
						break;
					}
					else if(i%3 != 0)
					{
						largeHardBookCount++;
					}
				}
			
				largeHardBookPrice = (largeHardBookThreePair * 20) + (largeHardBookCount * 10);		
			}
			
			// FOR LOOP TO CALCULATE BILL AMOUNT FOR SMALL HARDBACK BOOKS
			{
				for(int i = smallHardBookQuantity; i > 0; i--)
				{
					if(i%2 == 0)
					{
						smallHardBookTwoPair = i / 2;
						break;
					}
					else if(i%2 != 0)
					{
						smallHardBookCount++;
					}
				}
				
				smallHardBookPrice = (smallHardBookTwoPair * 10) + (smallHardBookCount * 7);		
			}
			
			// FOR LOOP TO CALCULATE BILL AMOUNT FOR SOFTCOVER BOOKS
			{
				for(int i = softCoverBookQuantity; i > 0; i--)
				{
					if(i%5 == 0)
					{
						softCoverBookFivePair = i / 5;
						break;
					}
					else if(i%5 != 0)
					{
						softCoverBookCount++;
					}
				}
				
				softCoverBookPrice = (softCoverBookFivePair * 15) + (softCoverBookCount * 5);		
			}
			
				// CALCULATES TOTAL BILL IN THIS SESSION
				totalBill = largeHardBookPrice + smallHardBookPrice + softCoverBookPrice;
				System.out.println("Your total bill is: " + totalBill);
				System.out.println();
				
				// ASKS USER IF NEED TO CALCULATE ANOTHER BILL
				System.out.print("Would you like to calculate another bill (y/n)? ");
				continueBill = userInput.next();
				System.out.println();
				
				// CALCULATES TOTAL BILL IN ALL SESSIONS
				finalTotalBill = finalTotalBill + totalBill;
			}
			
			userInput.close();
			
			// END OF PROGRAM WITH DISPLAY OF FINAL BILL AND GOODBYE MESSAGE
			System.out.println("Total Sales in this session: " + "$" + finalTotalBill);
			System.out.println();
			System.out.println("Goodbye!");
	}

}
