
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Labb2
{
	[Activity (Label = "NewEntry")]			
	public class NewEntryActivity : Activity
	{
		private BookKeeperManager BKM = BookKeeperManager.Instance;
		private List<string> incomeAccounts= new List<string>();
		private List<string> expenseAccounts= new List<string>();
		private List<string> moneyAccounts= new List<string>();
		private List<string> tax= new List<string>();

		private Spinner typeSp;
		private string inOut;
		private string type;
		private string moneyAccount;
		private string taxRate;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.new_entry);

			//kan skariva på bättre sätt?
			foreach( Account a in BKM.incomeAccounts)
			{
				incomeAccounts.Add(a.ToString());
			}
			foreach( Account a in BKM.expenseAccounts)
			{
				expenseAccounts.Add(a.ToString());
			}
			foreach( Account a in BKM.moneyAccounts)
			{
				moneyAccounts.Add(a.ToString());
			}
			foreach( TaxRate t in BKM.tax)
			{
				tax.Add(t.ToString());
			}



			RadioButton incomeRb = FindViewById<RadioButton> (Resource.Id.income);
			RadioButton expenseRb = FindViewById<RadioButton> (Resource.Id.expense);
			typeSp = FindViewById<Spinner> (Resource.Id.type_spinner);

			incomeRb.Click += delegate {
				inOut="income";
				ArrayAdapter typeAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,incomeAccounts);
				typeSp.Adapter = typeAdapter;
			};
				
			expenseRb.Click += delegate {
				inOut="expense";
				ArrayAdapter typeAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,expenseAccounts);
				typeSp.Adapter = typeAdapter;
			};

			typeSp.ItemSelected += delegate {
				type = typeSp.SelectedItem.ToString();
				Console.WriteLine(type);
			};
				
			Spinner moneyAccountSp = FindViewById<Spinner> (Resource.Id.to_from_spinner);
			ArrayAdapter maAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,moneyAccounts);
			moneyAccountSp.Adapter = maAdapter;
			moneyAccountSp.ItemSelected += delegate {
				moneyAccount = moneyAccountSp.SelectedItem.ToString();
				Console.WriteLine(moneyAccount);
			};

			Spinner taxSp = FindViewById<Spinner> (Resource.Id.tax_spinner);
			ArrayAdapter taxAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,tax);
			taxSp.Adapter = taxAdapter;
			taxSp.ItemSelected += delegate {
				taxRate = taxSp.SelectedItem.ToString();
				Console.WriteLine(taxRate);
			};

			Button addButton = FindViewById<Button> (Resource.Id.add_button);
			addButton.Click += delegate {
				//måste fixa till string
				string date = FindViewById<EditText>(Resource.Id.date_input).ToString();
				string description = FindViewById<EditText>(Resource.Id.date_input).ToString();
				string totalAmount = FindViewById<EditText>(Resource.Id.total_amount_input).ToString();
				//Adds to list entries
				Entry entry = new Entry(inOut,date,description,type,moneyAccount,totalAmount,taxRate);
				BKM.addEntry(entry);

				Console.WriteLine(inOut+type+moneyAccount);
			};


		}
	}
}

