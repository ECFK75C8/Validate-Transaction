using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(compareValue(1500, 1500.45));
	}
	
	/**
		@param num
		@returns length.
		calculate the length of any given double value.
		e.g 45123.34 has a length of 5 ignoring the fractions.
	**/
	private static int calLength(double num){
	    if (num < 0)
		    throw new ArgumentOutOfRangeException();
		else if (num == 0)
			return 1;
		else
			return (int) Math.Floor(Math.Log10(num)) + 1;
	}
	
	/**
		@param length: 
		@return the number of times the compared value (returned amount by payment gatway)
		 should be divided to eliminate the added charges.
	**/
	private static int itterValue(int length){
		if (length <= 3)
			return 0;
		
		int copyLength = length;
		
		while(length > 3){
			length -= 3;
		}
		return copyLength - length;
	}
	

	/**
		@params x: amount generated/initiated by our system
		@params y: amount returned from payment gatway.
		compare both values to determine if they are equal to ascertain if user made
		correct payment.
		@return bool True if the two amount matches and False otherwise.
	**/
	private static bool compareValue(double x, double y){
		int num_x = (int) Math.Floor(x); // ignore fraction on x leaving only the whole number e.g 45000.00 gives 45000
		int num_y = (int) Math.Floor(y); // ignore fraction on y leaving only the whole number e.g 45120.45 gives 45120
		int len_y = calLength(num_y);    // calculate length of num_y(45120) gives 5
		
		//num_itter = 1000 if itterValue(len_y = 3). i.e (pow(10, 3) = 1000) 
		int num_itter = (int) Math.Pow(10, itterValue(len_y));
		
		int update_num_y = num_y / num_itter; // update_num_y = num_y (45120) / num_itter (1000) = 45
		
		if (num_x == (num_itter * update_num_y)) // num_x = 45000 compared to num_itter (1000) multilied by
			return true;                         // update_num_y 45 gives 45000 which returns True.
			
		return false;
	}
}