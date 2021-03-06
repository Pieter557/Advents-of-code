﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day23 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day23.txt");
			var stream = input.OpenText();
			List<string[]> commands = new List<string[]>();
			Dictionary<char, int> registers = new Dictionary<char, int>();
			while (!stream.EndOfStream) {
				commands.Add(stream.ReadLine().Split());
			}
			// Part2
			registers['a'] = 12;
			registers['b'] = 0;
			registers['c'] = 0;
			registers['d'] = 0;
			for (int i = 0; i < commands.Count; i++) {
				//Console.WriteLine("a: " + registers['a'] + " b: " + registers['b'] + " c: " + registers['c'] + " d: " + registers['d'] + "\t" + string.Join(" ", commands[i]));
				switch (commands[i][0]) {
					case "tgl":
						/*
						 *	For one-argument instructions, inc becomes dec, and all other one-argument instructions become inc.
							For two-argument instructions, jnz becomes cpy, and all other two-instructions become jnz.
							The arguments of a toggled instruction are not affected.
							If an attempt is made to toggle an instruction outside the program, nothing happens.
							If toggling produces an invalid instruction (like cpy 1 2) and an attempt is later made to execute that instruction, skip it instead.
							If tgl toggles itself (for example, if a is 0, tgl a would target itself and become inc a), the resulting instruction is not executed until the next time it is reached.

						 */
						int x;
						if (!int.TryParse(commands[i][1], out x)) {
							x = registers[commands[i][1][0]];
						}
						if (i+x < commands.Count) {
							if (commands[i + x].Length == 2) {
								if (commands[i + x][0] == "inc") {
									commands[i + x][0] = "dec";
								} else {
									commands[i + x][0] = "inc";
								}
							} else {
								if (commands[i + x][0] == "jnz") {
									commands[i + x][0] = "cpy";
								} else {
									commands[i + x][0] = "jnz";
								}
							} 
						}

						break;
					case "cpy":
						if (Char.IsLetter(commands[i][2][0])) {
							if (Char.IsLetter(commands[i][1][0])) {
								registers[commands[i][2][0]] = registers[commands[i][1][0]];
							} else {
								registers[commands[i][2][0]] = int.Parse(commands[i][1]);
							} 
						}
						break;
					case "inc":
						registers[commands[i][1][0]]++;
						break;
					case "dec":
						registers[commands[i][1][0]]--;
						break;
					case "jnz":
						// jnz x y  jumps to an instruction y away (positive means forward; negative means backward), but only if x is not zero.
						int a; // x
						int b; // y
						if(!int.TryParse(commands[i][1], out a)) {
							a = registers[commands[i][1][0]];
						}
						if (!int.TryParse(commands[i][2], out b)) {
							b = registers[commands[i][2][0]];
						}
						if(a != 0 && b != 0) {
							i += b - 1;
						}
						break;
				}
			}
			Console.WriteLine(registers['a']);
		}
	}
}
