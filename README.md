# Unity Local Notification (For android)
This repository allows to send local notification from unity project
on android devices.

## Features
* you can send local notification in android
* you can schedule sending notification for some time in future
* you can send notification having big picture style

## Issues
* not all android notification features are supported

## Sample code
```
Publisher publisher = PublisherManager.Instance.CreatePublisher(channelId,
  channelName, channelDescription);

// put your icon png file in Plugins/Android/UnityLocalNotification/res/drawable
Notification notification = new Notification()
  .SmallIconName("test_icon")  
  .Title("My notif title")
  .Message("This is a test notification message");

publisher.Publish(notification);
```

## Screenshots
<img src="/Documents/Screenshot_20180909-085228.png" width="300">

## Unity asset
[Unity local notification asset](UnityLocalNotificationAsset.unitypackage)

## Class diagram
[class diagram](/Documents/classDiagram.png)
