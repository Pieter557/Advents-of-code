using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day10 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day10.txt");
			var stream = input.OpenText();
			Dictionary<int, Bot> bots = new Dictionary<int, Bot>();
			while (!stream.EndOfStream) {
				string line = stream.ReadLine();
				string[] instr = line.Split();
				switch (instr[0]) {
					case "value":
						int botid = int.Parse(instr[5]);
						if (!bots.ContainsKey(botid)) {
							bots.Add(botid, new Bot(botid));
						}
						bots[botid].addChip(int.Parse(instr[1]));
						break;
					case "bot":
						Bot tmp = new Bot(int.Parse(instr[1]));

						int low = int.Parse(instr[6]);
						if (instr[5] == "output") low += 1000;
						if (!bots.ContainsKey(low)) {
							bots.Add(low, new Bot(low));
						}
						tmp.lowOut = bots[low];

						int high = int.Parse(instr[11]);
						if (instr[10] == "output") high += 1000;
						if (!bots.ContainsKey(high)) {
							bots.Add(high, new Bot(high));
						}
						tmp.highOut = bots[high];
						if (!bots.ContainsKey(tmp.botID)) {
							bots.Add(tmp.botID, tmp);
						} else {
							bots[tmp.botID].highOut = tmp.highOut;
							bots[tmp.botID].lowOut = tmp.lowOut;
						}
						break;
				}
			}
			while (!complete(bots)) {
				foreach (KeyValuePair<int, Bot> k in bots.Where(p => p.Value.chips.Count == 2 && p.Value.hasGiven == false)) {
					k.Value.highOut.addChip(k.Value.chips.Last().Key);
					k.Value.lowOut.addChip(k.Value.chips.First().Key);
					k.Value.hasGiven = true;
				}
			}
			Bot output = bots.Where(p => p.Value.chips.First().Key == 17 && p.Value.chips.Last().Key == 61).First().Value;
			Console.WriteLine(output.botID);

			Bot[] outputbin = bots.Where(p => p.Key == 1000 || p.Key == 1001 || p.Key == 1002).Select(b => b.Value).ToArray();
			int result = 1;
			foreach(Bot b in outputbin) {
				result = result * b.chips.First().Key;
			}
			Console.WriteLine(result);
		}

		private static bool complete(Dictionary<int, Bot> bots) {
			if (bots.Where(p => p.Value.chips.Count == 2 && p.Key < 1000).Count() == bots.Where(p => p.Key < 1000).Count()) {
				return true;
			} else {
				return false;
			}
		}
	}
	class Bot {
		public int botID { get; set; }
		public SortedList<int, int> chips { get; set; }
		public Bot lowOut { get; set; }
		public Bot highOut { get; set; }
		public bool hasGiven { get; set; }
		public Bot(int botID) {
			this.botID = botID;
			chips = new SortedList<int, int>();
		}
		public void addChip(int val) {
			chips.Add(val, 0);
		}

	}

}
