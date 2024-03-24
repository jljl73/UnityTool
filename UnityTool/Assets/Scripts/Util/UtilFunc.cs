using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon
{
    public class UtilFunc
    {
        public static void Shuffle<T>(List<T> list)
        {
            System.Random random = new System.Random();
            int n = list.Count;
            for (int i = 0; i < (n - 1); ++i)
            {
                int r   = i + random.Next(n - i);
                T t     = list[r];
                list[r] = list[i];
                list[i] = t;
            }
        }

        public async static UniTask DoNumberText(Action<int> onUpdateText, int startValue, int endValue, int duration = 600)
        {
            if (startValue == endValue)
            {
                onUpdateText?.Invoke(endValue);
                return;
            }

            int targetFrame = Application.targetFrameRate;
            if (targetFrame < 1)
                targetFrame = 30;

            int diff = (endValue - startValue) / (duration / targetFrame);
            bool isPlus = endValue > startValue;
            
            if (startValue < endValue)
                ++diff;
            else
                --diff;

            while (startValue != endValue)
            {
                await UniTask.NextFrame();
                startValue += diff;
                if (isPlus)
                    startValue = Math.Min(startValue, endValue);
                else
                    startValue = Math.Max(startValue, endValue);

                onUpdateText?.Invoke(startValue);
            }
        }
    }
}
