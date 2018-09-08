using UnityEngine;

namespace UnityLocalNotification
{
    public class ResourceIdManagaer
    {
        private string packageName;
        private AndroidJavaObject resource;

        private static ResourceIdManagaer instance;
        public static ResourceIdManagaer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceIdManagaer();
                }
                return instance;
            }
        }

        private ResourceIdManagaer()
        {
            AndroidJavaObject activityContext = LibraryConfig.Instance.context;
            resource = activityContext.Call<AndroidJavaObject>("getResources");
            packageName = activityContext.Call<string>("getPackageName");
        }

        public int GetResourceId(string name, string category)
        {
            return resource.Call<int>("getIdentifier", name, category, packageName);
        }
    }
}