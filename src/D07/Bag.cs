using System.Collections.Generic;

namespace aoc.D07
{
	public class Bag
	{
		private string _color;
		private Dictionary<string, int> _table;

		public Bag(string color)
		{
			_color = color;
			_table = new Dictionary<string, int>();
		}

		public string Color { get { return _color; } }

		public Dictionary<string, int> Table { get { return _table; } }


		public bool CanHoldShinyGoldBag(List<Bag> list)
		{
			bool result = false;
			int value = -1;

			if (_table.Count != 0) //no bags
			{
				if (_table.TryGetValue("shiny gold", out value)) //child
					result = true;
				else //descendent
				{
					foreach (var entry in _table)
					{
						var tempBag = list.Find(b => b.Color == entry.Key);

						if (tempBag.CanHoldShinyGoldBag(list))
						{
							result = true;
							break;
						}
					}
				}
			}

			return result;
		}

		public int TotalBagsNeeded(List<Bag> list)
		{
			int result = 1;  //itself
			
			if (_table.Count != 0) //descendents
			{
				foreach (var entry in _table)
				{
					var num = entry.Value;
					var tempBag = list.Find(b => b.Color == entry.Key);
					var insideIt = tempBag.TotalBagsNeeded(list);

					result += (num * insideIt);
				}
			}

			return result;
		}
	}
}
