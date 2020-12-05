using System;
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
			var chunk = new List<string>();
			var chunks = new List<List<string>>();
			var result = new List<Passport>();

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

			foreach (var piece in chunks)
				result.Add(new Passport(ExtractFields(piece.ToArray())));		
			
			return result;
		}
	}
}
