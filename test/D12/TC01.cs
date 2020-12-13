using aoc.D12;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D12
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D12/ex.txt", 25)]
    [DataRow("./D12/input.txt", 1319)]
    public void PartI(string path, int expected)
    {
      var ferry = new Ferry(Parser.Parse(path));

      var actual = ferry.PartI();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D12/ex.txt", 286)]
    [DataRow("./D12/input.txt", 62434)]
    public void PartII(string path, int expected)
    {
      var ferry = new Ferry(Parser.Parse(path));

      var actual = ferry.PartII();

      Assert.AreEqual(expected, actual);
    }
  }
}
