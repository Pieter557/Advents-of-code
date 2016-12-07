using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day7 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day7.txt");
			var stream = input.OpenText();
			int validAddresses = 0;
			while (!stream.EndOfStream) {
				//IPV7 ip = new IPV7("aba[bab]xyz");
				IPV7 ip = new IPV7(stream.ReadLine());
				if (ip.supportsSSL()) {
					validAddresses++;
				}
			}
			Console.WriteLine(validAddresses);
		}

	}
	class IPV7 {
		public List<char> Outside { get; set; }
		public List<char> Inside { get; set; }
		public string input { get; set; }
		public IPV7(string input) {
			this.input = input;
		}

		internal bool supportsTLS() {
			bool inside = false;
			bool supportsTLS = false;
			for (int i = 0; i < input.Length - 3; i++) {
				if (input[i + 3] == '[') {
					inside = true;
					i += 3;
				} else if (input[i + 3] == ']') {
					inside = false;
					i += 3;
				} else if (inside == false && input[i] != input[i + 1] && input[i] == input[i + 3] && input[i + 1] == input[i + 2]) {
					supportsTLS = true;
				} else if (inside == true && input[i] != input[i + 1] && input[i] == input[i + 3] && input[i + 1] == input[i + 2]) {
					supportsTLS = false;
					break;
				}

			}
			return supportsTLS;

		}
		internal bool supportsSSL() {
			bool supportsSSL = false;
			List<string> split = input.Split(new char[] { '[', ']' }).ToList(); // even is outside, odd is inside hypernetthingy
			for (int i = 0; i < split.Count; i += 2) {
				for (int j = 0; j < split[i].Length - 2; j++) {
					if (split[i][j] != split[i][j + 1] && split[i][j] == split[i][j + 2]) {
						for (int k = 1; k < split.Count; k += 2) {
							for (int l = 0; l < split[k].Length - 2; l++) {
								if (split[k][l] != split[k][l + 1] && split[k][l] == split[k][l + 2] && split[k][l] == split[i][j + 1] && split[k][l + 1] == split[i][j]) {
									return true;
								}

							}
						}
					}
				}
			}
			return supportsSSL;
		}
	}
}