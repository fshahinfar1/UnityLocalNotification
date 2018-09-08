using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AndroidTools;

namespace UnityLocalNotification
{
    public class Notification
    {
        internal int id;
        internal long delaySeconds;
        internal long intervalSeconds;
        private AndroidBundle data;
        private ResourceIdManagaer resIdMan;

        internal HashSet<string> setFields;


        public Notification()
        {
            data = new AndroidBundle();
            resIdMan = ResourceIdManagaer.Instance;
            setFields = new HashSet<string>();

            this.id = -1;

            // set the needed data for notification to open the game
            data.Put<string>("app_package_name", Application.identifier);
        }

        public Notification Id(int id)
        {
            this.id = id;
            setFields.Add("id");
            return this;
        }

        public Notification Priority(int priority)
        {
            data.Put<int>("notification_priority", priority);
            setFields.Add("priority");
            return this;
        }

        public Notification Title(string title)
        {
            data.Put<string>("text_title", title);
            setFields.Add("text_title");
            return this;
        }

        public Notification Message(string message)
        {
            data.Put<string>("text_content", message);
            setFields.Add("text_content");
            return this;
        }

        
        public Notification Delay(TimeSpan delay)
        {
            this.delaySeconds = (long)delay.TotalSeconds;
            setFields.Add("delay");
            return this;
        }

        public Notification Interval(TimeSpan interval)
        {
            this.intervalSeconds = (long)interval.TotalSeconds;
            setFields.Add("interval");
            return this;
        }

        public Notification SmallIconName(string name)
        {
            int resId = resIdMan.GetResourceId(name, "drawable");
            data.Put<int>("icon_res", resId);
            setFields.Add("small_icon");
            return this;
        }

        public Notification LargeIconName(string name)
        {
            int resId = resIdMan.GetResourceId(name, "drawable");
            data.Put<int>("large_icon_res", resId);
            setFields.Add("large_icon");
            return this;
        }

        public Notification BigPictureName(string name)
        {
            int resId = resIdMan.GetResourceId(name, "drawable");
            data.Put<int>("big_picture_res", resId);
            setFields.Add("big_picture");
            return this;
        }

        public Notification AutoCancel(bool value)
        {
            data.Put<bool>("auto_cancel", value);
            setFields.Add("auto_cancel");
            return this;
        }

        public AndroidJavaObject GetData()
        {
            return data.Bundle;
        }

    }

}
