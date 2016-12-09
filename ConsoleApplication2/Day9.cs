using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day9 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day9.txt");
			StringBuilder sb = new StringBuilder();
			string data = input.OpenText().ReadLine();
			//data = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";
			string output = string.Empty;
			Int64 chars = 0;
			do {
				if (output.Length > 0) {
					int i = 0;
					while (Char.IsLetter(output[i])) {
						chars++;
						i++;
					}
					data = output.Substring(i);
					sb = new StringBuilder();
				}
				for (int i = 0; i < data.Length;) {
					if (data[i] == '(') {
						int t = i + 1;
						string letterstring = string.Empty;
						while (Char.IsDigit(data[t])) {
							letterstring += data[t];
							t++;
						}
						int letters = int.Parse(letterstring);
						t++; // skip x
						string amountstring = string.Empty;
						while (Char.IsDigit(data[t])) {
							amountstring += data[t];
							t++;
						}
						int amount = int.Parse(amountstring);
						t += 1; // should be first character to decompress
						for (int j = amount; j > 0; j--) {
							sb.Append(data.Substring(t, letters));
						}
						i = t + letters;
					} else {
						sb.Append(data[i++]);
					}
				}
				output = sb.ToString();
				Console.WriteLine(output.Length);
			} while (output.Contains('('));
			Console.WriteLine(chars);
		}
		internal static void part2() {
			FileInfo input = new FileInfo(Program.dir + "day9.txt");
			StringBuilder sb = new StringBuilder();
			string data = input.OpenText().ReadLine();
			//data = "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN";
			long chars = solve(data) ;
			 
			Console.WriteLine(chars);
		}

		private static long solve(string data) { // shameless copy from intel. 
			if (!data.Contains('(')) {
				return data.Length;
			}
			int firstOpenBracket = data.IndexOf('(');
			int firstClosingBracket = data.IndexOf(')');
			long outputlength = firstOpenBracket;
			string[] marker = data.Substring(firstOpenBracket+1, firstClosingBracket - firstOpenBracket-1).Split('x');
			long subOutputLenght = solve(data.Substring(firstClosingBracket + 1, int.Parse(marker[0])));
			outputlength += int.Parse(marker[1]) * subOutputLenght;
			return outputlength + solve(data.Substring(firstClosingBracket + int.Parse(marker[0]) + 1));
			
		}
	}
}
