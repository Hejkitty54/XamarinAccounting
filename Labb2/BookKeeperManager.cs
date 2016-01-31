﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
	public class BookKeeperManager
	{
		private static BookKeeperManager instance = null;
		public List<Entry> entries = new List<Entry> ();
		public List<Account> incomeAccounts;
		public List<Account> expenseAccounts;
		public List<Account> moneyAccounts;
		public List<TaxRate> tax;

		//singleton
		public static BookKeeperManager Instance 
		{
			get 
			{ 
				if (instance == null) 
				{
					instance = new BookKeeperManager ();
				}
				return instance;
			}
		}

		//constructor
		public BookKeeperManager ()
		{
			incomeAccounts = new List<Account> () 
			{
				new Account ("Försäljning inom Sverige", 3000),
				new Account ("Fakturerade frakter", 3520),
				new Account ("Försäljning av övrigt material", 3619)
			};

			expenseAccounts = new List<Account> () 
			{
				new Account ("Lokalhyra", 5010),
				new Account ("Programvaror", 5420),
				new Account ("Energikostnader", 5300)
			};
				
			moneyAccounts = new List<Account> () 
			{
				new Account ("Kassa", 1910),
				new Account ("PlusGiro", 1920),
				new Account ("Bankcertifikat", 1950)
			};

			tax = new List<TaxRate> () 
			{
				new TaxRate(6.0),
				new TaxRate(12.0),
				new TaxRate(25.0)
			};
		}

		public void addEntry(Entry e)
		{
			entries.Add (e);
		}
		/*
		public override string ToString ()
		{
			return String.Join (",",moneyAccounts.Select(s=> s.ToString()));
		}*/
	}
}

