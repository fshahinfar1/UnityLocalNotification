#if UNITY_ANDROID
using UnityEngine;
using UnityLocalNotification;
using System;

public class SimpleLocalNotification : MonoBehaviour
{
    private Publisher publisher;
    public int delaySec;
    public int intervalSec;
    private int notificationId = 123;

    void Start()
    {
        string channelId = "channel_id_1";
        string channelName = "Test Channel";
        string channelDescription = "Test notification are sent througth this channel";

        // with  publisher manager you can get a publisher for your notification channel
        // you can create it with `CreatePublisher` or you can just get a previously created
        // publisher using its channel id with `GetPublisher`.
        // 
        // you should not worry calling `CreatePublisher` multiple times since if 
        // there is a publisher for that channel then it is returned.
        publisher = PublisherManager.Instance.CreatePublisher(channelId,
            channelName, channelDescription);


        // having a notification config is optional
        // it helps to setup some option from inspector instead of
        // writing it in code for each notification you need.
        NotificationConfig notificationConfig = GetComponent<NotificationConfig>();


        // with setting notification config of a publisher if some options of a notification
        // is not set by `Notification` object then they are set from given config.
        publisher.SetNotificationConfig(notificationConfig.GetDataConfig());
    }

    public void SendNow()
    {
        // a `Notification` object is needed for sending notifications
        // it is important that notification have a small icon
        // you can set it to `Notification` object by `SmallIconName` method
        // or you can set Notification config of your publisher and give it through there
        // 
        // you should notice that if you set `NotificationConfig` for publisher and
        // also set data into `Notification` object, data from `Notification` object is
        // used
        Notification notification = new Notification()
                .Title("My notif title")
                .Message("This is a test notification message");


        // sending a notification
        publisher.Publish(notification);
    }

    public void SendWithDelay()
    {
        TimeSpan delay = new TimeSpan(0, 0, seconds: delaySec);

        Notification notification = new Notification()
            .Title("My delayed notif title")
            .Message("This is a test notification message wich had some delayed")
            .Delay(delay);  // set delay time

        // sending a notification
        publisher.Publish(notification);
    }

    public void SendRepeating()
    {
        TimeSpan delay = new TimeSpan(0, 0, seconds: delaySec);
        TimeSpan interval = new TimeSpan(0, 0, seconds: intervalSec);

        Notification notification = new Notification()
            .Id(notificationId) // set a override config's id.
            .Title("My delayed notif title")
            .Message("This is a test notification message wich had some delayed")
            .Delay(delay)  // set delay time
            .Interval(interval);  // set duration between to consequence notification
                                  // if interval is zero then notification is not repeated

        // sending a notification
        publisher.Publish(notification);
    }

    public void CancelRepeating()
    {
        // use notification id to cancel it.
        // it can both cancel repeating and delayed notifications
        Canceler.Instance.Cancel(notificationId);
    }

}
#endif
