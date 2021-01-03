using System;
using System.Collections.Generic;
using System.Text;

namespace aoc.D14
{
  public class Emulator
  {
    private Dictionary<long, String> _memory;

    public Emulator()
    {
      _memory = new Dictionary<long, string>();
    }

    public long PartI(List<Tuple<string, long, long>> list) 
    {
      string mask;
      long address;
      long value;
      long sum = 0;

      foreach (var item in list)
      {
        mask = item.Item1;
        address = item.Item2;
        value = item.Item3;

        var values_s = ApplyMask(mask, value);
        Store(address, values_s);
      }

      foreach (var item in _memory)
        sum += Convert.ToInt64(item.Value, 2);

      return sum;
    }

    private string ApplyMask(string mask, long num)
    {
      var sb = new StringBuilder();
      var num_s = Convert.ToString(num, 2).PadLeft(36, '0');

      int i = 0;

      foreach (var c in mask)
      {
        if ((c == '1') || (c == '0'))
          sb.Append(c);
        else
          sb.Append(num_s[i]);

        i++;
      }

      return sb.ToString();
    }

    private void Store(long address, string value)
    {
      string v;

      if (_memory.TryGetValue(address, out v))  //update exisiting mem location
        _memory[address] = value;
      else
        _memory.Add(address, value);
    }
  }
}
