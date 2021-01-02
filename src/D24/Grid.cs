using System;
using System.Collections.Generic;
using System.IO;

namespace aoc.D24
{
  public class Grid
  {
    private List<Hextille> _visited;

    public int PartI(List<List<Dir>> paths)
    {
      _visited = new List<Hextille>();
      var blacksCount = 0;

      foreach (var path in paths)
        ExecuteSteps(path);

      foreach (var h in _visited)
        if (h.Color == Color.Black)
          blacksCount++;

      return blacksCount;
    }

    public int PartII(List<List<Dir>> paths, int days)
    {      
      PartI(paths); //call Part I to get initial config

      var blacksCount = 0;
      List<int> indicesBlack;
      List<int> indicesWhite;

      for (int i = 1; i < (days + 1); i++)
      {
        blacksCount = 0;
        indicesBlack = new List<int>();
        indicesWhite = new List<int>();

        for (int j = 0; j < _visited.Count; j++)
        {
          var h = _visited[j];
          var blackNeighborsCount = GetBlackNeighborsCount(h);

          if (h.Color == Color.Black)
          {
            if ((blackNeighborsCount == 0) || (blackNeighborsCount > 2))
              indicesBlack.Add(j);
          }
          else //white
          {
            if (blackNeighborsCount == 2)
              indicesWhite.Add(j);            
          }
        }

        foreach (var index in indicesWhite)
          _visited[index].Flip();        

        foreach (var index in indicesBlack)
          _visited[index].Flip();

        foreach (var h in _visited)
          if (h.Color == Color.Black)
            blacksCount++;

        //these may have null tiles in their neighbors, fix that by creating any missing neighbors
        var list = new List<Hextille>();   

        foreach (var index in indicesWhite)        
          list.Add(_visited[index]);        

        foreach (var h in list)
          CreateMissingNeighbors(h);

        indicesBlack = null;
        indicesWhite = null;
      }

      return blacksCount;
    }

    private void ExecuteSteps(List<Dir> path)
    {
      var coords = GetCoords(path);

      var hextille = _visited.Find(h => ((h.X == coords.Item1) && (h.Y == coords.Item2) && (h.Z == coords.Item3)));

      if (hextille != null) //previously visited
        hextille.Flip();
      else
      {
        hextille = new Hextille(coords.Item1, coords.Item2, coords.Item3);
        hextille.Flip();
        _visited.Add(hextille);
      }

      CreateMissingNeighbors(hextille);
    }

    //choosing cube coordinates based on https://www.redblobgames.com/grids/hexagons/#coordinates
    private Tuple<int, int, int> GetCoords(List<Dir> path)
    {
      int x = 0;
      int y = 0;
      int z = 0;

      foreach (var dir in path)
      {
        switch (dir)
        {
          case Dir.E:
            x += 1;
            y -= 1;
            break;
          case Dir.SE:
            z += 1;
            y -= 1;
            break;
          case Dir.SW:
            x -= 1;
            z += 1;
            break;
          case Dir.W:
            x -= 1;
            y += 1;
            break;
          case Dir.NW:
            z -= 1;
            y += 1;
            break;
          case Dir.NE:
            x += 1;
            z -= 1;
            break;
          case Dir.unknown:
          default:
            throw new InvalidDataException("Should not have happened!");
        }
      }

      return Tuple.Create(x, y, z);
    }

    private List<Tuple<int, int, int>> GetNeighborCoords(Hextille h)
    {
      var neighbors = new List<Tuple<int, int, int>>();

      neighbors.Add(Tuple.Create(h.X + 1, h.Y - 1, h.Z));  //E      
      neighbors.Add(Tuple.Create(h.X, h.Y - 1, h.Z + 1));  //SE
      neighbors.Add(Tuple.Create(h.X - 1, h.Y, h.Z + 1));  //SW
      neighbors.Add(Tuple.Create(h.X - 1, h.Y + 1, h.Z));  //W
      neighbors.Add(Tuple.Create(h.X, h.Y + 1, h.Z - 1));  //SE
      neighbors.Add(Tuple.Create(h.X + 1, h.Y, h.Z - 1));  //NE

      return neighbors;
    }

    private void CreateMissingNeighbors(Hextille hextille)
    {
      var nCoordsList = GetNeighborCoords(hextille);

      foreach (var nCoords in nCoordsList)
      {
        var h = _visited.Find(h => ((h.X == nCoords.Item1) && (h.Y == nCoords.Item2) && (h.Z == nCoords.Item3)));

        if (h == null)
        {
          h = new Hextille(nCoords.Item1, nCoords.Item2, nCoords.Item3);
          _visited.Add(h);
        }
      }
    }

    private int GetBlackNeighborsCount(Hextille h)
    {
      int blackNeighborsCount = 0;
      var neighbors = GetNeighborCoords(h);

      foreach (var nabo in neighbors)
      {
        var hextille = _visited.Find(h => ((h.X == nabo.Item1) && (h.Y == nabo.Item2) && (h.Z == nabo.Item3)));

        if ((hextille != null) && (hextille.Color == Color.Black))    // if null => tile is white anyway
          blackNeighborsCount++;
      }

      return blackNeighborsCount;
    }    
  }
}
