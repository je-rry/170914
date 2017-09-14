using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Instruction
{
	public enum INSTRUCTION
	{
		ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT,

		PLUS, MINUS,

		ACTION, NUMBER,

		NULL
	}

	public abstract class Instruction
	{

		public Instruction next
		{
			get;
			set;
		}

		public Instruction before
		{
			get;
			set;
		}

		public INSTRUCTION instruction
		{
			get;
			protected set;
		}

		public abstract bool nextValid();


		public bool checkValid()
		{
			Instruction _tmp = this;
			bool flag = true;

			while (_tmp != null && flag)
			{
				flag &= _tmp.nextValid();
				_tmp = _tmp.next;
			}

			return flag;
		}

		public static Instruction operator +(Instruction one, Instruction other)
		{
			Instruction _tmp = one;

			while (_tmp.next != null)
				_tmp = _tmp.next;

			_tmp.next = other;
			other.before = _tmp;

			return one;
		}

		public Instruction make(INSTRUCTION instruction)
		{
			Instruction _tmp;
			INSTRUCTION type = typeCheck(instruction);

			if (type == INSTRUCTION.ACTION)
				_tmp = new Action(instruction);
			else
				_tmp = new Number(instruction);

			return (this + _tmp);
		}

		public Instruction make(String instruction)
		{
			return make(convert(instruction));
		}

		protected INSTRUCTION convert(String instruction)
		{
			instruction.ToLower();

			if (instruction.Equals("plus"))
				return INSTRUCTION.PLUS;
			else if (instruction.Equals("minus"))
				return INSTRUCTION.MINUS;
			else if (instruction.Equals("one") || instruction.Equals("1"))
				return INSTRUCTION.ONE;
			else if (instruction.Equals("two") || instruction.Equals("2"))
				return INSTRUCTION.TWO;
			else if (instruction.Equals("three") || instruction.Equals("3"))
				return INSTRUCTION.THREE;
			else if (instruction.Equals("four") || instruction.Equals("4"))
				return INSTRUCTION.FOUR;
			else if (instruction.Equals("five") || instruction.Equals("5"))
				return INSTRUCTION.FIVE;
			else if (instruction.Equals("six") || instruction.Equals("6"))
				return INSTRUCTION.SIX;
			else if (instruction.Equals("seven") || instruction.Equals("7"))
				return INSTRUCTION.SEVEN;
			else if (instruction.Equals("eight") || instruction.Equals("8"))
				return INSTRUCTION.EIGHT;
			else
				return INSTRUCTION.NULL;
		}

		public Instruction one()
		{
			return make("1");
		}
		public Instruction two()
		{
			return make("2");
		}
		public Instruction three()
		{
			return make("3");
		}
		public Instruction four()
		{
			return make("4");
		}
		public Instruction five()
		{
			return make("5");
		}
		public Instruction six()
		{
			return make("6");
		}
		public Instruction seven()
		{
			return make("7");
		}
		public Instruction eight()
		{
			return make("8");
		}
		public Instruction plus()
		{
			return make("plus");
		}
		public Instruction minus()
		{
			return make("minus");
		}


		protected INSTRUCTION typeCheck(INSTRUCTION instruction)    // check the type of instruction
		{
			if (INSTRUCTION.ONE <= instruction && instruction <= INSTRUCTION.EIGHT)
				return INSTRUCTION.NUMBER;

			else
				return INSTRUCTION.ACTION;
		}

		public override string ToString ()
		{
			string str = "";
			Instruction _tmp = this;

			while (_tmp != null) {
				if(!_tmp.instruction.Equals(INSTRUCTION.NULL))
					str += _tmp.instruction.ToString () + " ";
				_tmp = _tmp.next;
			}

			return str;
		}

		public void make(Instruction instruction)
		{
			if (instruction.instruction == INSTRUCTION.PLUS)
				make ("plus");
			else if (instruction.instruction == INSTRUCTION.MINUS)
				make ("minus");
			else if (instruction.instruction == INSTRUCTION.ONE)
				make ("one");
			else if (instruction.instruction == INSTRUCTION.TWO)
				make ("two");
			else if (instruction.instruction == INSTRUCTION.THREE)
				make ("three");
			else if (instruction.instruction == INSTRUCTION.FOUR)
				make ("four");
			else if (instruction.instruction == INSTRUCTION.FIVE)
				make ("five");
			else if (instruction.instruction == INSTRUCTION.SIX)
				make ("six");
			else if (instruction.instruction == INSTRUCTION.SEVEN)
				make ("seven");
			else if (instruction.instruction == INSTRUCTION.EIGHT)
				make ("eight");
		}
	}

}