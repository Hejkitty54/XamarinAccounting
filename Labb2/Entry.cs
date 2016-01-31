using System;

namespace Labb2
{
	public class Entry
	{
		public string InOut { get; set;}
		public string Date { get; set;}
		public string Description { get; set;}
		public string Type { get; set;}
		public string MoneyAccount { get; set;}
		public string TotalAmount { get; set;}
		public string TaxRate { get; set;}

		public Entry (string inOut,string date,string description,string type,string moneyAccount,string totalAmount,string taxrate)
		{
			InOut = inOut;
			Date = date;
			Description = description;
			Type = type;
			MoneyAccount = moneyAccount;
			TotalAmount = totalAmount;
			TaxRate = taxrate;
		}
	}
}

