using aoc.D02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D02
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    public void InitialI()
    {
      var expected = 2;
      var input = new Record[] {
                                 new Record(1, 3, 'a', "abcde"),
                                 new Record(1, 3, 'b', "cdefg"),
                                 new Record(2, 9, 'c', "ccccccccc"),
                              };

      var actual = Helper.CountValidsI(input);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void PartI()
    {
      var expected = 396;
      var input = Parser.Parse("./D02/input.txt");

      var actual = Helper.CountValidsI(input);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void InitialII()
    {
      var expected = 1;
      var input = new Record[] {
                                 new Record(1, 3, 'a', "abcde"),
                                 new Record(1, 3, 'b', "cdefg"),
                                 new Record(2, 9, 'c', "ccccccccc"),
                              };

      var actual = Helper.CountValidsII(input);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void PartII()
    {
      var expected = 428;
      var input = Parser.Parse("./D02/input.txt");

      var actual = Helper.CountValidsII(input);

      Assert.AreEqual(expected, actual);
    }
  }
}
