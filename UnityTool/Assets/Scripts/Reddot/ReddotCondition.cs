using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.Reddot
{
    public interface iReddotCondition
    {
        bool IsOn();
    }

    public class DefaultReddotCondition : iReddotCondition
    {
        public bool IsOn()
        {
            return false;
        }
    }
}
