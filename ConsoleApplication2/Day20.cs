using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Day20
    {
        internal static List<long> ipList = new List<long>();
        internal static List<Tuple<long, long>> ip2 = new List<Tuple<long, long>>();
        internal static void part1()
        {
            FileInfo input = new FileInfo(Program.dir + "day20.txt");
            var stream = input.OpenText();

            while (!stream.EndOfStream)
            {
                string[] ips = stream.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                long startip = long.Parse(ips[0]);
                long stopip = long.Parse(ips[1]);
                ip2.Add(new Tuple<long, long>(startip, stopip));

            }

            var sorted = ip2.OrderBy(t => t.Item1);
            long lowestIP = 0;
            long count = 0;
            foreach (Tuple<long, long> t in sorted)
            {
                if(t.Item1 > lowestIP + 1)
                {
                    count += t.Item1 - (lowestIP + 1);
                }
                lowestIP = Math.Max(lowestIP, t.Item2);
            }
            Console.WriteLine(count);

        }

    }
}
