namespace aoc.D03
{
	public struct Point
	{
		public Point(int x, int y, bool isTree)
		{
      X = x;
      Y = y;
      T = isTree;
    }

    public int X { get; }
    public int Y { get; }
    public bool T { get; set; }
  }
}
