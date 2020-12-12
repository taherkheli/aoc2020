namespace aoc.D11
{
  public class Seat
  {
    private int _r;
    private int _c;
    private Status _status;

    public Seat(int r, int c, Status status)
    {
      _r = r;
      _c = c;
      _status = status;
    }

    public int R { get { return _r; } set { _r = value; } }

    public int C { get { return _c; } set { _c = value; } }

    public Status Status { get { return _status; } set { _status = value; } }
  }
}
