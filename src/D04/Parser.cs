using aoc.Shared;
using System.Collections.Generic;
using System.IO;

namespace aoc.D04
{
	public static class Parser
	{
		private static Dictionary<string, string> ExtractFields(string[] chunk)
		{
			var fields = new Dictionary<string, string>();

			foreach (var line in chunk)
			{
				var s1Array = line.Trim().Split(' ');

				foreach (var s in s1Array)
				{
					var s2Array = s.Trim().Split(':');
					fields.Add(s2Array[0], s2Array[1]);
				}
			}

			return fields;
		}

		public static List<Passport> Parse(string path)
		{
			var lines = File.ReadAllLines(path);
			var result = new List<Passport>();
			var chunks = Lib.GetEmptyLineSeparatedChunks(lines);

			foreach (var chunk in chunks)
				result.Add(new Passport(ExtractFields(chunk.ToArray())));

			return result;
		}
	}
}
