namespace aoc.D24
{
  public class Hextille
  {
    private readonly int _x;
    private readonly int _y;
    private readonly int _z;
    private Color _color;

    public int X
    {
      get { return _x; }
    }

    public int Y
    {
      get { return _y; }
    }

    public int Z
    {
      get { return _z; }
    }

    public Hextille(int x, int y, int z)
    {
      _x = x;
      _y = y;
      _z = z;
      _color = Color.White;
    }

    public Color Color
    {
      get { return _color; }
    }

    public void Flip()
    {
      if (_color == Color.Black)
        _color = Color.White;
      else
        _color = Color.Black;
    }
  }
}
