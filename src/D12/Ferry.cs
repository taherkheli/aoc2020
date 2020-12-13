using System;

namespace aoc.D12
{
  public class Ferry
  {
    private Instruction[] _insts;
    private Direction _dir;
    private int _x;
    private int _y;
    private int _xw;
    private int _yw;

    public Ferry(Instruction[] instructions)
    {
      _x = 0;
      _y = 0;
      _xw = 0;
      _yw = 0;
      _dir = Direction.East;
      _insts = instructions;
    }

    public int PartI()
    {
      _x = 0;
      _y = 0;

      Navigate();

      return Math.Abs(_x) + Math.Abs(_y);
    }

    public int PartII()
    {
      _x = 0;
      _y = 0;
      _xw = _x + 10;
      _yw = _y + 1;

      NavigatePartII();

      return Math.Abs(_x) + Math.Abs(_y);
    }

    private void Navigate()
    {
      foreach (var i in _insts)
      {
        switch (i.Action)
        {
          case 'N':
            _y += i.Value;
            break;

          case 'S':
            _y -= i.Value;
            break;

          case 'E':
            _x += i.Value;
            break;

          case 'W':
            _x -= i.Value;
            break;

          case 'L':
            switch (i.Value)
            {
              case 90:
                switch (_dir)
                {
                  case Direction.East:
                    _dir = Direction.North;
                    break;
                  case Direction.West:
                    _dir = Direction.South;
                    break;
                  case Direction.North:
                    _dir = Direction.West;
                    break;
                  case Direction.South:
                    _dir = Direction.East;
                    break;
                  case Direction.Unknown:
                  default:
                    throw new Exception("Should not have happened!!");
                }
                break;

              case 180:
                switch (_dir)
                {
                  case Direction.East:
                    _dir = Direction.West;
                    break;
                  case Direction.West:
                    _dir = Direction.East;
                    break;
                  case Direction.North:
                    _dir = Direction.South;
                    break;
                  case Direction.South:
                    _dir = Direction.North;
                    break;
                  case Direction.Unknown:
                  default:
                    throw new Exception("Should not have happened!!");
                }
                break;

              case 270:
                switch (_dir)
                {
                  case Direction.East:
                    _dir = Direction.South;
                    break;
                  case Direction.West:
                    _dir = Direction.North;
                    break;
                  case Direction.North:
                    _dir = Direction.East;
                    break;
                  case Direction.South:
                    _dir = Direction.West;
                    break;
                  case Direction.Unknown:
                  default:
                    throw new Exception("Should not have happened!!");
                }
                break;

              default:
                throw new Exception("Should not have happened!!");
            }
            break;

          case 'R':
            switch (i.Value)
            {
              case 90:
                switch (_dir)
                {
                  case Direction.East:
                    _dir = Direction.South;
                    break;
                  case Direction.West:
                    _dir = Direction.North;
                    break;
                  case Direction.North:
                    _dir = Direction.East;
                    break;
                  case Direction.South:
                    _dir = Direction.West;
                    break;
                  case Direction.Unknown:
                  default:
                    throw new Exception("Should not have happened!!");
                }
                break;

              case 180:
                switch (_dir)
                {
                  case Direction.East:
                    _dir = Direction.West;
                    break;
                  case Direction.West:
                    _dir = Direction.East;
                    break;
                  case Direction.North:
                    _dir = Direction.South;
                    break;
                  case Direction.South:
                    _dir = Direction.North;
                    break;
                  case Direction.Unknown:
                  default:
                    throw new Exception("Should not have happened!!");
                }
                break;

              case 270:
                switch (_dir)
                {
                  case Direction.East:
                    _dir = Direction.North;
                    break;
                  case Direction.West:
                    _dir = Direction.South;
                    break;
                  case Direction.North:
                    _dir = Direction.West;
                    break;
                  case Direction.South:
                    _dir = Direction.East;
                    break;
                  case Direction.Unknown:
                  default:
                    throw new Exception("Should not have happened!!");
                }
                break;

              default:
                throw new Exception("Should not have happened!!");
            }
            break;

          case 'F':
            switch (_dir)
            {
              case Direction.East:
                _x += i.Value;
                break;
              case Direction.West:
                _x -= i.Value;
                break;
              case Direction.North:
                _y += i.Value;
                break;
              case Direction.South:
                _y -= i.Value;
                break;
              case Direction.Unknown:
              default:
                throw new Exception("Should not have happened!!");
            }
            break;

          default:
            throw new Exception("Should not have happened!!");
        }

      }
    }

    private void NavigatePartII()
    {
      //relative to ferry
      int dx;
      int dy;

      foreach (var i in _insts)
      {
        dx = _xw - _x;
        dy = _yw - _y;

        switch (i.Action)
        {
          case 'N':
            _yw += i.Value;
            break;

          case 'S':
            _yw -= i.Value;
            break;

          case 'E':
            _xw += i.Value;
            break;

          case 'W':
            _xw -= i.Value;
            break;

          case 'L':
            switch (i.Value)
            {
              case 90:
                //  x-> -y
                //  y-> x
                _xw = _x + (-1 * dy);
                _yw = _y + dx;
                break;

              case 180:
                //  x-> -x
                //  y-> -y
                _xw = _x + (-1 * dx);
                _yw = _y + (-1 * dy);
                break;

              case 270:
                //same as Rotate Right 90
                _xw = _x + dy;
                _yw = _y + (-1 * dx);
                break;

              default:
                throw new Exception("Should not have happened!!");
            }
            break;

          case 'R':
            switch (i.Value)
            {
              case 90:
                //  x-> y
                //  y-> -x
                _xw = _x + dy;
                _yw = _y + (-1 * dx);
                break;

              case 180:
                //Same as Rotate Left 180
                _xw = _x + (-1 * dx);
                _yw = _y + (-1 * dy);
                break;

              case 270:
                //same as Rotate Left 90
                _xw = _x + (-1 * dy);
                _yw = _y + dx;
                break;

              default:
                throw new Exception("Should not have happened!!");
            }
            break;

          case 'F':
            _x += dx * i.Value;
            _y += dy * i.Value;
            _xw = _x + dx;
            _yw = _y + dy;
            break;

          default:
            throw new Exception("Should not have happened!!");
        }
      }
    }
  }
}
