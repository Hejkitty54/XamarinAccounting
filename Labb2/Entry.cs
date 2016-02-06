using System;
using SQLite;

namespace Labb2
{
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

