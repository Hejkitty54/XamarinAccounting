using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Labb2
{	/// <summary> This class is connected to the database and has the logic for this application. </summary>
	public class BookKeeperManager
	{
		private static BookKeeperManager instance = null;
		private SQLiteConnection db;

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
		private BookKeeperManager ()
		{
			string dbPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			db = new SQLiteConnection ( dbPath + @"\database.db");

			try{
				db.Table<Entry>().Count();
			} catch(SQLiteException e){
				db.CreateTable<Entry> ();
			}

			try{
				db.Table<TaxRate>().Count();
			} catch(SQLiteException e){
				db.CreateTable<TaxRate> ();
				db.Insert (new TaxRate(){ Tax = 6.0});
				db.Insert (new TaxRate(){ Tax = 12.0});
				db.Insert (new TaxRate(){ Tax = 25.0});
			}

			try{
				db.Table<Account>().Count();
			} catch(SQLiteException e){
				db.CreateTable<Account> ();
				db.Insert (new Account(){ Name = "Försäljning inom Sverige", Number = 3000});
				db.Insert (new Account(){ Name = "Fakturerade frakter", Number = 3520});
				db.Insert (new Account(){ Name = "Försäljning av övrigt material", Number = 3619});
				db.Insert (new Account(){ Name = "Lokalhyra", Number = 5010});
				db.Insert (new Account(){ Name = "Programvaror", Number = 5420});
				db.Insert (new Account(){ Name = "Energikostnader", Number = 5300});
				db.Insert (new Account(){ Name = "Kassa", Number = 1910});
				db.Insert (new Account(){ Name = "PlusGiro", Number = 1920});
				db.Insert (new Account(){ Name = "Bankcertifikat", Number = 1950});
			}
		}
		/// <summary> adds an Entry to the Entry table.</summary>
		/// <param name="e"> instance of a Entry class</param>
		public void addEntry(Entry e)
		{
			db.Insert (e);
		}

		/// <summary> hämtar whole Entry table and converts it to the list and returns it.</summary>
		public List<Entry> Entries{
			get{ 
				return db.Table<Entry> ().ToList ();
			}
		}

		/// <summary> hämtar whole TaxRate table and converts it to the list and returns it.</summary>
		public List<TaxRate> TaxRates{
			get{ 
				return db.Table<TaxRate> ().ToList ();
			}
		}
		/// <summary> hämtar Account table which Number is 3000, 3520 and 3619. 
		/// It is converted to the list and is returned.</summary>
		public List<Account> IncomeAccounts{
			get{ 
				return db.Table<Account> ().Where(a=>a.Number ==3000||a.Number==3520||a.Number==3619 ).ToList();
			}
		}

		/// <summary> hämtar Account table which Number is 5010, 5420 and 5300. 
		/// It is converted to the list and is returned.</summary>
		public List<Account> ExpenseAccounts{
			get{ 
				return db.Table<Account> ().Where(a=>a.Number==5010||a.Number==5420||a.Number==5300 ).ToList();
			}
		}

		/// <summary> hämtar Account table which Number is 1910, 1920 and 1950. 
		/// It is converted to the list and is returned.</summary>
		public List<Account> MoneyAccounts{
			get{ 
				return db.Table<Account> ().Where(a=>a.Number==1910||a.Number==1920||a.Number==1950 ).ToList();
			}
		}
	
		/// <returns> a string of the all information about the tax report.</returns>
		public string GetTaxReport(){

			String whole = "";
			double calculatedTax;
			double total=0.0;

			List<Entry> entries = db.Table<Entry> ().ToList ();

			foreach(Entry e in entries){

				whole+= e.Date +"-"+e.Description+" ";
			
				int amount = Int32.Parse (e.TotalAmount);
				double tax = Convert.ToDouble(e.TaxRate.Remove ((e.TaxRate.Length)-1));

				calculatedTax = amount * tax*0.01;

				if (e.InOut == "expense") {
					calculatedTax = calculatedTax*(-1);
				} 

				total += calculatedTax;
				whole+= calculatedTax.ToString()+"kr"+"\n" ;
			}

			whole += "Total: "+ total.ToString()+"kr";

			return whole;
		}

		/*
		public override string ToString ()
		{
			return String.Join (",",moneyAccounts.Select(s=> s.ToString()));
		}*/
	}
}

