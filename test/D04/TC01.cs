using aoc.D04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D04
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D04/ex1.txt", 2)]
    [DataRow("./D04/input.txt", 170)]
    public void PartI(string path, int expected)
    {
      var passports = Parser.Parse(path);
      int count = 0;

      foreach (var p in passports)
        if (p.ValidatePartI())
          count++;

      var actual = count;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D04/ex2.txt", 4)]
    [DataRow("./D04/input.txt", 103)]
    public void PartII(string path, int expected)
    {
      var passports = Parser.Parse(path);
      int count = 0;

      foreach (var p in passports)
        if (p.ValidatePartII())
          count++;

      var actual = count;

      Assert.AreEqual(expected, actual);
    }
  }
}
