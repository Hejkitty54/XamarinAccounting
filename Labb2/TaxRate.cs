using System;

namespace Labb2
{
	public class TaxRate
	{
		public double Tax { get; private set;} 

		public TaxRate (double tax)
		{
			Tax = tax;
		}
		public override string ToString ()
		{
			return Tax.ToString() + "%";
		}
	}
}

