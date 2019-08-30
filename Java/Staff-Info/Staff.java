public abstract class Staff {
	// declaring data fields to store staff name, staff id and position
		protected String staffName;
		protected String staffId;
		protected String position;
		
		// declaring no-arg/default constructor
		public Staff()
		{
			
		}
		
		// creating get method to get staff name
		public String getName()
		{
			return staffName;
		}
		
		// creating set method to change staff name
		public void setName(String newStaffName)
		{
			staffName = newStaffName;
		}
		
		// creating get method to get staff id
		public String getId()
		{
			return staffId;
		}

		// creating set method to change staff id
		public void setId(String newId)
		{
			staffId = newId;
		}

		// creating get method to get position
		public String getPosition()
		{
			return position;
		}

		// creating set method to change position
		public void setPosition(String newPosition)
		{
			position = newPosition;
		}		
		
		
		// creating a method to represents string format of new staff, staff id and staff position
		public String toString()
		{
			String newStaffId = getId();
			String newStaffName = getName();
			String newPosition = getPosition();
			return "Staff id is " + newStaffId + ". Staff name is " + newStaffName + ". Staff position is " + newPosition + ".";
		}
}

class FullTimeStaff extends Staff
{
	protected String researchArea;
	
	// declaring no-arg/default constructor
	public FullTimeStaff() 
	{
	
	}
			
	// creating get method to get research area
	public String getResearchArea()
	{
		return researchArea;
	}
			
	// creating set method to change research area
	public void setResearchArea(String newResearchArea)
	{
		researchArea = newResearchArea;
	}
	
	// creating a method to represents string format of research area
	public String toString()
	{
		String newResearchArea = getResearchArea();
		return "Staff duty is full time. " + super.toString() + " Research area is " + newResearchArea + ".";
	}
}

class PartTimeStaff extends Staff
{
	private String timeFraction;
	
	// declaring no-arg/default constructor
	public PartTimeStaff() 
	{

	}
			
	// creating get method to get time fraction
	public String getTimeFraction()
	{
		return timeFraction;
	}
			
	// creating set method to change time fraction
	public void setTimeFraction(String newTimeFraction)
	{
		timeFraction = newTimeFraction;
	}
	
	// creating a method to represents string format of time fraction
	public String toString()
	{
		String newTimeFraction = getTimeFraction();
		return "Staff duty is part time. " + super.toString() + " Time fraction is " + newTimeFraction + ".";
	}
}

class CasualStaff extends Staff
{
	protected String hours;
	
	// declaring no-arg/default constructor
	public CasualStaff() 
	{

	}
			
	// creating get method to get hoursstaf
	public String getHours()
	{
		return hours;
	}
			
	// creating set method to change hours
	public void setHours(String newHours)
	{
		hours = newHours;
	}
	
	// creating a method to represents string format of hours
	public String toString()
	{
		String newHours = getHours();
		return "Staff duty is casual. " + super.toString() + " Hours are " + newHours + ".";
	}
}
