using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day6 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day6.txt");
			var stream = input.OpenText();
			List<char>[] chars = new List<char>[8];
			for(int i = 0; i < 8; i++) {
				chars[i] = new List<char>();
			}
			while (!stream.EndOfStream) {
				string s = stream.ReadLine();
				for(int i = 0; i < 8; i++) {
					chars[i].Add(s[i]);
				}
			}
			for (int i = 0; i < 8; i++) {
				Console.Write(chars[i].GroupBy(c => c).Select(x => new { x.Key, count = x.Count() }).OrderByDescending(x => x.count).Take(1).Select(c => c.Key).ToList()[0]);
			}
		}
		internal static void part2() {
			FileInfo input = new FileInfo(Program.dir + "day6.txt");
			var stream = input.OpenText();
			List<char>[] chars = new List<char>[8];
			for (int i = 0; i < 8; i++) {
				chars[i] = new List<char>();
			}
			while (!stream.EndOfStream) {
				string s = stream.ReadLine();
				for (int i = 0; i < 8; i++) {
					chars[i].Add(s[i]);
				}
			}
			for (int i = 0; i < 8; i++) {
				Console.Write(chars[i].GroupBy(c => c).Select(x => new { x.Key, count = x.Count() }).OrderBy(x => x.count).Take(1).Select(c => c.Key).ToList()[0]);
			}
		}
	}
}
