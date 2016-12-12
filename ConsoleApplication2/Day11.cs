using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2 {
	class Day11 {
		internal static void part1() {
			/*
			 * Input:
				 * The first floor contains a polonium generator, a thulium generator, a thulium-compatible microchip, a promethium generator, 
				 * a ruthenium generator, a ruthenium-compatible icrochip, a cobalt generator, and a cobalt-compatible microchip.
				 * The second floor contains a polonium-compatible microchip and a promethium-compatible microchip.
				 * The third floor contains nothing relevant.
				 * The fourth floor contains nothing relevant.
				 * 
				 * 10 items to move to floor 4. 8 from floor 1 and 2 from floor 2
				 * For each items you need 2 moves to bring it a floor up.
				 * -3 for last 2 items each floor,  no need to go down afterwards
				 * 16-3+20-3+20-3 = 47
			 * 
			 */
		}
		internal static void part() {
			/*
			 * 4 extra items:
			 * 3*4*2 = 24 extra moves => 47+24 = 71
			 */
		}
	}

}
/*
FF:	POG		TG	TM	PRG		RG	RM	CG	CM
SF		PM				PRM					
TF											
SF											
	*/


