using UnityEngine;
using System.Collections.Generic;

namespace UnityLocalNotification
{
    public class Publisher
    {

        private AndroidJavaObject publisher;
        private NotificationConfigData nConfig;

        internal Publisher(string channelId, string channelName, string channelDescription)
        {
            LibraryConfig config = LibraryConfig.Instance;
            publisher = new AndroidJavaObject(config.PACKAGE_NAME + ".Publisher",
                channelId, channelName, channelDescription, config.context);
        }

        public void SetNotificationConfig(NotificationConfigData config)
        {
            nConfig = config;
        }

        public void Publish(Notification notification)
        {
            int id = notification.id;
            HashSet<string> setFields = notification.setFields;
            if (nConfig != null)
            {
                if (id == -1)
                {
                    id = nConfig.id;
                }
                if (!setFields.Contains("small_icon"))
                {
                    string name = nConfig.smallIcon;
                    if (name != "")
                    {
                        notification.SmallIconName(name);
                    }
                    else
                    {
                        throw new UnityException("Small icon should be set");
                    }
                }
                if (!setFields.Contains("priority"))
                {
                    notification.Priority(nConfig.priority);
                }
                if (!setFields.Contains("large_icon"))
                {
                    string name = nConfig.largeIcon;
                    if (name != "")
                        notification.LargeIconName(name);
                }
                if (!setFields.Contains("big_picture"))
                {
                    string name = nConfig.bigPicture;
                    if (name != "")
                        notification.BigPictureName(name);
                }
                if (!setFields.Contains("auto_cancel"))
                {
                    notification.AutoCancel(nConfig.autoCancel);
                }
            }
            else
            {
                if (!setFields.Contains("small_icon"))
                {
                    throw new UnityException("Small icon should be set");
                }
            }
            publisher.Call("publish", notification.GetData(), notification.id,
                notification.delaySeconds, notification.intervalSeconds);
        }

    }
}
