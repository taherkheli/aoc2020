using aoc.D09;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D09
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D09/ex.txt", 5, 127)]
    [DataRow("./D09/input.txt", 25, 27911108)]

    public void PartI(string path, int preamble, int expected)
    {
      var xmas = new XMAS(path, preamble);

      var actual = xmas.PartI();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D09/ex.txt", 5, 62)]
    [DataRow("./D09/input.txt", 25, 4023754)]
    public void PartII(string path, int preamble, int expected)
    {
      var xmas = new XMAS(path, preamble);
      var num = xmas.PartI();

      var actual = xmas.PartII(num);

      Assert.AreEqual(expected, actual);
    }
  }
}
