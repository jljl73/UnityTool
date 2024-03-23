using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.Data
{
    public abstract class DataModelBase
    {
        public abstract void Init();
        public abstract void Dispose();
    }


    public class DataCenter : Singleton<DataCenter>
    {
        public UserData UserData { get; private set; }

        List<DataModelBase> dataModels = new List<DataModelBase>();

        public override void Init()
        {
            dataModels.Clear();
            
            UserData = new UserData();
            dataModels.Add(UserData);

            for (int i = 0; i < dataModels.Count; ++i)
                dataModels[i].Init();
        }

        public void Dispose()
        {
            for (int i = 0; i < dataModels.Count; ++i)
                dataModels[i].Dispose();
            dataModels.Clear();
        }
    }
}
