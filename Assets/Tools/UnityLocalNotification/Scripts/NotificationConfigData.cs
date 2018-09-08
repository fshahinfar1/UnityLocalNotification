using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLocalNotification
{
    public class NotificationConfigData
    {
        public int priority;
        public int id;
        public string smallIcon; //res
        public string largeIcon; //res
        public string bigPicture; //res
        public bool autoCancel;

        public NotificationConfigData()
        {
            //LibraryConfig config = LibraryConfig.Instance;
            //AndroidJavaObject resource = config.resource;

            //string packageName = config.context.Call<string>("getPackageName");
            //resource.Call<int>("getIdentifier", "ic_stat_footyard_large_icon", "drawable", packageName)
            priority = 0;
            id = 0;
            smallIcon = "";
            largeIcon = "";
            bigPicture = "";
            autoCancel = true;
        }

	    public NotificationConfigData Priority(int value){
	        priority = value;
	        return this;
	    }

	    public NotificationConfigData SmallIcon(string value){
	        smallIcon = value;
	        return this;
	    }

	    public NotificationConfigData LargeIcon(string value){
	        largeIcon = value;
	        return this;
	    }

	    public NotificationConfigData BigPicture(string value){
	        bigPicture = value;
	        return this;
	    }

	    public NotificationConfigData AutoCancel(bool value){
	        autoCancel = value;
	        return this;
	    }

    }
}
