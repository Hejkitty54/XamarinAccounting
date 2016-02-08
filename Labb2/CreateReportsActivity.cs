
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
	/// <summary> This activity has a button which sends a tax report via e-mail. </summary>
	public class CreateReportsActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.create_reports);
			BookKeeperManager BKM = BookKeeperManager.Instance;

			Button button = FindViewById<Button> (Resource.Id.tax_report);
			button.Click += delegate {

				var email = new Intent (Intent.ActionSend);
				email.PutExtra (Intent.ExtraSubject, "Tax report");
				email.PutExtra (Intent.ExtraText,BKM.GetTaxReport());
				email.SetType ("message/rfc822");
				StartActivity (email);
			};
		}
	}
}

