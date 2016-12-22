using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Day21
    {
        internal static string inputstring = "dbfgaehc";
        internal static string password = "fbgdceah";
        internal static void part1()
        {
            FileInfo input = new FileInfo(Program.dir + "day21.txt");
            var stream = input.OpenText();
            //inputstring = "abcde";
            char[] pw = inputstring.ToArray();
            while (!stream.EndOfStream)
            {
                //Console.WriteLine(pw);

                string[] words = stream.ReadLine().Split();
                //Console.WriteLine(String.Join(" ", words));
                switch (words[0])
                {
                    case "swap":
                        if (words[1].Equals("position"))
                        {
                            int x = int.Parse(words[2]);
                            int y = int.Parse(words[5]);
                            char tmp = pw[x];
                            pw[x] = pw[y];
                            pw[y] = tmp;
                        }
                        else
                        {
                            char x = words[2][0];
                            char y = words[5][0];
                            pw = swap(pw, x, y);
                        }
                        break;
                    case "rotate":
                        if (words[1].Equals("based"))
                        {
                            int rotations = Array.IndexOf(pw, words[6][0]);
                            if (rotations >= 4) rotations++;
                            rotations++;
                            pw = shiftRight(pw, rotations);
                        }
                        else
                        {
                            int rotations = int.Parse(words[2]);
                            if (words[1].Equals("left"))
                            {
                                pw = shiftLeft(pw, rotations);
                            }
                            else
                            {
                                pw = shiftRight(pw, rotations);
                            }
                        }
                        break;
                    case "reverse":
                        int from = int.Parse(words[2]);
                        int to = int.Parse(words[4]);
                        Array.Reverse(pw, from, to - from + 1);
                        break;
                    case "move":
                        int f = int.Parse(words[2]);
                        int t = int.Parse(words[5]);

                        pw = move(pw, f, t);
                        break;
                }

            }
            Console.WriteLine(pw);

        }

        internal static void part2()
        {
            FileInfo input = new FileInfo(Program.dir + "day21.txt");
            var stream = input.OpenText();
            List<string> operations = new List<string>();
            while (!stream.EndOfStream)
            {
                operations.Add(stream.ReadLine());
            }
            //inputstring = "abcde";
            string unscrambled = "abcdefgh";
            var tosearch = GetPermutations(unscrambled.ToList(), 8);
            foreach(var ts in tosearch)
            {
                char[] pw = ts.ToArray();
                foreach (string operation in operations)
                {
                    //Console.WriteLine(pw);

                    string[] words = operation.Split();
                    //Console.WriteLine(String.Join(" ", words));
                    switch (words[0])
                    {
                        case "swap":
                            if (words[1].Equals("position"))
                            {
                                int x = int.Parse(words[2]);
                                int y = int.Parse(words[5]);
                                char tmp = pw[x];
                                pw[x] = pw[y];
                                pw[y] = tmp;
                            }
                            else
                            {
                                char x = words[2][0];
                                char y = words[5][0];
                                pw = swap(pw, x, y);
                            }
                            break;
                        case "rotate":
                            if (words[1].Equals("based"))
                            {
                                int rotations = Array.IndexOf(pw, words[6][0]);
                                if (rotations >= 4) rotations++;
                                rotations++;
                                pw = shiftRight(pw, rotations);
                            }
                            else
                            {
                                int rotations = int.Parse(words[2]);
                                if (words[1].Equals("left"))
                                {
                                    pw = shiftLeft(pw, rotations);
                                }
                                else
                                {
                                    pw = shiftRight(pw, rotations);
                                }
                            }
                            break;
                        case "reverse":
                            int from = int.Parse(words[2]);
                            int to = int.Parse(words[4]);
                            Array.Reverse(pw, from, to - from + 1);
                            break;
                        case "move":
                            int f = int.Parse(words[2]);
                            int t = int.Parse(words[5]);

                            pw = move(pw, f, t);
                            break;
                    }

                }
                unscrambled = new string(pw);
                if(unscrambled == password)
                {
                    Console.WriteLine(new string(ts.ToArray()));
                    return;
                }
            }

        }
        private static char[] move(char[] pw, int f, int t)
        {
            List<char> n = pw.ToList();
            char m = n[f];
            n.RemoveAt(f);
            n.Insert(t, m);


            return n.ToArray();

        }

        private static char[] shiftLeft(char[] pw, int rotations)
        {
            char[] n = pw;
            for (int i = 0; i < rotations; i++)
            {
                char[] t = new char[pw.Length];
                for (int j = 0; j < n.Length; j++)
                {
                    t[j] = n[(j + 1) % (n.Length)];
                }
                n = t;
            }
            return n;
        }
        private static char[] shiftRight(char[] pw, int rotations)
        {
            char[] n = pw;
            for (int i = 0; i < rotations; i++)
            {
                char[] t = new char[pw.Length];
                for (int j = 0; j < t.Length; j++)
                {
                    t[(j + 1) % n.Length] = n[j];
                }
                n = t;
            }
            return n;
        }

        private static char[] swap(char[] pw, char x, char y)
        {
            string n = string.Empty;
            foreach (char c in pw)
            {
                if (c == x)
                {
                    n += y;
                }
                else if (c == y)
                {
                    n += x;
                }
                else
                {
                    n += c;
                }
            }
            return n.ToArray();
        }
        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
