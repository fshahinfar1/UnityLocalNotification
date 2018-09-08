using UnityEngine;
using System.Collections.Generic;

namespace UnityLocalNotification
{
    public class PublisherManager
    {
        private static PublisherManager instance;
        public static PublisherManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PublisherManager();
                }
                return instance;
            }
        }

        private Dictionary<string, Publisher> publishers;

        private PublisherManager()
        {
            publishers = new Dictionary<string, Publisher>();
        }

        public Publisher CreatePublisher(string channelId, string channelName, string channelDescription)
        {
            if (publishers.ContainsKey(channelId))
            {
                return publishers[channelId];
            }

            Publisher p = new Publisher(channelId, channelName, channelDescription);
            publishers.Add(channelId, p);
            return p;
        }

        public Publisher GetPublisher(string channelId)
        {
            if (publishers.ContainsKey(channelId))
            {
                return publishers[channelId];
            }

            throw new UnityException("No publisher for given channel id [you can create one by CreatePublisher]");
        }

    }
}