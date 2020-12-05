using System;

namespace aoc.D05
{
	public class BoardingPass
	{
		private int _seatID;

		public BoardingPass(string code)
		{
			if (code.Length != 10)
				throw new ArgumentException("code must be 10 digits long!");

			_seatID = GetSeatID(code);
		}

		public int SeatID { get { return _seatID; } }

		public static int PartI(BoardingPass[] passes)
		{
			int max = -1;

			foreach (var b in passes)
			{
				if (b.SeatID > max)
					max = b.SeatID;
			}

			return max;
		}

		public static int PartII(BoardingPass[] passes)
		{
			Array.Sort(passes, (x1, x2) => x1.SeatID.CompareTo(x2.SeatID));

			int mySeatID = -1;

			for (int i = 0; i < passes.Length; i++)
			{
				if (i != passes.Length - 1) //last element should not be checked
				{
					if ((passes[i + 1].SeatID - passes[i].SeatID) != 1)
					{
						mySeatID = passes[i].SeatID + 1;
						break;
					}
				}
			}

			return mySeatID;
		}

	  private int GetSeatID(string s)
		{
			var s_row = s.Substring(0, 7);
			var s_column = s.Substring(7);

			return 8 * GetRow(s_row) + GetColumn(s_column);
		}

		private int GetColumn(string s)
		{
			return Locate(s);
		}

		private int GetRow(string s)
		{
			return Locate(s);
		}

		private int Locate(string s)
		{
			var iterations = s.Length;
			var range = new int[] { 0, (int)Math.Pow(2, iterations) - 1 };  //starting point

			for (int i = 0; i < iterations; i++)
			{
				range = UpdateRange(s[i], range);
			}

			return range[0];
		}

		private int[] UpdateRange(char c, int[] range)
		{
			var result = new int[2] { -1, -1 };

			if ((range[1] - range[0]) == 1) //final iteration
			{
				if ((c == 'R') || (c == 'B'))
				{
					result[0] = result[1] = range[1];
				}
				else if ((c == 'L') || (c == 'F'))
				{
					result[0] = result[1] = range[0];
				}
			}
			else
			{
				if ((c == 'R') || (c == 'B'))
				{
					result[0] = range[0] + ((range[1] - range[0]) + 1) / 2;
					result[1] = range[1];
				}
				else if ((c == 'L') || (c == 'F'))
				{
					result[0] = range[0];
					result[1] = range[0] + ((((range[1] - range[0]) + 1) / 2) - 1);
				}
			}

			return result;
		}
	}
}
