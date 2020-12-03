namespace aoc.D02
{
	public struct Record
	{
		public int min;
		public int max;
		public char character;
		public string value;

		public Record(int min, int max, char c, string value)
		{
			this.min = min;
			this.max = max;
			this.character = c;
			this.value = value;
		}
	}
}
