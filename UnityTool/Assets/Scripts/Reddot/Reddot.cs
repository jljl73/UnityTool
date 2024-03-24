using System.Collections.Generic;

namespace Mignon.Reddot
{
    public class Reddot
    {
        public int Key              { get; private set; }
        public int ParentKey        { get; private set; }   = -1;

        private List<int>           reddotChildren          = new List<int>();
        private List<int>           onReddotChildren        = new List<int>();
        private iReddotCondition    condition;

        public Reddot(int key, iReddotCondition condition)
        {
            this.Key        = key;
            this.condition  = condition;
        }

        public void SetParent(int parentKey)
        {
            this.ParentKey = parentKey;
        }

        public void AddChild(int childKey)
        {
            reddotChildren.Add(childKey);
        }

        public void SetOn(int childKey)
        {
            if (onReddotChildren.Contains(childKey) == false)
                onReddotChildren.Add(childKey);
        }
        
        public void SetOff(int childKey)
        {
            onReddotChildren.Remove(childKey);
        }
        
        public bool IsOn()
        {
            if (reddotChildren.Count == 0)
                return condition.IsOn();

            for (int i = 0; i < reddotChildren.Count; ++i)
            {
                if (ReddotManager.Instance.IsOn(reddotChildren[i]))
                    return true;
            }

            return condition.IsOn();
        }
    }
}
