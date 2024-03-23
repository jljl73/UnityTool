using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Mignon.Data
{
    public class UserData : DataModelBase
    {
        private ReactiveProperty<int> gold = new ReactiveProperty<int>();
        public IReactiveProperty<int> Gold => gold;
        public override void Init()
        {
        }

        public override void Dispose()
        {
        }

        //public int Gold
        //{
        //    get { return gold.Value; }
        //    set { gold.Value = value; }
        //}
    }
}
