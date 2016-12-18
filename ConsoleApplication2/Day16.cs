using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day16 {
		internal static string input = "11101000110010100";
		internal static int disksize = 35651584;
		internal static void part1() {
			string a = input;
			while (a.Length < disksize) {
				string b = invert(reverse(a));
				a = a + "0" + b;
			}
			var bits = a.Substring(0, disksize).ToList(); ;
			List<char> checksum = new List<char>();
			while (checksum.Count % 2 == 0) {
				checksum.Clear();
				for (int i = 0; i < bits.Count; i += 2) {
					if (bits[i] == bits[i + 1]) {
						checksum.Add('1');
					} else {
						checksum.Add('0');
					}
				}
				bits.Clear();
				bits.AddRange(checksum);
			}
			foreach(char c in checksum) {
				Console.Write(c);
			}

		}
		internal static string invert(string s) {
			return new string(s.Select(c => c == '1' ? '0' : '1').ToArray());
		}
		internal static string reverse(string s) {
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

	}
}

