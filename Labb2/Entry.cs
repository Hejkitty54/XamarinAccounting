using System;
using SQLite;

namespace Labb2
{	
	/// <summary> This is an Entry which user can add. This is used both for the income and the cost.
	/// This has all informations abot the entry.</summary>
	public class Entry
	{
		[PrimaryKey, AutoIncrement]
		public int Id{ get; private set;}
		public string InOut { get; set;}
		public string Date { get; set;}
		public string Description { get; set;}
		public string Type { get; set;}
		public string MoneyAccount { get; set;}
		public string TotalAmount { get; set;}
		public string TaxRate { get; set;}
		public double CalculatedTax { get; set;}

		public Entry ()
		{
		}
	}
}

