using System;
public static class Randomizer 
{
	static Random random = new Random();
	public static int getInteger() {
		return (int)(random.Next(6));
	}
}
