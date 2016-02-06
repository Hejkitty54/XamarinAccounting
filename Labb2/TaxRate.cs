using System;
using SQLite;

namespace Labb2
{
	public class TaxRate
	{
		[PrimaryKey, AutoIncrement]
		public int Id{ get; private set;}
		public double Tax { get; set;} 

		public TaxRate ()
		{
		}

		public override string ToString ()
		{
			return Tax.ToString() + "%";
		}
	}
}

