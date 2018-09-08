using UnityEngine;


namespace UnityLocalNotification
{
    public class LibraryConfig
    {
        private static LibraryConfig instance;
        public static LibraryConfig Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LibraryConfig();
                }
                return instance;
            }
        }

        public readonly string PACKAGE_NAME = "shahinfar.farbod.unitylocalnotificationlibrary";
        public readonly AndroidJavaObject context;
        public readonly AndroidJavaObject resource;

        private LibraryConfig()
        {
            AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            context = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            resource = context.Call<AndroidJavaObject>("getResources");
        }

    }
}