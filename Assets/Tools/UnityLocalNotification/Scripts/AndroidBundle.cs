using UnityEngine;

namespace AndroidTools
{
    public class AndroidBundle
    {
        private AndroidJavaObject mBundle;

        public AndroidJavaObject Bundle { get { return this.mBundle; } }

        public AndroidBundle()
        {
            this.mBundle = new AndroidJavaObject("android.os.Bundle");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">string, int, bool, double, float</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public AndroidBundle Put <T> (string key, T value)
        {
            if(value is string)
            {
                mBundle.Call("putString", key, value);
            }
            else if (value is int)
            {
                mBundle.Call("putInt", key, value);
            }
            else if (value is double)
            {
                mBundle.Call("putDouble", key, value);
            }
            else if (value is bool)
            {
                mBundle.Call("putBoolean", key, value);
            }
            else if (value is float)
            {
                mBundle.Call("putFloat", key, value);
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>type is object</returns>
        public object Get(string key)
        {
            return mBundle.Call<object>("get", key);
        }
    }
}