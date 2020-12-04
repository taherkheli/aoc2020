using aoc.D04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace aoc.test.D04
{
	[TestClass]
	public class TC01
	{
		[TestMethod]
		public void InitialI()
		{
			var expected = 2;

			var passports = Parser.Parse("./D04/ex1.txt");
			int count = 0;

			foreach (var p in passports)
				if (p.ValidatePartI())
					count++;

			var actual = count;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartI()
		{
			var expected = 170;

			var passports = Parser.Parse("./D04/input.txt");
			int count = 0;

			foreach (var p in passports)
				if (p.ValidatePartI())
					count++;

			var actual = count;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InitialII()
		{
			var expected = 4;

			var passports = Parser.Parse("./D04/ex2.txt");
			int count = 0;

			foreach (var p in passports)
				if (p.ValidatePartII())
					count++;

			var actual = count;

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PartII()
		{
			var expected = 103;

			var passports = Parser.Parse("./D04/input.txt");
			int count = 0;

			foreach (var p in passports)
				if (p.ValidatePartII())
					count++;

			var actual = count;

			Assert.AreEqual(expected, actual);		
		}
	}
}
