using aoc.D05;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D05
{
	[TestClass]
	public class TC01
	{
		BoardingPass[] passes = Parser.Parse("./D05/input.txt");

		[TestMethod]
		public void InitialI()
		{
			var expected1 = 357;
			var expected2 = 567;
			var expected3 = 119;
			var expected4 = 820;

			var actual1 = new BoardingPass("FBFBBFFRLR").SeatID;
			var actual2 = new BoardingPass("BFFFBBFRRR").SeatID;
			var actual3 = new BoardingPass("FFFBBBFRRR").SeatID;
			var actual4 = new BoardingPass("BBFFBBFRLL").SeatID;

			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
			Assert.AreEqual(expected3, actual3);
			Assert.AreEqual(expected4, actual4);
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
