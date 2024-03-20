using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.Reddot
{
    public class ReddotManager : MonoSingleton<ReddotManager>
    {
        private Dictionary<int, Reddot> reddotDict = new Dictionary<int, Reddot>();

        protected override void Init()
        {
            // TODO : Init Setting

            // Example
            var defaultCondition = new DefaultReddotCondition();
            Add(0, defaultCondition);
            Add(1, 0, defaultCondition);
            Add(2, 0, defaultCondition);
        }

        public void Add(int key, iReddotCondition condition)
        {
            var newReddot = new Reddot(key, condition);
            reddotDict.Add(key, newReddot);
        }

        public void Add(int key, int parentKey, iReddotCondition condition)
        {
            var newReddot = new Reddot(key, condition);
            reddotDict.Add(key, newReddot);

            reddotDict[key].SetParent(parentKey);
            reddotDict[parentKey].AddChild(key);

            reddotDict.Add(key, newReddot);
        }

        public void SetOn(int key, bool value)
        {
            var reddot = reddotDict[key];
            if (reddot.ParentKey == -1)
                return;

            var parent = reddotDict[reddot.ParentKey];
            if (value)
                parent.SetOn(key);
            else
                parent.SetOff(key);
            
            SetOn(reddot.ParentKey, value);
        }

        public bool IsOn(int key)
        {
            var reddot = reddotDict[key];
            return reddot.IsOn();
        }
    }
}
