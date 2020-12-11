using aoc.D07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace aoc.test.D07
{
  [TestClass]
  public class TC01
  {
    [TestMethod]
    [DataRow("./D07/ex1.txt", 4)]
    [DataRow("./D07/input.txt", 226)]
    public void PartI(string path, int expected)
    {
      List<Bag> bags = Parser.Parse(path);
      int actual = 0;

      foreach (var bag in bags)
        if (bag.CanHoldShinyGoldBag(bags))
          actual++;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("./D07/ex1.txt", 32)]
    [DataRow("./D07/ex2.txt", 126)]
    [DataRow("./D07/input.txt", 9569)]
    public void PartII(string path, int expected)
    {
      List<Bag> bags = Parser.Parse(path);

      var bag = bags.Find(b => b.Color == "shiny gold");

      var actual = bag.TotalBagsNeeded(bags) - 1;  //excluding itself

      Assert.AreEqual(expected, actual);
    }
  }
}
