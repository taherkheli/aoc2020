namespace aoc.D02
{
	public static class Helper
	{
		public static int CountValidsI(Record[] records)
		{
			int count = 0;

			for (int i = 0; i < records.Length; i++)
			{
				var r = records[i];
				var occurences = CountOccurences(r.value, r.character);

				if ((occurences > r.min - 1)  && (occurences < r.max + 1))
					count++;
			}

			return count;
		}

		public static int CountValidsII(Record[] records)
		{
			int count = 0;

			for (int i = 0; i < records.Length; i++)
			{
				var r = records[i];
				var p1 = r.min - 1;
				var p2 = r.max - 1;

				if((r.value[p1] == r.character) ^ (r.value[p2] == r.character))
					count++;
			}

			return count;
		}

		private static int CountOccurences(string s, char c)
		{
			int count = s.Length - s.Replace(c.ToString(), "").Length;

			return count;
		} 
	}
}
