using System;
using System.Collections.Generic;

namespace aoc.D11
{
  public class SeatingSystem
  {
    private int _rows;
    private int _cols;
    private Seat[,] _seats;
    private Seat[,] _initialCfg;
    private Seat[,] _snapshot;
    private bool _hasStabilized;

    public SeatingSystem(Seat[,] seats)
    {
      _hasStabilized = false;
      _rows = seats.GetLength(0);
      _cols = seats.GetLength(1);
      _seats = seats;

      _initialCfg = new Seat[_rows, _cols];

      for (int i = 0; i < _rows; i++)
        for (int j = 0; j < _cols; j++)
          _initialCfg[i, j] = new Seat(i, j, _seats[i, j].Status);
    }

    public int PartI()
    {
      return Calculate();
    }

    public int PartII()
    {
      return Calculate(true);
    }

    public void Print()
    {
      for (int i = 0; i < _rows; i++)
      {
        for (int j = 0; j < _cols; j++)
        {
          var status = _seats[i, j].Status;
          char c;

          switch (status)
          {
            case Status.Floor:
              c = '.';
              break;
            case Status.Occupied:
              c = '#';
              break;
            case Status.Empty:
              c = 'L';
              break;
            case Status.Unknown:
            default:
              c = '!';
              break;
          }

          Console.Write(c);
        }

        Console.WriteLine();
      }

      Console.WriteLine("\n");
    }

    private void Reset()
    {
      _hasStabilized = false;

      for (int i = 0; i < _rows; i++)
        for (int j = 0; j < _cols; j++)
          _seats[i, j] = new Seat(i, j, _initialCfg[i, j].Status);
    }

    private int Calculate(bool partII = false)
    {
      int occupiedCount = 0;

      while (!_hasStabilized)
      {
        if (partII)
          Simulate(true);
        else
          Simulate();
      }

      foreach (var s in _seats)
        if (s.Status == Status.Occupied)
          occupiedCount++;

      Reset();

      return occupiedCount;
    }

    private void Simulate(bool partII = false)
    {
      int changes = 0;
      var next = Status.Unknown;
      var current = Status.Unknown;

      _snapshot = new Seat[_rows, _cols];

      for (int i = 0; i < _rows; i++)
        for (int j = 0; j < _cols; j++)
          _snapshot[i, j] = new Seat(i, j, _seats[i, j].Status);

      foreach (var s in _seats)
      {
        current = s.Status;

        if (partII)
          next = GetNextStatus(s, true);
        else
          next = GetNextStatus(s);

        if (current != next)
        {
          changes++;
          s.Status = next;
        }
      }

      if (changes == 0)
        _hasStabilized = true;
    }

    private Status GetNextStatus(Seat s, bool partII = false)
    {
      int occupiedCount = 0;
      var result = Status.Unknown;
      var neighbors = new List<Seat>();
      int minReq;      

      if (s.Status == Status.Floor)
        result = Status.Floor;
      else
      {
        if (partII)
        {
          minReq = 4;
          neighbors = GetVisibleNeighbors(s);
        }
        else
        {
          minReq = 3;
          neighbors = GetNeighbors(s);
        }


        foreach (var n in neighbors)
          if (n.Status == Status.Occupied)
            occupiedCount++;

        if ((s.Status == Status.Empty) && (occupiedCount == 0))
          result = Status.Occupied;

        else if ((s.Status == Status.Occupied) && (occupiedCount > minReq))
          result = Status.Empty;
        else
          result = s.Status;  //retain state
      }

      return result;
    }

    private List<Seat> GetNeighbors(Seat s)
    {
      var neighbors = new List<Seat>();

      var temp = GetSeat(s.R - 1, s.C);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R - 1, s.C + 1);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R, s.C + 1);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R + 1, s.C + 1);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R + 1, s.C);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R + 1, s.C - 1);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R, s.C - 1);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeat(s.R - 1, s.C - 1);
      if (temp != null)
        neighbors.Add(temp);

      return neighbors;
    }

    private List<Seat> GetVisibleNeighbors(Seat s)
    {
      var neighbors = new List<Seat>();

      var temp = GetSeatInLoS(s, 1);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 2);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 3);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 4);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 5);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 6);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 7);
      if (temp != null)
        neighbors.Add(temp);

      temp = GetSeatInLoS(s, 8);
      if (temp != null)
        neighbors.Add(temp);

      return neighbors;
    }

    private Seat GetSeat(int r, int c)
    {
      if ((r < 0) || (c < 0) || (r > _rows - 1) || (c > _cols - 1))
        return null;

      return _snapshot[r, c];
    }

    private Seat GetSeatInLoS(Seat s, int dir)
    {
      int r;
      int c;
      Seat result = null;
      
      switch (dir)
      {
        case 1:
          r = s.R - 1;
          c = s.C;
          while (r > -1)
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            r--;
          }
          break;

        case 2:
          r = s.R - 1;
          c = s.C + 1;
          while ((r > -1) && (c < _cols))
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            r--;
            c++;
          }
          break;

        case 3:
          r = s.R;
          c = s.C + 1;
          while (c < _cols)
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            c++;
          }
          break;

        case 4:
          r = s.R + 1;
          c = s.C + 1;
          while ((r < _rows) && (c < _cols))
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            r++;
            c++;
          }
          break;

        case 5:
          r = s.R + 1;
          c = s.C;
          while (r < _rows)
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            r++;
          }
          break;

        case 6:
          r = s.R + 1;
          c = s.C - 1;
          while ((r < _rows) && (c > -1))
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            r++;
            c--;
          }
          break;

        case 7:
          r = s.R;
          c = s.C - 1;
          while (c > -1)
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            c--;
          }
          break;

        case 8:
          r = s.R - 1;
          c = s.C - 1;
          while ((r > -1) && (c > -1))
          {
            if (_snapshot[r, c].Status != Status.Floor)
            {
              result = _snapshot[r, c];
              break;
            }
            r--;
            c--;
          }
          break;

        default:
          break;
      }

      return result;
    }
  }
}