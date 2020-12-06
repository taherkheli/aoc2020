using aoc.D06;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace aoc.test.D06
{
	[TestClass]
	public class TC01
	{
		List<Group> groupsExample = Parser.Parse("./D06/example.txt");
		List<Group> groupsInput = Parser.Parse("./D06/input.txt");

		[TestMethod]
		public void InitialI()
		{
			var expected = 11;

			var actual = Group.GetAnyoneAnsweredYesCount(groupsExample);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartI()
		{
			var expected = 6443;

			var actual = Group.GetAnyoneAnsweredYesCount(groupsInput);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InitialII()
		{
			var expected = 6;

			var actual = Group.GetEveryoneAnsweredYesCount(groupsExample);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartII()
		{
			var expected = 3232;

			var actual = Group.GetEveryoneAnsweredYesCount(groupsInput);

			Assert.AreEqual(expected, actual);
		}
	}
}
