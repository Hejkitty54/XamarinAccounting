using System;
using SQLite;

namespace Labb2
{
	/// <summary>This is an account class which has information about account.
	/// This is used for the income account, expense account and money account.</summary>
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

