using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Day22
    {
        internal static void part1()
        {
            FileInfo input = new FileInfo(Program.dir + "day22.txt");
            var stream = input.OpenText();
            List<Node> nodes = new List<Node>();
            while (!stream.EndOfStream)
            {
                string[] words = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Node n = new Node();
                string[] coords = Regex.Split(words[0], @"\D+");
                n.x = int.Parse(coords[1]);
                n.y = int.Parse(coords[2]);
                n.size = int.Parse(words[1].Trim('T'));
                n.used = int.Parse(words[2].Trim('T'));
                n.available = int.Parse(words[3].Trim('T'));
                nodes.Add(n);
            }
            int count = 0;
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (nodes[j].used > 0 && nodes[i].available >= nodes[j].used)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
            writeMap(nodes);
        }

        private static void writeMap(List<Node> nodes)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    Node n = nodes.Find(a => a.x == x && a.y == y);
                    Console.Write(n.used + "/" + n.available + " ");
                }

                Console.Write("\n");
            }
        }
    }
    class Node
    {
        public int x { get; set; }
        public int y { get; set; }
        public int size { get; set; }
        public int used { get; set; }
        public int available { get; set; }
        public Node(int x, int y, int size, int used, int available)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.used = used;
            this.available = available;
        }
        public Node()
        {

        }

    }
}
