using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day15 {
		internal static void part1() {
			FileInfo input = new FileInfo(Program.dir + "day15.txt");
			var stream = input.OpenText();
			List<Disk> disks = new List<Disk>();
			while (!stream.EndOfStream) {
				string line = stream.ReadLine();
				var s = line.Split();
				Disk d = new Disk(int.Parse(s[1][1].ToString()), int.Parse(s[3]), int.Parse(s[11].TrimEnd('.')));
				disks.Add(d);
			}
			//part2
			disks.Add(new Disk(disks.Count + 1, 11, 0));
			bool running = true;
			int time = 0;
			while (running) {
				foreach(Disk d in disks) {
					int t = time;
					if (d.isGoodPosition(t)) {
						t++;
						if(d.disk == disks.Count) {
							running = false;
							Console.WriteLine(time);
						}
					} else {
						break;
					}
				}
				time++;
			
			}
		}

		private static bool testDisks(List<Disk> disks) {
			var tmp = disks;

			return testDisks(tmp);
		}
	}
	class Disk {
		public int disk;
		public int positions;
		public int currentPostion;

		public Disk(int disk, int positions, int currentPosition) {
			this.disk = disk;
			this.positions = positions;
			this.currentPostion = currentPosition;
		}

		internal bool isGoodPosition(int time) {
			return (currentPostion + disk + time) % positions == 0;
		}

	}
}
