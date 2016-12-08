﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day8 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day8.txt");
			var stream = input.OpenText();
			bool[,] seq = new bool[6, 50];
			int pixels = 0;
			while (!stream.EndOfStream) {
				List<string> operation = stream.ReadLine().Split().ToList();
				switch (operation[0]) {
					case "rect":
						// create rectangle:
						int x = int.Parse(operation[1].Split('x')[0].ToString());
						int y = int.Parse(operation[1].Split('x')[1].ToString());
						for (int i = 0; i < x; i++) {
							for (int j = 0; j < y; j++) {
								seq[j,i] = true;
							}
						}
						break;
					case "rotate":
						switch (operation[1]) {
							case "column":
								int column = int.Parse(operation[2].Split('=')[1].ToString());
								int amountc = int.Parse(operation[4].ToString());
								bool[] tmp = new bool[6];
								for (int i = 0; i < 6; i++) {
									tmp[(i + amountc) % tmp.Length] = seq[i, column];
								}
								for (int i = 0; i < 6; i++) {
									seq[i, column] = tmp[i];
								}
								break;
							case "row":
								int row = int.Parse(operation[2].Split('=')[1].ToString());
								int amountr = int.Parse(operation[4].ToString());
								bool[] tmpr = new bool[50];
								for (int i = 0; i < 50; i++) {
									tmpr[(i + amountr) % tmpr.Length] = seq[row, i];
								}
								for (int i = 0; i < 50; i++) {
									seq[row, i] = tmpr[i];
								}
								break;

						}
						break;

				}
			}
			for (int i = 0; i < 6; i++) {
				for (int j = 0; j < 50; j++) {
					if (seq[i, j]) {
						Console.Write('#');
						pixels++;
					} else {
						Console.Write(' ');
					}
				}
				Console.Write("\n");
			}
			Console.WriteLine(pixels);
		}

	}
}
