using System;
using System.IO;

namespace aoc.D02
{
	public static class Parser
	{
		public static Record[] Parse(string path) 
		{
			int min = -1;
			int max = -1;
			char c = ' ';
			string value = "";

			var lines = File.ReadAllLines(path);
			var records = new Record[lines.Length];

			for (var i = 0; i < lines.Length; i++)
			{
				var s = lines[i].Split(' ');

				c = s[1].Trim().Trim(':').ToCharArray()[0];

				value = s[2].Trim();

				s = s[0].Trim().Split('-');
				min = Int32.Parse(s[0]);
				max = Int32.Parse(s[1]);

				records[i] = new Record(min, max, c, value);
			}

			return records;
		}
	}
}
