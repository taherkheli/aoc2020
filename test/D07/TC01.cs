using aoc.D07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace aoc.test.D07
{
	[TestClass]
	public class TC01
	{
		List<Bag> bags = Parser.Parse("./D07/input.txt");
		List<Bag> bags_ex1 = Parser.Parse("./D07/ex1.txt");
		List<Bag> bags_ex2 = Parser.Parse("./D07/ex2.txt");

		[TestMethod]
		public void InitialI()
		{
			var expected = 4;
			int count = 0;

			foreach (var bag in bags_ex1)
				if (bag.CanHoldShinyGoldBag(bags_ex1))
					count++;

			var actual = count;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartI()
		{
			var expected = 226;
			int count = 0;

			foreach (var bag in bags)
				if (bag.CanHoldShinyGoldBag(bags))
					count++;

			var actual = count;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InitialIIa()
		{
			var expected = 32;

			var bag = bags_ex1.Find(b => b.Color == "shiny gold");

			var actual = bag.TotalBagsNeeded(bags_ex1) - 1;  //excluding itself

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InitialIIb()
		{
			var expected = 126;
			List<Bag> bags_temp = Parser.Parse("./D07/ex2.txt");

			var bag = bags_ex2.Find(b => b.Color == "shiny gold");

			var actual = bag.TotalBagsNeeded(bags_ex2) - 1;  //excluding itself

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartII()
		{
			var expected = 9569;
			List<Bag> bags_temp = Parser.Parse("./D07/ex2.txt");

			var bag = bags.Find(b => b.Color == "shiny gold");

			var actual = bag.TotalBagsNeeded(bags) - 1;

			Assert.AreEqual(expected, actual);
		}
	}
}
