using aoc.D08;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D08
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D08/ex.txt", 5)]
    [DataRow("./D08/input.txt", 1420)]

    public void PartI(string path, int expected)
    {
      var program = Parser.Parse(path);
      var b = new BalilInside(program);

      var actual = b.PartI();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D08/ex.txt", 8)]
    [DataRow("./D08/input.txt", 1245)]
    public void PartII(string path, int expected)
    {
      var program = Parser.Parse(path);

      var b = new BalilInside(program);

      var actual = b.PartII();

      Assert.AreEqual(expected, actual);
    }
  }
}
