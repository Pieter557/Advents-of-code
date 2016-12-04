using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day3 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day3.txt");
			var stream = input.OpenText();
			int countOfTriangles = 0;
			while (!stream.EndOfStream) {
				string[] s = stream.ReadLine().Trim().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
				//string[] s = new string[] { "5", "10", "25" };
				List<int> sides = new List<int>();
				sides.Add(int.Parse(s[0]));
				sides.Add(int.Parse(s[1]));
				sides.Add(int.Parse(s[2]));
				sides.Sort();
				if (sides[0] + sides[1] > sides[2]) {
					countOfTriangles++;
				}
			}
			Console.WriteLine(countOfTriangles);

		}
		internal static void part2() {
			FileInfo input = new FileInfo(Program.dir + "day3.txt");
			var stream = input.OpenText();
			int countOfTriangles = 0;
			while (!stream.EndOfStream) {
				List<int>[] sides = new List<int>[3];
				sides[0] = new List<int>();
				sides[1] = new List<int>();
				sides[2] = new List<int>();
				for (int i = 0; i < 3; i++) {
					string[] s = stream.ReadLine().Trim().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
					sides[0].Add(int.Parse(s[0]));
					sides[1].Add(int.Parse(s[1]));
					sides[2].Add(int.Parse(s[2]));
				}
				sides[0].Sort();
				sides[1].Sort();
				sides[2].Sort();
				if (sides[0][0] + sides[0][1] > sides[0][2]) {
					countOfTriangles++;
				}
				if (sides[1][0] + sides[1][1] > sides[1][2]) {
					countOfTriangles++;
				}
				if (sides[2][0] + sides[2][1] > sides[2][2]) {
					countOfTriangles++;
				}
			}
			Console.WriteLine(countOfTriangles);

		}
	}
}
