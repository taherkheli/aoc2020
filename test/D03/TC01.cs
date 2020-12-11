using aoc.D03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D03
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D03/ex.txt", 7)]
    [DataRow("./D03/input.txt", 159)]
    public void PartI(string path, int expected)
    {
      var g = new Grid(path);

      var actual = g.TreesEncountered(3, 1);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D03/ex.txt", 336)]
    [DataRow("./D03/input.txt", 6419669520)]
    public void PartII(string path, long expected)
    {
      var g = new Grid(path);

      long product = 1;
      product *= g.TreesEncountered(1, 1);
      g.reset();
      product *= g.TreesEncountered(3, 1);
      g.reset();
      product *= g.TreesEncountered(5, 1);
      g.reset();
      product *= g.TreesEncountered(7, 1);
      g.reset();
      product *= g.TreesEncountered(1, 2);
      var actual = product;

      Assert.AreEqual(expected, actual);
    }
  }
}
