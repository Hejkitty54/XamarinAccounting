
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
using SQLite;


namespace Labb2
{
	[Activity (Label = "NewEntry")]
	/// <summary> This is an activity class which the user can make a new entry with.
	/// User inputs information in it and when user click add button,
	/// an Entry object is created and is saved in the database.</summary>
	public class NewEntryActivity : Activity
	{
		private BookKeeperManager BKM;
		private Spinner typeSp;
		private string inOut;
		private string type;
		private string moneyAccount;
		private string taxRate;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.new_entry);
			BKM = BookKeeperManager.Instance;

			RadioButton incomeRb = FindViewById<RadioButton> (Resource.Id.income);
			RadioButton expenseRb = FindViewById<RadioButton> (Resource.Id.expense);
			typeSp = FindViewById<Spinner> (Resource.Id.type_spinner);

			incomeRb.Click += delegate {
				inOut="income";
				ArrayAdapter typeAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,BKM.IncomeAccounts);
				typeSp.Adapter = typeAdapter;
			};
				
			expenseRb.Click += delegate {
				inOut="expense";
				ArrayAdapter typeAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,BKM.ExpenseAccounts);
				typeSp.Adapter = typeAdapter;
			};

			typeSp.ItemSelected += delegate {
				type = typeSp.SelectedItem.ToString();
			};
				
			Spinner moneyAccountSp = FindViewById<Spinner> (Resource.Id.to_from_spinner);
			ArrayAdapter maAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,BKM.MoneyAccounts);
			moneyAccountSp.Adapter = maAdapter;
			moneyAccountSp.ItemSelected += delegate {
				moneyAccount = moneyAccountSp.SelectedItem.ToString();
			};
				
			Spinner taxSp = FindViewById<Spinner> (Resource.Id.tax_spinner);
			ArrayAdapter taxAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerDropDownItem,BKM.TaxRates);
			taxSp.Adapter = taxAdapter;
			taxSp.ItemSelected += delegate {
				taxRate = taxSp.SelectedItem.ToString();
			};

			Button addButton = FindViewById<Button> (Resource.Id.add_button);
			addButton.Click += delegate {
				
				string date = FindViewById<EditText>(Resource.Id.date_input).Text;
				string description = FindViewById<EditText>(Resource.Id.description_input).Text;
				string totalAmount = FindViewById<EditText>(Resource.Id.total_amount_input).Text;

				//Adds to BKM
				Entry entry = new Entry(){ InOut=inOut, Date = date, Description=description,Type = type, MoneyAccount=moneyAccount,
											TotalAmount = totalAmount, TaxRate=taxRate};
				BKM.addEntry(entry);
						
			};
		}
	}
}

