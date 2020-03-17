using System;

namespace StrCalcLibrary
{
    public class WilksPoint
    {
		private readonly double maleA = -216.0475144;
		private readonly double maleB = 16.2606339;
		private readonly double maleC = -0.002388645;
		private readonly double maleD = -0.00113732;
		private readonly double maleE = 7.01863E-06;
		private readonly double maleF = -1.291E-08;
		private readonly double femaleA = 594.31747775582;
		private readonly double femaleB = -27.23842536447;
		private readonly double femaleC = 0.82112226871;
		private readonly double femaleD = -0.00930733913;
		private readonly double femaleE = 4.731582E-05;
		private readonly double femaleF = -9.054E-08;

		public double Coeff(double weight, double big3weight, string gender)
		{
			double x = weight;
			double total = big3weight;
			if (gender.Equals("Male"))
			{
				double result = total / (maleA + (maleB * Math.Pow(x, 1)) + (maleC * Math.Pow(x, 2)) + (maleD * Math.Pow(x, 3)) +
							(maleE * Math.Pow(x, 4)) + (maleF * Math.Pow(x, 5))) / 2 * 1000;
				return Math.Round(result, 0);
			}
			else
			{
				double result = total / (femaleA + (femaleB * Math.Pow(x, 1)) + (femaleC * Math.Pow(x, 2)) + (femaleD * Math.Pow(x, 3)) +
							(femaleE * Math.Pow(x, 4)) + (femaleF * Math.Pow(x, 5))) / 2 * 1000;
				return Math.Round(result, 0);
			}
		}

	}
}
