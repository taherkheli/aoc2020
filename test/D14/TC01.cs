using aoc.D14;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D14
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D14/ex.txt", 165)]
    [DataRow("./D14/input.txt", 17765746710228)]
    public void PartI(string path, long expected)
    {
      var list = Parser.Parse(path);
      var memory = new Emulator();

      var actual = memory.PartI(list);

      Assert.AreEqual(expected, actual);
    }

  }
}
