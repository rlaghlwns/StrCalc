using System;

namespace StrCalcLibrary
{
    public class WilksRank
    {
		public double weightClass(double weight)
		{
			double[] weightArr = new double[12] { 52, 56, 60, 67, 75, 82, 90, 100, 110, 125, 145, 146 };
			double result = 146;
			for (int i = 0; i < weightArr.Length; i++)
			{
				if (weight < weightArr[i]) result = weightArr[i];
			}
			return result;
		}

		public String getRank(double wilkspoint, double weightClass)
		{
			double[] standard = new double[5];
			if (weightClass.Equals(52)) standard = new double[5] { 116, 193, 227, 321, 416 };
			if (weightClass.Equals(56)) standard = new double[5] { 116, 193, 230, 320, 415 };
			if (weightClass.Equals(60)) standard = new double[5] { 117, 195, 231, 321, 414 };
			if (weightClass.Equals(67)) standard = new double[5] { 118, 197, 236, 326, 416 };
			if (weightClass.Equals(75)) standard = new double[5] { 119, 198, 236, 326, 415 };
			if (weightClass.Equals(82)) standard = new double[5] { 120, 201, 239, 329, 418 };
			if (weightClass.Equals(90)) standard = new double[5] { 121, 201, 241, 329, 416 };
			if (weightClass.Equals(100)) standard = new double[5] { 121, 202, 243, 330, 415 };
			if (weightClass.Equals(110)) standard = new double[5] { 123, 204, 242, 329, 412 };
			if (weightClass.Equals(125)) standard = new double[5] { 122, 203, 241, 326, 408 };
			if (weightClass.Equals(145)) standard = new double[5] { 121, 202, 240, 324, 405 };
			if (weightClass.Equals(146)) standard = new double[5] { 124, 206, 245, 330, 413 };
			
			String rank = "Beginner";
			if (wilkspoint > standard[0]) rank = "Novice";
			if (wilkspoint > standard[1]) rank = "Intermediate";
			if (wilkspoint > standard[2]) rank = "Advanced";
			if (wilkspoint > standard[3]) rank = "Elite";
			if (wilkspoint > standard[3]) rank = "Professional";
			return rank;
		}
	}
}
