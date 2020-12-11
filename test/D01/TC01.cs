using aoc.D01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D01
{
  [TestClass]
  public class TC01
  {
    int[] input = Parser.Parse("./D01/input.txt");

    [TestMethod]
    public void Initial()
    {
      var expected = 514579;
      var input = new int[] {
                              1721,
                              979,
                              366,
                              299,
                              675,
                              1456
                            };

      var actual = Helper.Sum2(input);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void PartI()
    {
      var expected = 158916;

      var actual = Helper.Sum2(input);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void PartII()
    {
      var expected = 165795564;

      var actual = Helper.Sum3(input);

      Assert.AreEqual(expected, actual);
    }
  }
}
