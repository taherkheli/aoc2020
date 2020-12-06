using System.Collections.Generic;

namespace aoc.D06
{
	public class Group
	{
		List<HashSet<char>> _responses = new List<HashSet<char>>();

		public Group(string[] lines)
		{
			foreach (var line in lines)
				_responses.Add(new HashSet<char>(line));
		}

		public static int GetAnyoneAnsweredYesCount(IEnumerable<Group> groups)
		{
			int sum = 0;

			foreach (var group in groups)
				sum += group.AnyoneAnsweredYes();

			return sum;
		}

		public static int GetEveryoneAnsweredYesCount(IEnumerable<Group> groups)
		{
			int sum = 0;

			foreach (var group in groups)
				sum += group.EveryoneAnsweredYes();

			return sum;
		}

		private int AnyoneAnsweredYes()
		{
			var temp = new HashSet<char>();

			foreach (var r in _responses)
				temp.UnionWith(r);

			return temp.Count;
		}

		private int EveryoneAnsweredYes()
		{
			int indexLongest = -1;

			//find longest response index
			for (int i = 0; i < _responses.Count; i++)
			{
				if (_responses[i].Count > indexLongest)
					indexLongest = i;
			}

			var temp = new HashSet<char>(_responses[indexLongest]);

			foreach (var r in _responses)
				temp.IntersectWith(r);

			return temp.Count;
		}
	}
}