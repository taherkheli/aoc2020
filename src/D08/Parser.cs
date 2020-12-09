using System.Collections.Generic;
using System.IO;

namespace aoc.D08
{
	public class Parser
	{
		public static List<Instruction> Parse(string path)
		{
			var result = new List<Instruction>();
			var lines = File.ReadAllLines(path);

			foreach (var line in lines)
			{
				var s = line.Split(' ');

				var arg = int.Parse(s[1].Trim());
				var Op = Operation.Unknown;

				switch (s[0])
				{
					case "acc":
						Op = Operation.Accumulate;
						break;

					case "jmp":
						Op = Operation.Jump;
						break;

					case "nop":
						Op = Operation.NOP;
						break;

					default:
						break;
				}

				result.Add(new Instruction(Op, arg));
			}

			return result;
		}
	}
}
