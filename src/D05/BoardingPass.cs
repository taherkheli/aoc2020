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
      var string_row = s.Substring(0, 7);
      var string_column = s.Substring(7);

      return 8 * GetRow(string_row) + GetColumn(string_column);
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
      var range = Tuple.Create(0, (int)Math.Pow(2, iterations) - 1);  //starting point

      foreach (var c in s)
        range = UpdateRange(c, range);

      return range.Item1;
    }

    private Tuple<int, int> UpdateRange(char c, Tuple<int, int> range)
    {
      var result = Tuple.Create(-1, -1);
      int lb = range.Item1;
      int ub = range.Item2;

      if ((ub - lb) == 1) //final iteration
      {
        if ((c == 'R') || (c == 'B'))
        {
          result = Tuple.Create(ub, ub);
        }
        else if ((c == 'L') || (c == 'F'))
        {
          result = Tuple.Create(lb, lb);
        }
      }
      else
      {
        if ((c == 'R') || (c == 'B'))
        {
          result = Tuple.Create(lb + ((ub - lb) + 1) / 2, ub);
        }
        else if ((c == 'L') || (c == 'F'))
        {
          result = Tuple.Create(lb, lb + ((((ub - lb) + 1) / 2) - 1));
        }
      }

      return result;
    }
  }
}
