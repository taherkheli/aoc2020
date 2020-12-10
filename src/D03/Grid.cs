using System.Collections.Generic;
using System.IO;

namespace aoc.D03
{
  public class Grid
  {
    private int _currX;
    private int _currY;
    private int _maxX;
    private int _maxY;
    private List<Point> _points;

    public Grid(string path)
    {
      _currX = 0;
      _currY = 0;
      var lines = File.ReadAllLines(path);
      _maxY = lines.Length;
      _maxX = lines[0].Trim().Length;
      _points = new List<Point>();
      Initialize(lines);
    }

    private void Initialize(string[] lines)
    {
      for (int x = 0; x < _maxX; x++)
        for (int y = 0; y < _maxY; y++)
          _points.Add(new Point(x, y, (lines[y][x] == '#' ? true : false)));
    }

    private void ExpandAlongX()
    {
      List<Point> movedCopy = _points.ConvertAll(p => new Point(p.X + _maxX, p.Y, p.T));
      _points.AddRange(movedCopy);
      _maxX += _maxX;
    }

    public void reset()
    {
      _currX = 0;
      _currY = 0;
    }

    public void Move(int right, int down)
    {
      _currY += down;
      _currX += right;

      //expansion needed?
      if (_currX >= _maxX)
        ExpandAlongX();
    }

    public int TreesEncountered(int right, int down)
    {
      int count = 0;

      while (true)
      {
        Move(right, down);

        if (_currY >= _maxY)
          break;

        var p = _points.Find(p => ((p.X == _currX) && (p.Y == _currY)));

        if (p.T)
          count++;
      }

      return count;
    }
  }
}
