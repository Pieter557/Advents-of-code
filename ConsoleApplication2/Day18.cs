using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day18 {
		internal static string input = ".^^..^...^..^^.^^^.^^^.^^^^^^.^.^^^^.^^.^^^^^^.^...^......^...^^^..^^^.....^^^^^^^^^....^^...^^^^..^";
		internal static int rowlength;
		internal static int rows = 400000;
		internal static List<bool> tiles = new List<bool>(); // true = trap; false = safe
		internal static void part1() {
			//input = ".^^.^.^^^^";
			foreach (char c in input) {
				if (c == '.') {
					tiles.Add(false);
				} else {
					tiles.Add(true);
				}
			}
			int currentrow = 0;
			rowlength = input.Length;
			while (currentrow < rows - 1) {
				for (int i = 0; i < input.Length; i++) {
					bool left, center, right;
					if (i == 0) { // first tile on row
						left = false;
						center = tiles[i + currentrow * rowlength];
						right = tiles[i + 1 + currentrow * rowlength];
					} else if (i == input.Length - 1) { // last tile on row
						left = tiles[i - 1 + currentrow * rowlength];
						center = tiles[i + currentrow * rowlength];
						right = false;
					} else {
						left = tiles[i - 1 + currentrow * rowlength];
						center = tiles[i + currentrow * rowlength];
						right = tiles[i + 1 + currentrow * rowlength];
					}
					tiles.Add(isTrap(left, center, right));

				}
				currentrow++;
			}
			//printmap();
			Console.WriteLine(tiles.Count(x => x == false));
		}

		private static void printmap() {
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < input.Length; j++) {
					Console.Write(tiles[j + i * input.Length] ? '^' : '.');
				}
				Console.Write("\n");
			}
		}

		private static bool isTrap(bool left, bool center, bool right) {
			if ((left && center && !right) || (!left && center && right) || (left && !center && !right) || (!left && !center && right)) {
				return true;
			} else {
				return false;
			}
		}
	}
}
