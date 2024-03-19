using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon
{
    public class Singleton<T> where T : class, new()
    {
        static T instance;
        public T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
        }
    }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = GameObject.FindObjectOfType<T>();

                if(instance == null)
                {
                    GameObject singleton = new GameObject();
                    instance = singleton.AddComponent<T>();
                    instance.name = typeof(T).Name;
                }    

                return instance;
            }
        }
    }
}
