using System;
using System.IO;

namespace D01
{
	class Program
	{
		static void Main()
		{
			var lines = File.ReadAllLines("input.txt");
			var numbers = new int[lines.Length];

			for (var i = 0; i < lines.Length; i++)
				numbers[i] = int.Parse(lines[i].Trim());

			Console.WriteLine("Part I: \n{0}\n", Helper.Sum2(numbers));
			Console.WriteLine("Part II: \n{0}\n", Helper.Sum3(numbers));
		}
	}
}
