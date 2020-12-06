using aoc.Shared;
using System.Collections.Generic;
using System.IO;

namespace aoc.D06
{
	public static class Parser
	{	
		public static List<Group> Parse(string path)
		{
			var lines = File.ReadAllLines(path);
			var result = new List<Group>();
			var chunks = Lib.GetEmptyLineSeparatedChunks(lines);

			foreach (var chunk in chunks)
				result.Add(new Group(chunk.ToArray()));

			return result;
		}
	}
}
