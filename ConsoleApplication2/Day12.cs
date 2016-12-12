using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApplication2 {
	class Day12 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day12.txt");
			var stream = input.OpenText();
			List<string> commands = new List<string>();
			Dictionary<char, int> registers = new Dictionary<char, int>();
			while (!stream.EndOfStream) {
				commands.Add(stream.ReadLine());
			}
			// Part2
			registers['c'] = 1;
			for (int i = 0; i < commands.Count; i++) {
				string[] cmd = commands[i].Split();
				switch (cmd[0]) {
					case "cpy":
						if (Char.IsLetter(cmd[1][0])) {
							registers[cmd[2][0]] = registers[cmd[1][0]];
						} else {
							registers[cmd[2][0]] = int.Parse(cmd[1]);
						}
						break;
					case "inc":
						registers[cmd[1][0]]++;
						break;
					case "dec":
						registers[cmd[1][0]]--;
						break;
					case "jnz":
						if ((Char.IsLetter(cmd[1][0]) && registers.ContainsKey(cmd[1][0]) && registers[cmd[1][0]] != 0) || (Char.IsDigit(cmd[1][0]) && int.Parse(cmd[1]) != 0)) {
							i += int.Parse(cmd[2]) - 1;
						}
						break;
				}
			}
			Console.WriteLine(registers['a']);
		}
	}
}
