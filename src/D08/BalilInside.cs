using System;
using System.Collections.Generic;

namespace aoc.D08
{
  public class BalilInside
  {
    private int iPtr;
    private List<Instruction> _code;
    private int _reg1;

    public BalilInside(List<Instruction> program)
    {
      iPtr = 0;
      _code = program;
      _reg1 = 0;
    }

    //returns true if completed successfully till the very end. false if infinite loop was detected
    private bool Execute()
    {
      bool complete = true;
      var inst = _code[iPtr];

      while (true)
      {
        switch (inst.Operation)
        {
          case Operation.Accumulate:
            _reg1 += inst.Argument;
            inst.Executed = true;
            iPtr++;
            break;

          case Operation.Jump:
            iPtr += inst.Argument;
            inst.Executed = true;
            break;

          case Operation.NOP:
            iPtr++;
            inst.Executed = true;
            break;

          case Operation.Unknown:
          default:
            throw new Exception("Should never have happened. Fix it!");
        }

        if (iPtr == _code.Count) //last instructon executed already = program ended successfully				
          break;
        else
          inst = _code[iPtr];

        if (inst.Executed) //infinte loop detected
        {
          complete = false;
          break;
        }
      }

      return complete;
    }

    private void reset()
    {
      iPtr = 0;
      _reg1 = 0;

      foreach (var inst in _code)
        inst.Executed = false;
    }

    public int PartI()
    {
      Execute();
      int result = _reg1;
      reset();
      return result;
    }

    public int PartII()
    {
      int result = 0;
      bool done = false;
      var jumps = new List<int>();
      var nops = new List<int>();

      for (int i = 0; i < _code.Count; i++)
      {
        if (_code[i].Operation == Operation.Jump)
          jumps.Add(i);
        else if (_code[i].Operation == Operation.NOP)
          nops.Add(i);
      }

      //change nops to jumps n try
      foreach (var nop in nops)
      {
        _code[nop].Operation = Operation.Jump;

        if (Execute())
        {
          result = _reg1;
          done = true;
          reset();
          break;
        }
        else
        {
          _code[nop].Operation = Operation.NOP;
          reset();
        }
      }

      if (!done)
      {
        //change jumps to nops n try
        foreach (var jump in jumps)
        {
          _code[jump].Operation = Operation.NOP;

          if (Execute())
          {
            result = _reg1;
            reset();
            break;
          }
          else
          {
            _code[jump].Operation = Operation.Jump;
            reset();
          }
        }
      }

      return result;
    }
  }
}
