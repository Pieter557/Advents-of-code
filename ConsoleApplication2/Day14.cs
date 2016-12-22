using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day14 {
		internal static string salt = "yjdafjpo";
		internal static int keysNeeded = 64;
		internal static void part1() {
			
			int keysfound = 0;
			Dictionary<int, string> hashes = createHashes();
			Regex r = new Regex(@"(.)\1\1");
			foreach (int i in hashes.Where(x => r.IsMatch(x.Value)).Select(x => x.Key)) {
				string triple = r.Match(hashes[i]).Value;
				//check if next 1000 hashes contain 5 times triple
				Regex r5 = new Regex(triple[0] + "{5}");
				List<int> triple5 = hashes.Where(x => x.Key > i && x.Key < i + 1000 && r5.IsMatch(x.Value)).Select(x => x.Key).ToList();
				if (triple5.Count > 0) {
					keysfound++;
					if (keysfound == keysNeeded) {
						Console.WriteLine(i);
					}
				}

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
		internal static Dictionary<int, string> createHashes() {
			Dictionary<int, string> hashes = new Dictionary<int, string>();
			FileInfo input = new FileInfo(Program.dir + "day14.txt");
			var stream = input.OpenText();
			while (!stream.EndOfStream) {
				string line = stream.ReadLine();
				hashes.Add(int.Parse(line.Split()[0]), line.Split()[1]);
			}
			stream.Close();
			if (hashes.Count == 0) {
				StreamWriter output = new StreamWriter(input.FullName);
				Console.WriteLine("Creating hashes");
				for (int i = 0; i < 50000; i++) {
					string hash = salt + i;
					for (int j = 0; j <= 2016; j++) {
						hash = md5hash(hash);
					}
					hashes.Add(i, hash);
					output.WriteLine(i + " " + hashes[i]);
					if(i % 1000 == 0) {
						Console.WriteLine("hash of i: " + i);
					}
				}
				output.Close();
				Console.WriteLine("Done hashing");
			}
			return hashes;
		}
	}
}
