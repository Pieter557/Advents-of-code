using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day2 {
		public static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day2.txt");
			var stream = input.OpenText();
			int currentButton = 5;
			while (!stream.EndOfStream) {
				string s = stream.ReadLine();
				foreach (char c in s) {
					switch (c) {
						case 'L':
							switch (currentButton) {
								case 1: break;
								case 4: break;
								case 7: break;
								default:
									currentButton--;
									break;
							}
							break;
						case 'U':
							switch (currentButton) {
								case 1: break;
								case 2: break;
								case 3: break;
								default:
									currentButton -= 3;
									break;
							}
							break;
						case 'D':
							switch (currentButton) {
								case 7: break;
								case 8: break;
								case 9: break;
								default:
									currentButton += 3;
									break;
							}
							break;
						case 'R':
							switch (currentButton) {
								case 3: break;
								case 6: break;
								case 9: break;
								default:
									currentButton++;
									break;
							}
							break;
					}
				}
				Console.WriteLine(currentButton);
			}

		}
		public static void part2() {
			FileInfo input = new FileInfo(Program.dir + "day2.txt");
			var stream = input.OpenText();
			int[,] keypad = new int[,]
			{
				{ 0, 0, 1, 0 ,0 },
				{ 0, 2, 3, 4, 0 },
				{ 5, 6, 7, 8, 9 },
				{ 0, 10, 11, 12, 0 },
				{ 0, 0, 13, 0, 0 }
			};
			int y = 2;
			int x = 0;
			while (!stream.EndOfStream) {
				string s = stream.ReadLine();
				//s = "ULL";
				foreach (char c in s) {
					switch (c) {
						case 'L':
							if (x - 1 >= 0 && keypad[x - 1, y] != 0) {
								x = x - 1;
							}
							break;
						case 'R':
							if (x + 1 <= 4 && keypad[x + 1, y] != 0) {
								x = x + 1;
							}
							break;
						case 'D':
							if (y + 1 <= 4 && keypad[x, y + 1] != 0) {
								y = y + 1;
							}
							break;
						case 'U':
							if (y - 1 >= 0 && keypad[x, y - 1] != 0) {
								y = y - 1;
							}
							break;
					}
				}
				Console.WriteLine(keypad[y, x]);
			}
			Console.WriteLine();
		}

	}
}
