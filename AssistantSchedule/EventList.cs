/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Provider;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace AssistantSchedule
{
	[Activity (Label = "Event List")]			
	public class EventList : ListActivity
	{
		int _calId;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.EventList);
			// Create your application here
			//int calId;
			_calId = Intent.GetIntExtra ("calID", -1);

			InitAddEvent ();

		}
		void InitAddEvent ()
		{
			var addSampleEvent = FindViewById<Button> (Resource.Id.addSampleEvent);

			addSampleEvent.Click += (sender, e) => {           
				// Create Event code
				ContentValues eventValues = new ContentValues ();
				eventValues.Put (CalendarContract.Events.InterfaceConsts.CalendarId, _calId);
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Title, "Working");
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Description, "Working a Day shift");
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS (2015, 2, 24, 10, 0));
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS (2015, 2, 24, 11, 0));

				eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
				eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

				var uri = ContentResolver.Insert (CalendarContract.Events.ContentUri, eventValues);
				Console.WriteLine ("Uri for new event: {0}", uri);
			};
		}

		long GetDateTimeMS (int yr, int month, int day, int hr, int min)
		{
			Java.Util.Calendar c = Java.Util.Calendar.GetInstance(Java.Util.TimeZone.Default);

			c.Set (Java.Util.Calendar.DayOfMonth, 23);
			c.Set (Java.Util.Calendar.HourOfDay, hr);
			c.Set (Java.Util.Calendar.Minute, min);
			c.Set (Java.Util.Calendar.Month, Java.Util.Calendar.February);
			c.Set (Java.Util.Calendar.Year, 2015);
			//1424685605802
			return c.TimeInMillis;
		}
	}
}
*/

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
	[Activity (Label = "EventListActivity")]            
	public class EventList : ListActivity
	{   
		int _calId;
		int [] datesChosen = new int[32];
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.EventList);

			_calId = Intent.GetIntExtra ("calId", -1); 
			string CalMonth = Intent.GetStringExtra ("CalMonth") ?? "data not avail.";
			IList <string> newdates;// = new List<string>{ };
			newdates = Intent.GetStringArrayListExtra ("newDates");
			int CurrentMonth = 0;
			if (CalMonth == "January") { 
			} else if (CalMonth == "February") { CurrentMonth = 1;
			} else if (CalMonth == "March") {CurrentMonth = 2;
			} else if (CalMonth == "April") {CurrentMonth = 3;
			} else if (CalMonth == "May") {CurrentMonth = 4;
			} else if (CalMonth == "June") {CurrentMonth = 5;
			} else if (CalMonth == "July") {CurrentMonth = 6;
			} else if (CalMonth == "August") {CurrentMonth = 7;
			} else if (CalMonth == "September") {CurrentMonth = 8;
			} else if (CalMonth == "October") {CurrentMonth = 9;
			} else if (CalMonth == "November") {CurrentMonth = 10;
			} else if (CalMonth == "December") {CurrentMonth = 11;
			} else {
			}  
			//ListEvents ();
			for (int i = 0; i < newdates.Count(); i++) {
				datesChosen[i] = Int32.Parse(newdates[i]);
			}
			var addSampleEvent = FindViewById<Button> (Resource.Id.addSampleEvent);
			addSampleEvent.Click += (sender, e) => { 

				for (int i = 0; i < newdates.Count (); i++) {
					InitAddEvent (CurrentMonth, datesChosen [i]);
				}
			};

		}

	

		void InitAddEvent (int month, int day)
		{

			int currentMonth = month;
			int currentDay = day;
			int hour = 7;
			         
				// Create Event code
				ContentValues eventValues = new ContentValues ();
				eventValues.Put (CalendarContract.Events.InterfaceConsts.CalendarId, _calId);
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Title, "Working");
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Description, "working Day Shift");
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS (2015, month, day, hour, 0));
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS (2015, month, day, hour + 12, 30));

				// GitHub issue #9 : Event start and end times need timezone support.
				// https://github.com/xamarin/monodroid-samples/issues/9
				eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC-5");
				eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC-5");

				var uri = ContentResolver.Insert (CalendarContract.Events.ContentUri, eventValues);
				Console.WriteLine ("Uri for new event: {0}", uri);
			
		}
			
		long GetDateTimeMS (int yr, int month, int day, int hr, int min)
		{
			Java.Util.Calendar c = Java.Util.Calendar.GetInstance (Java.Util.TimeZone.Default);

			c.Set (Java.Util.Calendar.DayOfMonth, day);
			c.Set (Java.Util.Calendar.HourOfDay, hr);
			c.Set (Java.Util.Calendar.Minute, min);
			c.Set (Java.Util.Calendar.Month, month);
			c.Set (Java.Util.Calendar.Year, 2015);

			return c.TimeInMillis;
		}

	}
}

