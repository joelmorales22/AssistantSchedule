
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
	[Activity (Label = "Calendar")]			
	public class Calendar : Activity
	{
		List<int> dates = new List<int>();
		CheckBox [] allChecks = new CheckBox[32];
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.calendar);

			string CurrentMonth = Intent.GetStringExtra ("month") ?? "data not avail.";

			TextView disMonth = FindViewById<TextView> (Resource.Id.DisplayMonth);
			disMonth.Text = CurrentMonth;
			//CheckBox[] allChecks;
			//int[] dates;
			CheckBox CB1 = FindViewById<CheckBox> (Resource.Id.CB1); 
			allChecks[1] = CB1;
			CheckBox CB2 = FindViewById<CheckBox> (Resource.Id.CB2);// 
			allChecks [2] = CB2;
			CheckBox CB3 = FindViewById<CheckBox> (Resource.Id.CB3); 
			allChecks [3] = CB3;
			CheckBox CB4 = FindViewById<CheckBox> (Resource.Id.CB4); 
			allChecks [4] = CB4;
			CheckBox CB5 = FindViewById<CheckBox> (Resource.Id.CB5);
			allChecks [5] = CB5;
			CheckBox CB6 = FindViewById<CheckBox> (Resource.Id.CB6); 
			allChecks [6] = CB6;
			CheckBox CB7 = FindViewById<CheckBox> (Resource.Id.CB7); 
			allChecks [7] = CB7;
			CheckBox CB8 = FindViewById<CheckBox> (Resource.Id.CB8);
			allChecks [8] = CB8;
			CheckBox CB9 = FindViewById<CheckBox> (Resource.Id.CB9); 
			allChecks [9] = CB9;
			CheckBox CB10 = FindViewById<CheckBox> (Resource.Id.CB10); 
			allChecks [10] = CB10;
			CheckBox CB11 = FindViewById<CheckBox> (Resource.Id.CB11); 
			allChecks [11] = CB11;
			CheckBox CB12 = FindViewById<CheckBox> (Resource.Id.CB12);
			allChecks [12] = CB12;
			CheckBox CB13 = FindViewById<CheckBox> (Resource.Id.CB13); 
			allChecks [13] = CB13;
			CheckBox CB14 = FindViewById<CheckBox> (Resource.Id.CB14); 
			allChecks [14] = CB14;
			CheckBox CB15 = FindViewById<CheckBox> (Resource.Id.CB15); 
			allChecks [15] = CB15;
			CheckBox CB16 = FindViewById<CheckBox> (Resource.Id.CB16); 
			allChecks [16] = CB16;
			CheckBox CB17 = FindViewById<CheckBox> (Resource.Id.CB17); 
			allChecks [17] = CB17;
			CheckBox CB18 = FindViewById<CheckBox> (Resource.Id.CB18); 
			allChecks [18] = CB18;
			CheckBox CB19 = FindViewById<CheckBox> (Resource.Id.CB19); 
			allChecks [19] = CB19;
			CheckBox CB20 = FindViewById<CheckBox> (Resource.Id.CB20); 
			allChecks [20] = CB20;
			CheckBox CB21 = FindViewById<CheckBox> (Resource.Id.CB21); 
			allChecks [21] = CB21;
			CheckBox CB22 = FindViewById<CheckBox> (Resource.Id.CB22); 
			allChecks [22] = CB22;
			CheckBox CB23 = FindViewById<CheckBox> (Resource.Id.CB23);
			allChecks [23] = CB23;
			CheckBox CB24 = FindViewById<CheckBox> (Resource.Id.CB24); 
			allChecks [24] = CB24;
			CheckBox CB25 = FindViewById<CheckBox> (Resource.Id.CB25);
			allChecks [25] = CB25; 
			CheckBox CB26 = FindViewById<CheckBox> (Resource.Id.CB26); 
			allChecks [26] = CB26;
			CheckBox CB27 = FindViewById<CheckBox> (Resource.Id.CB27); 
			allChecks [27] = CB27;
			CheckBox CB28 = FindViewById<CheckBox> (Resource.Id.CB28); 
			allChecks [28] = CB28;
			CheckBox CB29 = FindViewById<CheckBox> (Resource.Id.CB29);
			allChecks [29] = CB29;
			CheckBox CB30 = FindViewById<CheckBox> (Resource.Id.CB30); 
			allChecks [30] = CB30;
			CheckBox CB31 = FindViewById<CheckBox> (Resource.Id.CB31); 
			allChecks [31] = CB31;

			switch (CurrentMonth)
			{
			case "January":

				break;
			case "February":
				CB29.Enabled = false;
				CB30.Enabled = false;
				CB31.Enabled = false;
				break;
			case "March":
				//31
				break;
			case "April":
				//30
				CB31.Enabled = false;
				break;
			case "May":
				//31
				break;
			case "June":
				//30
				CB31.Enabled = false;
				break;
			case "July":
				//31
				break;
			case "August":
				//31
				break;
			case "September":
				//30
				CB31.Enabled = false;
				break;
			case "October":
				//31
				break;
			case "November":
				//30
				CB31.Enabled = false;
				break;
			case "December":
				//31
				break;
			}
			Button confirm = FindViewById <Button> (Resource.Id.submitCalendar);
			confirm.Click += delegate {
				for (int i=1; i < 32; i++){
					if (allChecks[i].Checked){dates.Add(i);}
				}
				//string[] newDates = new string[32];
				IList <string> newDates = new List<string>{ };
				for (int i=0; i<dates.Count(); i++){
					newDates.Add(dates[i].ToString());
				}
				var finalPage = new Intent(this, typeof(ConfirmDates));
				finalPage.PutExtra ("CurrentMonth",CurrentMonth);
				finalPage.PutStringArrayListExtra ("newDates", newDates);
				StartActivity(finalPage);
			};


			}

	}

}


