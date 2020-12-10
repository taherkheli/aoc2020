using System.Collections.Generic;
using System.IO;

namespace aoc.D09
{
	public class XMAS
	{
		private readonly int _preamble;
		private readonly long[] _backup;
		private Queue<long> _queue;
		private List<long> _inputs;

		public XMAS(string path, int preamble)
		{
			_preamble = preamble;
			var lines = File.ReadAllLines(path);
			_backup = new long[lines.Length];

			for (int i = 0; i < lines.Length; i++)
				_backup[i] = long.Parse(lines[i].Trim());		

			Reset();
		}

		public long PartI()
		{
			long result = long.MinValue;

			foreach (var input in _inputs)
			{
				if (!MeetsCriteria(input))
				{
					result = input;
					break;
				}
				else
				{
					_queue.Dequeue();
					_queue.Enqueue(input);
				}
			}

			Reset();
			return result;
		}

		public long PartII(long num)
		{
			long result = long.MinValue;
			bool success = false;
			List<long> sequence = null;

			for (int i = 0; i < _backup.Length - 1; i++)
			{
				sequence = new List<long>();
				sequence.Add(_backup[i]);
				long sum = _backup[i];

				for (int j = i + 1; j < _backup.Length; j++)
				{
					sequence.Add(_backup[j]);
					sum += _backup[j];

					if (sum > num) //drop n start next inner iteration					
						break;

					if (sum == num)
					{
						success = true;
						break; //drop n communicate success to outer loop
					}
				}

				if (success)
				{
					result = GetLargest(sequence) + GetSmallest(sequence);
					break;
				}
			}
			return result; ;
		}

		private void Reset()
		{
			_queue = new Queue<long>();
			_inputs = new List<long>();

			for (int i = 0; i < _backup.Length; i++)
			{
				if (i < _preamble)
					_queue.Enqueue(_backup[i]);
				else
					_inputs.Add(_backup[i]);
			}
		}

		private bool MeetsCriteria(long num)
		{
			bool valid = false;
			var a = _queue.ToArray();

			for (int i = 0; i < a.Length - 1; i++)
			{
				for (int j = i+1; j < a.Length; j++)
				{
					if (a[i] != a[j])
					{
						if (a[i] + a[j] == num)
						{
							valid = true;
							break;
						}
					}
				}
			}

			return valid;
		}

		private long GetLargest(List<long> list)
		{
			long largest = long.MinValue;

			foreach (var n in list)
				if (n > largest)
					largest = n;

			return largest;
		}

		private long GetSmallest(List<long> list)
		{
			long smallest = long.MaxValue;

			foreach (var n in list)
				if (n < smallest)
					smallest = n;

			return smallest;
		}
	}
}
