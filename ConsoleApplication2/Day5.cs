using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day5 {
		internal static void part1() {
			string input = "ugkcyxxp";
			int charsfound = 0;
			int index = 0;
			string password = "";
			while(charsfound < 8) {
				string hash = md5hash(input+ index);
				if(hash.StartsWith("00000")) {
					password += hash[5];
					Console.WriteLine(hash);
					charsfound++;
				}
				index++;
			}
			Console.WriteLine(password);
		}
		internal static void part2() {
			string input = "ugkcyxxp";
			int index = 0;
			char[] password = "--------".ToCharArray();
			while (password.Contains('-')) {
				string hash = md5hash(input + index);
				if (hash.StartsWith("00000")) {
					if(hash[5] < '8') {
						int pos = int.Parse(hash[5].ToString());
						if (password[pos] == '-') {
							password[pos] = hash[6];
							Console.WriteLine(password);
						}
					}
					//Console.WriteLine(hash);
				}
				index++;
			}
			Console.WriteLine(password);
		}
		private static string md5hash(string input) {
			StringBuilder hash = new StringBuilder();
			MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
			byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

			for (int i = 0; i < bytes.Length; i++) {
				hash.Append(bytes[i].ToString("x2"));
			}
			return hash.ToString();
		}
	}
}
