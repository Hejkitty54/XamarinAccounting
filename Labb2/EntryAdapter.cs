using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace Labb2
{	
	/// <summary> This is an adapter class which was made for being used to show the list in ShowAllEntries activity.</summary>
	public class EntryAdapter:BaseAdapter
	{
		private Activity activity;
		private List<Entry> entries;

		public EntryAdapter (Activity activity, List<Entry> entries)
		{
			this.activity = activity;
			this.entries = entries;
		}
			
		public override Java.Lang.Object GetItem (int position)
		{
			return null;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			if (convertView == null) {
				convertView = activity.LayoutInflater.Inflate (Resource.Layout.entry_list_item,parent,false);
			}

			Entry entry = entries [position];

			TextView textDate = convertView.FindViewById<TextView> (Resource.Id.showDate);
			TextView textMessage = convertView.FindViewById<TextView> (Resource.Id.showMessage);
			TextView textBelopp = convertView.FindViewById<TextView> (Resource.Id.showBelopp);
			TextView textTax = convertView.FindViewById<TextView> (Resource.Id.showTax);


			textDate.Text = entry.Date;
			textMessage.Text = entry.Description;
			textBelopp.Text = entry.TotalAmount+"kr";
			textTax.Text = "tax."+entry.TaxRate;

			return convertView;


		}

		public override int Count {
			get{
				return entries.Count;
			}
		}

	}
}

