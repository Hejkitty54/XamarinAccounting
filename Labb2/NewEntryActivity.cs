
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



			RadioButton incomeRb = FindViewById<RadioButton> (Resource.Id.income);
			RadioButton expenseRb = FindViewById<RadioButton> (Resource.Id.expense);

			incomeRb.Click += delegate {
				Spinner typeSp = FindViewById<Spinner> (Resource.Id.type_spinner);
				ArrayAdapter typeAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerItem,incomeAccounts);
				typeSp.Adapter = typeAdapter;
			};

			expenseRb.Click += delegate {
				Spinner typeSp = FindViewById<Spinner> (Resource.Id.type_spinner);
				ArrayAdapter typeAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerItem,expenseAccounts);
				typeSp.Adapter = typeAdapter;
			};


			Spinner moneyAccountSp = FindViewById<Spinner> (Resource.Id.to_from_spinner);
			ArrayAdapter maAdapter = new ArrayAdapter (this,Android.Resource.Layout.SimpleSpinnerItem,moneyAccounts);
			moneyAccountSp.Adapter = maAdapter;


		}
	}
}

