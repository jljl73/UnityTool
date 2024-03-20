using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        static T instance;
        public T Instance
        {
            get
            {
                if (instance == null)
                    instance = new T();
                instance.Init();
                return instance;
            }
        }

        protected virtual void Init()
        {
        }
    }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
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

                instance.Init();
                return instance;
            }
        }

        protected virtual void Init()
        {
        }
    }
}
