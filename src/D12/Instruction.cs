namespace aoc.D12
{
  public readonly struct Instruction
  {
    public Instruction(char action, int value)
    {
      Action = action;
      Value = value;
    }

    public char Action { get; }
    public int Value { get; }

    public override string ToString() => $"({Action}{Value})";
  }
}
