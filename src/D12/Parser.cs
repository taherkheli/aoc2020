using System.IO;

namespace aoc.D12
{
  public class Parser
  {
    public static Instruction[] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var result = new Instruction[lines.Length];

      for (int i = 0; i < lines.Length; i++)
        result[i] = new Instruction(lines[i][0], int.Parse(lines[i].Substring(1).Trim()));

      return result;
    }
  }
}
