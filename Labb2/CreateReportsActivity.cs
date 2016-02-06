
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
	[Activity (Label = "CreateReportsActivity")]			
	public class CreateReportsActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.create_reports);
			BookKeeperManager BKM = BookKeeperManager.Instance;
			// Create your application here
			Button button = FindViewById<Button> (Resource.Id.tax_report);
			button.Click += delegate {
				Console.WriteLine(BKM.GetTaxReport());
			};



		}
	}
}

