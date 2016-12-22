using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Day19
    {
        internal static int input = 3014387;
        internal static bool[] elves = new bool[input];
        internal static void part1()
        {
            for (int i = 0; i < input; i++)
            {
                elves[i] = true;
            }
            while (true)
            {
                for (int i = 0; i < input; i++)
                {
                    if (!elves[i])
                    {
                        continue;
                    }
                    int j = (i + 1) % input;
                    while (!elves[j])
                    {
                        j = (j + 1) % input;
                    }
                    if (j == i)
                    {
                        Console.WriteLine(j + 1);
                    }
                    elves[j] = false;

                }
            }

        }
        internal static void part2()
        {
            //input = 5;
            Elf start = new Elf(1);
            Elf elf = start;
            Elf target = null;

            for(int i = 1; i < input+1; i++)
            {
                elf.nextElf = (i == input) ? start : new Elf(i+1, elf);
                elf = elf.nextElf;
                if(i == input / 2)
                {
                    target = elf;
                }
            }
            start.prevElf = elf;
            int elvesLeft = input;
            while(elf.nextElf != elf)
            {
                //Console.WriteLine("{0} steals {1}'s presents", elf.ID, target.ID);
                target.prevElf.nextElf = target.nextElf;
                target.nextElf.prevElf = target.prevElf;
                target = elvesLeft % 2 == 1 ? target.nextElf.nextElf : target.nextElf;
                elvesLeft--;
                elf = elf.nextElf;
            }
            Console.WriteLine(elf.ID);
        }
    }
    class Elf
    {
        public int ID { get; set; }
        public Elf prevElf { get; set; }
        public Elf nextElf { get; set; }
        public Elf(int ID)
        {
            this.ID = ID;
        }
        public Elf(int ID, Elf prevElf)
        {
            this.ID = ID;
            this.prevElf = prevElf;
        }

    }
}
