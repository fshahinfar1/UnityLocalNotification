using UnityEngine;

namespace UnityLocalNotification
{
    public class Canceler
    {
        private static Canceler instance;
        public static Canceler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Canceler();
                }
                return instance;
            }
        }

        private AndroidJavaClass canceler;
        private AndroidJavaObject context;

        private Canceler()
        {
            LibraryConfig config = LibraryConfig.Instance;
            canceler = new AndroidJavaClass(config.PACKAGE_NAME + ".ScheduleCanceler");
            context = config.context;
        }

        public void Cancel(int notificationId)
        {
            canceler.CallStatic("Cancel", context, notificationId);
        }
    }
}