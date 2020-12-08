using System.Collections.Generic;
using System.IO;

namespace aoc.D07
{
	public static class Parser
	{
		public static List<Bag> Parse(string path)
		{
			var result = new List<Bag>();
			var lines = File.ReadAllLines(path);

			foreach (var line in lines)
			{
				var subStrings = line.Split(' ');
				var bag = new Bag(subStrings[0] + " " + subStrings[1]);

				var s = line.Substring(line.IndexOf("contain") + 8);

				if (s != "no other bags.")
				{
					var pieces = s.Split(',');

					foreach (var piece in pieces)
					{
						var subStrings2 = piece.Trim().Split(' ');

						var num = int.Parse(subStrings2[0].ToString());
						var color = (subStrings2[1] + " " + subStrings2[2]);
						bag.Data.Add(color, num);
					}
				}

				result.Add(bag);
			}

			return result;
		}
	}
}
