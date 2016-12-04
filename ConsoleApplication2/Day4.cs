using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day4 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day4.txt");
			var stream = input.OpenText();
			int sum = 0;
			while (!stream.EndOfStream) {
				Room r = new Room(stream.ReadLine());
				//Room r = new Room("aaaaa-bbb-z-y-x-123[abxyz]");
				if (r.isRealRoom()) {
					sum += r.sectorID;
					if (r.decrypt().ToLower().Contains("north")) {
						Console.WriteLine(r.decrypt());
						Console.WriteLine(r.sectorID);
					}
				}
			}
			Console.WriteLine(sum);
		}
	}
	class Room {
		public string s { get; set; }
		public string encryptedName { get; set; }
		public int sectorID { get; set; }
		public string checksum { get; set; }

		public Room(String s) {
			this.s = s;
			string pattern = @"(.+)-(\d+)\[(.+)\]";
			Regex r1 = new Regex(pattern);
			Match m1 = r1.Match(s);
			if (m1.Success) {
				encryptedName = m1.Groups[1].Value;
				sectorID = int.Parse(m1.Groups[2].Value);
				checksum = m1.Groups[3].Value;
			}
		}

		internal bool isRealRoom() {
			var letters = encryptedName.Where(c => c != '-').GroupBy(c => c).Select(x => new { x.Key, count = x.Count() }).OrderByDescending(x => x.count).ThenBy(x => x.Key).Take(5);
			char [] top5 = letters.Select(x => x.Key).ToArray();
			bool isreal = (new string(top5)).Equals(checksum);
			return isreal;
		}
		internal string decrypt() {
			var name = encryptedName.Replace('-', ' ').ToCharArray();
			for(int i = 0; i < encryptedName.Length; i++) {
				for(int a = 0; a < sectorID % 26; a++) {
					if(name[i] != ' ') {
						if(name[i] == 'z') {
							name[i] = 'a'; 
						} else {
							name[i] = (char)(name[i] + 1);
						}
					}
				}
			}
			return new string(name);
		}
	}
}
