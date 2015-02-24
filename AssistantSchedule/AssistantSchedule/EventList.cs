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

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.EventList);

			_calId = Intent.GetIntExtra ("calId", -1); 

			//ListEvents ();

			InitAddEvent ();
		}

	/*	void ListEvents ()
		{       
			var eventsUri = CalendarContract.Events.ContentUri;

			string[] eventsProjection = { 
				CalendarContract.Events.InterfaceConsts.Id,
				CalendarContract.Events.InterfaceConsts.Title,
				CalendarContract.Events.InterfaceConsts.Dtstart
			};

			var cursor = ManagedQuery (eventsUri, eventsProjection, 
				String.Format ("calendar_id={0}", _calId), null, "dtstart ASC");

			string[] sourceColumns = {
				CalendarContract.Events.InterfaceConsts.Title, 
				CalendarContract.Events.InterfaceConsts.Dtstart
			};

			int[] targetResources = { Resource.Id.eventTitle, Resource.Id.eventStartDate };

			var adapter = new SimpleCursorAdapter (this, Resource.Layout.EventList, 
				cursor, sourceColumns, targetResources); 

			//adapter.ViewBinder = new ViewBinder ();

			ListAdapter = adapter;

		
		}*/

		void InitAddEvent ()
		{
			var addSampleEvent = FindViewById<Button> (Resource.Id.addSampleEvent);

			addSampleEvent.Click += (sender, e) => {           
				// Create Event code
				ContentValues eventValues = new ContentValues ();
				eventValues.Put (CalendarContract.Events.InterfaceConsts.CalendarId, _calId);
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Title, "Working");
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Description, "working Day Shift");
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS (2011, 12, 15, 12, 0));
				eventValues.Put (CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS (2011, 12, 15, 25, 30));

				// GitHub issue #9 : Event start and end times need timezone support.
				// https://github.com/xamarin/monodroid-samples/issues/9
				eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC-5");
				eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC-5");

				var uri = ContentResolver.Insert (CalendarContract.Events.ContentUri, eventValues);
				Console.WriteLine ("Uri for new event: {0}", uri);
			};
		}

		/*class ViewBinder : Java.Lang.Object, SimpleCursorAdapter.IViewBinder
		{     
			public bool SetViewValue (View view, Android.Database.ICursor cursor, int columnIndex)
			{
				if (columnIndex == 2) {
					long ms = cursor.GetLong (columnIndex);

					DateTime date = 
						new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds (ms).ToLocalTime ();

					TextView textView = (TextView)view;
					textView.Text = date.ToLongDateString ();

					return true;
				}
				return false;
			}     
		}*/

		long GetDateTimeMS (int yr, int month, int day, int hr, int min)
		{
			Java.Util.Calendar c = Java.Util.Calendar.GetInstance (Java.Util.TimeZone.Default);

			c.Set (Java.Util.Calendar.DayOfMonth, 25);
			c.Set (Java.Util.Calendar.HourOfDay, hr);
			c.Set (Java.Util.Calendar.Minute, min);
			c.Set (Java.Util.Calendar.Month, Java.Util.Calendar.February);
			c.Set (Java.Util.Calendar.Year, 2015);

			return c.TimeInMillis;
		}

	}
}

