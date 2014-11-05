//Given n points on a 2D plane, 
//find the maximum number of points that lie on the same straight line.

//Two special cases:
//duplicate points
//vertical line (avoid division by 0)

using System;
using System.Collections.Generic;
using System.Collections;

namespace MaxPointsOnLine
{
	//definition for point class
	class Point
	{
		public int x{ get; set;}
		public int y{ get; set;}
		public Point() {
			x = 0;
			y = 0;
		}
		public Point(int a, int b)
		{
			x = a;
			y = b;
		}

	}

	class Finder
	{
		public static int FindMaxPoints(Point[] points)
		{
			Dictionary<float, int> dic = new Dictionary<float, int> ();
			int MaxNum = 0;
			int duplicate;
			for (int i = 0; i < points.Length; i++) {
				dic.Clear (); //clear dic each time
				duplicate = 1; //reset duplicate flag
				for (int j = 0; j < points.Length; j++) {
					if (i == j) //skip the point itself
						continue;

					//handle duplicate
					if (points [i].x == points [j].x && points [i].y == points [j].y) {
						duplicate++;
						continue;
					}

					//handle non-duplicate points
					float key = (points [j].x - points [i].x == 0) ? int.MaxValue : //handle vertical line
						(float)(points [j].y - points [i].y) / (points [j].x - points [i].x);

					if (dic.ContainsKey (key))
						dic [key] += 1;
					else {
						dic.Add (key, 1);
					}
				}

				//Shows How to iterate an unordered data strucutre
				foreach (KeyValuePair<float,int> kp in dic) { //remember use KeyValuePair<>
					if (kp.Value + duplicate > MaxNum)
						MaxNum = kp.Value + duplicate;
				}
			}
			return MaxNum;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Point[] points = new Point[] {new Point (1, 2), new Point (3, 4), new Point (5, 6),
				new Point (3, 16), new Point (9, 10), new Point (7, 8), new Point (1, 10), new Point (3, 5),
				new Point (3, 9), new Point (3, 9), new Point (3, 22), new Point (3, 6), new Point (3, 2),
			};

			Console.WriteLine (Finder.FindMaxPoints (points));
		}
	}
}
