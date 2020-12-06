using System;
using System.Collections.Generic;

namespace aoc.Shared
{
	public static class Lib
	{
		public static List<List<string>> GetEmptyLineSeparatedChunks(string [] lines)
		{
			var chunks = new List<List<string>>();
			var chunk = new List<string>();		

			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i] == String.Empty)
				{
					chunks.Add(chunk);
					chunk = new List<string>();
				}
				else
				{
					chunk.Add(lines[i]);

					if (i == lines.Length - 1)
					{
						chunks.Add(chunk);
						chunk = null;
					}
				}
			}

			return chunks;
		}
	}
}
