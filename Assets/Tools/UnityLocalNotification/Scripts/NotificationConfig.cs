using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using AndroidTools;


/*
*   notification minimum properties needed
*   1) title
*   2) message
*   3) small icon
*/

namespace UnityLocalNotification
{
    public class NotificationConfig : MonoBehaviour
    {

        public enum PreDefinedColor
        {
            Red,
            Green,
            Blue,
            Yellow,
            Magenta,
            Cyan,
            White
        };

        public int priority;
        public string smallIconName;
        public string largeIconName;
        public string bigPictureName;

        public string soundName; // path to URI
        public bool autoCancel = true;

        private NotificationConfigData configData;
        private bool isSet = false;


        public void Awake()
        {
            AndroidJavaObject activityContext = LibraryConfig.Instance.context;
            AndroidJavaObject resource = activityContext.Call<AndroidJavaObject>("getResources");
            string packageName = activityContext.Call<string>("getPackageName");

            configData = new NotificationConfigData();
            configData.Priority(priority);
            configData.AutoCancel(autoCancel);
            configData.SmallIcon(smallIconName);
            configData.SmallIcon(largeIconName);
            configData.BigPicture(bigPictureName);

            int soundRes = -1;
            if (soundName != null)
            {
                soundRes = resource.Call<int>("getIdentifier", soundName, "raw", packageName);
            }

            isSet = true;
        }

        public NotificationConfigData GetDataConfig()
        {
            if (isSet)
                return configData;
            throw new UnityException("NotificationConfig awake function hasn't been called yet");
        }
    }
}
