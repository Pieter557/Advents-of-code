using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day1 {
		private static List<Tuple<int, int>> coords = new List<Tuple<int, int>>();
		private static int x = 0;
		private static int y = 0;
		public static void day1() {
			FileInfo input = new FileInfo(Program.dir + "day1.txt");
			string s = input.OpenText().ReadLine();
			//string s = "R8, R4, R4, R8";
			char direction = 'N';
			int blocksN = 0;
			int blocksE = 0;

			foreach (string b in s.Split(',')) {
				char side = (b.Trim())[0];
				int blocks = int.Parse(b.Trim().Substring(1));
				switch (side) {
					case 'L':
						switch (direction) {
							case 'N':
								direction = 'W';
								blocksE -= blocks;
								break;
							case 'W':
								direction = 'S';
								blocksN -= blocks;
								break;
							case 'S':
								direction = 'E';
								blocksE += blocks;
								break;
							case 'E':
								direction = 'N';
								blocksN += blocks;
								break;
						}
						break;
					case 'R':
						switch (direction) {
							case 'N':
								direction = 'E';
								blocksE += blocks;
								break;
							case 'W':
								direction = 'N';
								blocksN += blocks;
								break;
							case 'S':
								direction = 'W';
								blocksE -= blocks;
								break;
							case 'E':
								direction = 'S';
								blocksN -= blocks;
								break;
						}
						break;
				}
				move(direction, blocks);
			}
			Console.WriteLine(blocksN + blocksE);

		}
		private static void move(char direction, int blocks) {
			switch (direction) {
				case 'N':
					for (int i = 0; i < blocks; i++) {
						y++;
						Tuple<int, int> place = Tuple.Create(x, y);
						if (coords.Contains(place)) {
							Console.WriteLine("x = " + x + "\ny = " + y);
							return;
						} else {
							coords.Add(place);
						}
					}
					break;
				case 'S':
					for (int i = 0; i < blocks; i++) {
						y--;
						Tuple<int, int> place = Tuple.Create(x, y);
						if (coords.Contains(place)) {
							Console.WriteLine("x = " + x + "\ny = " + y);
							return;
						} else {
							coords.Add(place);
						}
					}
					break;
				case 'E':
					for (int i = 0; i < blocks; i++) {
						x++;
						Tuple<int, int> place = Tuple.Create(x, y);
						if (coords.Contains(place)) {
							Console.WriteLine("x = " + x + "\ny = " + y);
							return;
						} else {
							coords.Add(place);
						}
					}
					break;
				case 'W':
					for (int i = 0; i < blocks; i++) {
						x--;
						Tuple<int, int> place = Tuple.Create(x, y);
						if (coords.Contains(place)) {
							Console.WriteLine("x = " + x + "\ny = " + y);
							return;
						} else {
							coords.Add(place);
						}
					}
					break;

			}

		}
	}

}
