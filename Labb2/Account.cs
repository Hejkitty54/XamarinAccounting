using System;

namespace Labb2
{
	public class Account
	{
		public string Name { get; private set;}
		public int Number  { get; private set;}

		public Account (string name, int number)
		{
			Name = name;
			Number = number;
		}
		public override string ToString ()
		{
			return Name + " ("+ Number + ")";
		}
	}
}

