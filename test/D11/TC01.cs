using aoc.D11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D11
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D11/ex.txt", 37)]
    [DataRow("./D11/input.txt", 2453)]
    public void PartI(string path, int expected)
    {
      var seatingSystem = new SeatingSystem(Parser.Parse(path));

      var actual = seatingSystem.PartI();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D11/ex.txt", 26)]
    [DataRow("./D11/input.txt", 2159)]
    public void PartII(string path, int expected)
    {
      var seatingSystem = new SeatingSystem(Parser.Parse(path));

      var actual = seatingSystem.PartII();

      Assert.AreEqual(expected, actual);
    }
  }
}
