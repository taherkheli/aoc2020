using System.IO;

namespace aoc.D11
{
  public class Parser
  {
    public static Seat[,] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var r = lines.Length;
      var c = lines[0].Trim().Length;
      var result = new Seat[r, c];

      for (int i = 0; i < r; i++)
      {
        for (int j = 0; j < c; j++)
        {
          switch (lines[i].Trim()[j])
          {          
            case '.':
              result[i, j] = new Seat(i, j, Status.Floor);
              break;

            case 'L':
              result[i, j] = new Seat(i, j, Status.Empty);
              break;

            case '#':
              result[i, j] = new Seat(i, j, Status.Occupied);
              break;

            default:
              result[i, j] = new Seat(i, j, Status.Unknown);
              break;
          }
        }
      }

      return result;
    }
  }
}
