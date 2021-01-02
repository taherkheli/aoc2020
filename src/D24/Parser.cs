using System.Collections.Generic;
using System.IO;

namespace aoc.D24
{
  public class Parser
  {
    public static List<List<Dir>> Parse(string path)
    {
      var result = new List<List<Dir>>();
      var lines = File.ReadAllLines(path);

      foreach (var line in lines)
      {
        var temp = new List<Dir>();

        for (int i = 0; i < line.Length; i++)
        {
          switch (line[i])
          {
            case 'e':
              temp.Add(Dir.E);
              break;

            case 'w':
              temp.Add(Dir.W);
              break;

            case 's':
              if (line[i + 1] == 'e')
                temp.Add(Dir.SE);
              else
                temp.Add(Dir.SW);              
              i++;              
              break;

            case 'n':
              if (line[i + 1] == 'e')
                temp.Add(Dir.NE);
              else
                temp.Add(Dir.NW);
              i++;
              break;

            default:
              throw new InvalidDataException("Should not have happened!");
          }
        }

        result.Add(temp);
      }

      return result;
    }
  }
}
