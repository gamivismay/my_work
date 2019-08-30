public class Employee {
	
	// declaring all the variables to store values for employee details
	private String employeeId;
	private double taxableIncome;
	private double taxAmount;
	
	// no args constuctor
	public Employee()
	{
		
	}

	// get method to get employee id
	public String getEmployeeId()
	{
		return employeeId;
	}
	
	// set method to set new employee id
	public void setEmployeeId(String newEmployeeId)
	{
		employeeId = newEmployeeId;
	}
	
	// get method to get taxable income
	public double getTaxableIncome()
	{
		return taxableIncome;
	}
	
	// set method to set new taxable income
	public void setTaxableIncome(double newTaxableIncome)
	{
		taxableIncome = newTaxableIncome;
	}
	
	// get method to get tax amount	
	public double getTaxAmount()
	{
		return taxAmount;
	}
	
	// set method to set new tax amount
	public void setTaxAmount(double newTaxAmount)
	{
		taxAmount = newTaxAmount;
	}
}
