using System;
using System.Collections.Generic;
using System.Text;

namespace aoc.D14
{
  public class Emulator
  {
    private Dictionary<long, long> _memory;

    public Emulator()
    {
      _memory = new Dictionary<long, long>();
    }

    public long PartI(List<Tuple<string, long, long>> list) 
    {
      long sum = 0;

      foreach (var item in list)
      {
        var (mask, address, value) = item;
        var binaryValue_s = ApplyMask(mask, value);  //binary representation as a string
        value = Convert.ToInt64(binaryValue_s, 2);
        Store(new List<long>() { address }, value);
      }

      foreach (var item in _memory)
        sum += item.Value;

      return sum;
    }

    public long PartII(List<Tuple<string, long, long>> list)
    {     
      _memory = new Dictionary<long, long>();  //undo PartI
      long sum = 0;

      foreach (var item in list)
      {
        var (mask, address, value) = item;

        var address_list = ApplyMaskII(mask, address);    
        
        Store(address_list, value);
      }

      foreach (var item in _memory)
        sum += item.Value;

      return sum;
    }

    private string ApplyMask(string mask, long num)
    {
      var sb = new StringBuilder();
      var num_s = Convert.ToString(num, 2).PadLeft(36, '0');

      for (int i = 0; i < mask.Length; i++)
      {
        if ((mask[i] == '1') || (mask[i] == '0'))
          sb.Append(mask[i]);
        else
          sb.Append(num_s[i]);
      }

      return sb.ToString();
    }

    private List<long> ApplyMaskII(string mask, long num)
    {
      var result = new List<long>();
      int i = 0;
      var xIndices = new List<int>();
      var sb = new StringBuilder();      
      var num_s = Convert.ToString(num, 2).PadLeft(36, '0');

      foreach (var c in mask)
      {
        if (c == '1')
          sb.Append(c);
        else if (c == '0')
          sb.Append(num_s[i]);
        else
          sb.Append('X');
        
        i++;
      }

      var masked = sb.ToString();

      for (int j = 0; j < masked.Length; j++)      
        if (masked[j] == 'X')
          xIndices.Add(j);

      var combos = GetCombos(xIndices.Count);

      foreach (var combo in combos)
      {
        var maskedArray = masked.ToCharArray();   //much better performance instead of String.Insert() n Remove()

        for (int k = 0; k < combo.Length; k++)   //replace at appropriate indices
          maskedArray[xIndices[k]] = combo[k];

        masked = new string(maskedArray);
        result.Add(Convert.ToInt64(masked, 2));
      }

      return result;
    }

    private void Store(List<long> addresses, long value)
    {
      long v;

      foreach (var address in addresses)
      {
        if (_memory.TryGetValue(address, out v))  //update exisiting mem location
          _memory[address] = value;
        else
          _memory.Add(address, value);
      }
    }

    private List<string> GetCombos(int size)
    {
      var result = new List<string>();
      var combinations = (int)Math.Pow(2, size);

      for (int i = 0; i < combinations; i++)
        result.Add(Convert.ToString((long)i, 2).PadLeft(size, '0'));

      return result;
    }
  }
}
