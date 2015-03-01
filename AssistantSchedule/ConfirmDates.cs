
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
using Android.Provider;
using Java.Util;


namespace AssistantSchedule
{
	[Activity (Label = "ConfirmDates")]			
	public class ConfirmDates : Activity
	{
		int [] datesChosen = new int[32];
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.confirmDates);

			string CalMonth = Intent.GetStringExtra ("CurrentMonth") ?? "data not avail.";

			IList <string> newdates;// = new List<string>{ };
			newdates = Intent.GetStringArrayListExtra ("newDates");

			TextView disMonth = FindViewById<TextView> (Resource.Id.tv1);
			disMonth.Text = "You have chosen the following dates" + System.Environment.NewLine ;

			TextView disDates = FindViewById<TextView> (Resource.Id.tv2);
			for (int i = 0; i < newdates.Count(); i++) {
				datesChosen[i] = Int32.Parse(newdates[i]);
			}
			disDates.Text = "";
			for (int i = 0; i < newdates.Count(); i++) {
				disDates.Text += CalMonth + " " + datesChosen [i] + System.Environment.NewLine ;
			}
			Button ChooseAccount = FindViewById <Button> (Resource.Id.SelectAccount);
			ChooseAccount.Click += delegate {
				var choose = new Intent (this, typeof(ChooseAccount));
				choose.PutExtra ("CalMonth",CalMonth);
				choose.PutStringArrayListExtra ("newDates", newdates);
				StartActivity (choose);
			};

		}
	}
}

