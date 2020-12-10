using System.IO;

namespace aoc.D01
{
  public static class Parser
  {
    public static int[] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var numbers = new int[lines.Length];

      for (var i = 0; i < lines.Length; i++)
        numbers[i] = int.Parse(lines[i].Trim());

      return numbers;
    }
  }
}
