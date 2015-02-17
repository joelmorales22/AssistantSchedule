using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AssistantSchedule
{

	[Activity (Label = "AssistantSchedule", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		string month;
		//int count = 1;
		//string SelectedMonth= "";

		private void spinner_ItemSelected ( object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;

			string toast = string.Format ("The Month is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
			//SelectedMonth = test;
			TextView SelectedMonth = FindViewById<TextView> (Resource.Id.textView1);
			SelectedMonth.Text=string.Format("{0}", spinner.GetItemAtPosition (e.Position));
			month = SelectedMonth.Text;
			//CurrentMonth.Text = SelectedMonth;

		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

		
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it



			Spinner spinner = FindViewById<Spinner> (Resource.Id.spinner3);
			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
			           this, Resource.Array.months, Android.Resource.Layout.SimpleSpinnerItem);

			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;

			Button confirm = FindViewById<Button> (Resource.Id.myButton);
			confirm.Click += delegate{
				var calendar = new Intent(this, typeof(Calendar));
				calendar.PutExtra ("month",month);
				StartActivity(calendar);
			};


		}

	}

}
