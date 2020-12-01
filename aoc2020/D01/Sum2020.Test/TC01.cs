using D01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sum2020.Test
{
	[TestClass]
	public class TC01
	{
		[TestMethod]
		public void TestMethod1()
		{
			var input = new int[] {
															1721,
															979,
															366,
															299,
															675,
															1456
														};

			var expected = 514579;

			var actual = Helper.Sum2(input);

			Assert.AreEqual(expected, actual);
		}
	}
}
