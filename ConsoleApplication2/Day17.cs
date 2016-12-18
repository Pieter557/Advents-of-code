using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day17 {
		internal static string input = "udskfozm";
		internal static char[] openChars = new char[] { 'b', 'c', 'd', 'e', 'f' };
		internal static int shortest = 0;
		internal static string shortestpath = string.Empty;
		internal static void part1() {
			//input = "ihgpwlah";
			coords current = new coords(0, 0);
			string path = string.Empty;
			move(path, current);
			Console.WriteLine(shortestpath.Length);
		}

		private static void move(string path, coords current) {
			/*if(path.Length > shortest) {
				return;
			}

			if(current.x == 3 && current.y == 3) {
				if (path.Length <= shortest) {
					Console.WriteLine(path);
					shortest = path.Length;
					shortestpath = path;
				}
				return;
			}*/
			if (current.x == 3 && current.y == 3) {
				if (path.Length >= shortest) {
					Console.WriteLine(path.Length);
					shortest = path.Length;
					shortestpath = path;
				}
				return;
			}
			string hash = md5hash(input + path).Substring(0, 4);
			if (isOpen(hash[0]) && current.y > 0) {
				move(path + "U", new coords(current.x, current.y - 1));
			}
			if (isOpen(hash[1]) && current.y < 3) {
				move(path + "D", new coords(current.x, current.y + 1));
			}
			if (isOpen(hash[2]) && current.x > 0) {
				move(path + "L", new coords(current.x - 1, current.y));
			}
			if (isOpen(hash[3]) && current.x < 3) {
				move(path + "R", new coords(current.x + 1, current.y));
			}

		}

		internal static string md5hash(string input) {
			StringBuilder hash = new StringBuilder();
			MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
			byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

			for (int i = 0; i < bytes.Length; i++) {
				hash.Append(bytes[i].ToString("x2"));
			}

			return hash.ToString();
		}
		internal static bool isOpen(char c) {
			if (openChars.Contains(c)) {
				return true;
			} else {
				return false;
			}
		}
	}
}
