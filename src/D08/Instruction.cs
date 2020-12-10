namespace aoc.D08
{
  public class Instruction
  {
    private Operation _operation;
    private int _argument;
    private bool _executed;

    public Instruction(Operation operation, int argument)
    {
      _operation = operation;
      _argument = argument;
      _executed = false;
    }

    public Operation Operation { get { return _operation; } set { _operation = value; } }

    public int Argument { get { return _argument; } set { _argument = value; } }

    public bool Executed { get { return _executed; } set { _executed = value; } }
  }
}