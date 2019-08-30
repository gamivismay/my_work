public class TaxRates {

	// declaring all the variables that relates to important factors needed for tax calculation
	private double incomeSlab;
	private double fixedAmount;
	private double fixedRate;
	
	
	// constructor of the class
	public TaxRates()
	{
		
	}
	
	
	// get method to get income slab value
	public double getIncomeSlab()
	{
		return incomeSlab;
	}
	
	
	// set method to set income slab value to new value
	public void setIncomeSlab(double newIncomeSlab)
	{
		incomeSlab = newIncomeSlab;
	}
	
	
	// get method to get fixed amount value
	public double getFixedAmount()
	{
		return fixedAmount;
	}
	
	
	// set method to set fixed amount value to new value
	public void setFixedAmount(double newFixedAmount)
	{
		fixedAmount = newFixedAmount;
	}
	
	
	// get method to get fixed rate value
	public double getFixedRate()
	{
		return fixedRate;
	}
	
	
	// set method to set fixed rate value to new value
	public void setFixedRate(double newFixedRate)
	{
		fixedRate = newFixedRate;
	}	
}
