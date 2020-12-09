using aoc.D05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D05
{
	[TestClass]
	public class TC01
	{
		BoardingPass[] passes = Parser.Parse("./D05/input.txt");

		[TestMethod]
		[DataRow("FBFBBFFRLR", 357)]
		[DataRow("BFFFBBFRRR", 567)]
		[DataRow("FFFBBBFRRR", 119)]
		[DataRow("BBFFBBFRLL", 820)]
		public void Initial(string code, int expected)
		{
			var actual = new BoardingPass(code).SeatID;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartI()
		{
			var expected = 858;

			var actual = BoardingPass.PartI(passes);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartII()
		{
			var expected = 557;

			var actual = BoardingPass.PartII(passes);

			Assert.AreEqual(expected, actual);
		}
	}
}
