
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
	[Activity (Label = "ShowAllEntriesActivity")]			
	public class ShowAllEntriesActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.show_all_entries);

			//hämta list of entries from BKM
			BookKeeperManager BKM = BookKeeperManager.Instance;
			List<Entry> entries = BKM.Entries;
			EntryAdapter adapter = new EntryAdapter (this, entries);

			ListView listView = FindViewById<ListView> (Resource.Id.myListView);
			listView.Adapter = adapter;
		}
	}
}

