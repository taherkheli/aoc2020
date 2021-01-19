using System;
using System.Collections.Generic;
using System.IO;

namespace aoc.D14
{
  public class Parser
  {
    public static List<Tuple<string, long, long>> Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var result = new List<Tuple<string, long, long>>();
      string mask = String.Empty;
      long address;
      long value;

      for (int i = 0; i < lines.Length; i++)
      {
        if (lines[i].StartsWith("mask"))    //update mask         
          mask = lines[i].Substring(7);        
        else 
        {
          var s = lines[i].Split(" = ");
          var temp = s[0].Substring(4);
          address = Int64.Parse(temp.Remove(temp.Length - 1));
          value = Int64.Parse(s[1].Trim());

          result.Add(Tuple.Create(mask, address, value));
        }
      }

      return result;
    }
  }
}
