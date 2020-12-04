using System.Collections.Generic;

namespace aoc.D04
{
	public class Passport
	{
		private Dictionary<string, string> _fields;

		public Passport(Dictionary<string, string> fields)
		{
			_fields = fields;
		}

		private Dictionary<string, string> Fields { get { return _fields; } }

		public bool ValidatePartI()
		{
			string value;

			if (!_fields.TryGetValue("byr", out value))
				return false;

			if (!_fields.TryGetValue("iyr", out value))
				return false;

			if (!_fields.TryGetValue("eyr", out value))
				return false;

			if (!_fields.TryGetValue("hgt", out value))
				return false;

			if (!_fields.TryGetValue("hcl", out value))
				return false;

			if (!_fields.TryGetValue("ecl", out value))
				return false;

			if (!_fields.TryGetValue("pid", out value))
				return false;

			return true;
		}

		public bool ValidatePartII()
		{
			if (!ValidateBYR())
				return false;

			if (!ValidateIYR())
				return false;

			if (!ValidateEYR())
				return false;

			if (!ValidateHGT())
				return false;

			if (!ValidateHCL())
				return false;

			if (!ValidateECL())
				return false;

			if (!ValidatePID())
				return false;

			if (!ValidateCID())
				return false;

			return true;
		}

		private bool ValidateBYR()
		{
			string value;
			bool result = false;

			if (_fields.TryGetValue("byr", out value))  //present
			{
				//valid
				if ((value.Length == 4) &&
						 (int.Parse(value) > 1919) &&
						 (int.Parse(value) < 2003))
				{
					result = true;
				}
			}

			return result;
		}

		private bool ValidateIYR()
		{
			string value;
			bool result = false;

			if (_fields.TryGetValue("iyr", out value)) 
			{
				if ((value.Length == 4) &&
						 (int.Parse(value) > 2009) &&
						 (int.Parse(value) < 2021))
				{
					result = true;
				}
			}

			return result;
		}

		private bool ValidateEYR()
		{
			string value;
			bool result = false;

			if (_fields.TryGetValue("eyr", out value))  //present
			{
				//valid
				if ((value.Length == 4) &&
						 (int.Parse(value) > 2019) &&
						 (int.Parse(value) < 2031))
				{
					result = true;
				}
			}

			return result;
		}

		private bool ValidateHGT()
		{
			string value;
			int num;
			bool result = false;

			if (_fields.TryGetValue("hgt", out value))  //present
			{
				var unit = value.Substring(value.Length - 2);

				switch (unit)
				{
					case "cm":
						num = int.Parse(value.Substring(0, value.Length - 2));
						if ((num > 149) && (num < 194))
							result = true;						
						break;

					case "in":
						num = int.Parse(value.Substring(0, value.Length - 2));
						if ((num > 58) && (num < 77))
							result = true;
						break;

					default:
						break;
				}
			}

			return result;
		}

		private bool ValidateHCL()
		{
			string value;
			bool result = false;

			if (_fields.TryGetValue("hcl", out value)) 
			{
				if ((value.Length == 7) &&
						(value[0] == '#') &&
						(HasValidHexChars(value.Substring(1))))
				{
					result = true;
				}
			}

			return result;
		}

		private bool ValidateECL()
		{
			var validColors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

			string value;
			bool result = false;

			if (_fields.TryGetValue("ecl", out value))  //present
			{
				if (validColors.Contains(value))
					result = true;
			}

			return result;
		}

		private bool ValidatePID()
		{
			string value;
			int num;
			bool result = false;

			if (_fields.TryGetValue("pid", out value))  //present
			{
				if (value.Length == 9)
				{					
					result = int.TryParse(value, out num);
				}
			}

			return result;
		}

		private bool ValidateCID()
		{
			return true;
		}

		private bool HasValidHexChars(string s)
		{
			var hexValues = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
			bool result = true;

			for (int i = 0; i < s.Length; i++)
			{
				if (!hexValues.Contains(s[i]))
				{
					result = false;
					break;
				}
			}

			return result;
		}
	}
}
