using aoc.D24;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D24
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D24/ex.txt", 10)]
    [DataRow("./D24/input.txt", 455)]
    public void PartI(string path, int expected)
    {
      var paths = Parser.Parse(path);
      var grid = new Grid();

      var actual = grid.PartI(paths);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D24/ex.txt", 100, 2208)]
    [DataRow("./D24/input.txt", 100, 3904)]
    public void PartII(string path, int days, int expected)
    {
      var paths = Parser.Parse(path);
      var grid = new Grid();

      var actual = grid.PartII(paths, days);

      Assert.AreEqual(expected, actual);
    }
  }
}
