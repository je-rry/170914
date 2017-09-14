using System;

namespace Instruction
{
	public class Action : Instruction	//for plus,minus,play
	{
		public Action (INSTRUCTION instruction)
		{
			if(instruction == INSTRUCTION.PLUS || instruction == INSTRUCTION.MINUS )
				this.instruction = instruction;
		}

		public Action(String instruction)
		{
			this.instruction = convert (instruction);
		}


		public override bool nextValid ()
		{
			return next is Number;
		} 
	}
}