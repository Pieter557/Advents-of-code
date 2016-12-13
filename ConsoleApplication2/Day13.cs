using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day13 {
		internal static int input = 1358;
		internal static int targetx = 31;
		internal static int targety = 39;

		internal static void part1() {
			Queue<coords> toVisit = new Queue<coords>();
			Dictionary<coords, int> visitedCoords = new Dictionary<coords, int>();
			visitedCoords.Add(new coords(1, 1), 0);
			toVisit.Enqueue(new coords(1, 1));
			while (toVisit.Count > 0) {
				coords c = toVisit.Dequeue();
				if (c.x == targetx && c.y == targety) {
					Console.WriteLine(visitedCoords[c]);
					return;
				}
				foreach (coords d in adjecentSquares(c)) {
					if (visitedCoords.ContainsKey(d)) {
						continue;
					}
					toVisit.Enqueue(d);
					visitedCoords.Add(d, visitedCoords[c] + 1);
				}
			}
		}
		internal static void part2() {
			Queue<coords> toVisit = new Queue<coords>();
			Dictionary<coords, int> visitedCoords = new Dictionary<coords, int>();
			List<coords> visited = new List<coords>();
			visitedCoords.Add(new coords(1, 1), 0);
			toVisit.Enqueue(new coords(1, 1));
			while (toVisit.Count > 0) {
				coords c = toVisit.Dequeue();

				foreach (coords d in adjecentSquares(c)) {
					if (visited.Contains(d)) {
						continue;
					}
					toVisit.Enqueue(d);
					visited.Add(d);
					if(visitedCoords.ContainsKey(c) && !visitedCoords.ContainsKey(d) && visitedCoords[c] < 50)
						visitedCoords.Add(d, visitedCoords[c] + 1);

				}
			}
			Console.WriteLine(visitedCoords.Count(x => x.Value < 51));
		}
		internal static bool isOpenSpace(int x, int y) {
			if (x < 0 || y < 0) {
				return false;
			}
			int sum = x * x + 3 * x + 2 * x * y + y + y * y + input;
			bool isOpenSpace = true;
			while (sum != 0) {
				isOpenSpace = !isOpenSpace;
				sum &= sum - 1;
			}
			return isOpenSpace;
		}
		internal static List<coords> adjecentSquares(coords c) {
			List<coords> adjSquares = new List<coords>();

			if (isOpenSpace(c.x + 1, c.y)) {
				adjSquares.Add(new coords(c.x + 1, c.y));
			}
			if (isOpenSpace(c.x - 1, c.y)) {
				adjSquares.Add(new coords(c.x - 1, c.y));
			}
			if (isOpenSpace(c.x, c.y + 1)) {
				adjSquares.Add(new coords(c.x, c.y + 1));
			}
			if (isOpenSpace(c.x, c.y - 1)) {
				adjSquares.Add(new coords(c.x, c.y - 1));
			}
			return adjSquares;

		}
	}
	struct coords {
		public int x { get; set; }
		public int y { get; set; }
		public coords(int x, int y) {
			this.x = x;
			this.y = y;
		}
	}
}
