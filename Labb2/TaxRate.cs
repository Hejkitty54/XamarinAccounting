using System;
using SQLite;

namespace Labb2
{	
	/// <summary> This is a class which has information about tax. </summary>
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

