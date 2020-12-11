using System.IO;

namespace aoc.D05
{
  public static class Parser
  {
    public static BoardingPass[] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var result = new BoardingPass[lines.Length];

      for (int i = 0; i < lines.Length; i++)
        result[i] = new BoardingPass(lines[i].Trim());

      return result;
    }
  }
}
