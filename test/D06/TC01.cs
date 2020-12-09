using aoc.D06;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D06
{
	[TestClass]
	public class TC01
	{
		[TestMethod]
		[DataRow("./D06/ex.txt", 11)]
		[DataRow("./D06/input.txt", 6443)]
		public void PartI(string path, int expected)
		{
			var groups = Parser.Parse(path);

			var actual = Group.GetAnyoneAnsweredYesCount(groups);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[DataRow("./D06/ex.txt", 6)]
		[DataRow("./D06/input.txt", 3232)]
		public void PartII(string path, int expected)
		{
			var groups = Parser.Parse(path);

			var actual = Group.GetEveryoneAnsweredYesCount(groups);

			Assert.AreEqual(expected, actual);
		}
	}
}
