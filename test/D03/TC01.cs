using aoc.D03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D03
{
	[TestClass]
	public class TC01
	{
		[TestMethod]
		public void InitialI()
		{
			var expected = 7;

			var g = new Grid("./D03/example.txt");

			var actual = g.TreesEncountered(3, 1);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartI()
		{
			var expected = 159;

			var g = new Grid("./D03/input.txt");

			var actual = g.TreesEncountered(3, 1);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InitialII()
		{
			var expected = 336;

			var g = new Grid("./D03/example.txt");

			long product = 1;
			product *= g.TreesEncountered(1, 1);
			g.reset();
			product *= g.TreesEncountered(3, 1);
			g.reset();
			product *= g.TreesEncountered(5, 1);
			g.reset();
			product *= g.TreesEncountered(7, 1);
			g.reset();
			product *= g.TreesEncountered(1, 2);
			var actual = product;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartII()
		{
			var expected = 6419669520;

			var g = new Grid("./D03/input.txt");

			long product = 1;
			product *= g.TreesEncountered(1, 1);
			g.reset();
			product *= g.TreesEncountered(3, 1);
			g.reset();
			product *= g.TreesEncountered(5, 1);
			g.reset();
			product *= g.TreesEncountered(7, 1);
			g.reset();
			product *= g.TreesEncountered(1, 2);
			var actual = product;

			Assert.AreEqual(expected, actual);
		}
	}
}
