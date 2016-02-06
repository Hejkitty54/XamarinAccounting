using System;
using SQLite;

namespace Labb2
{
	public class Account
	{
		public string Name { get; set;}
		public int Number  { get; set;}

		public Account ()
		{
		}
		public override string ToString ()
		{
			return Name + " ("+ Number + ")";
		}
	}
}

