using UnityEngine;

namespace Mignon
{
    public class RandomDistributionTest : MonoBehaviour
    {
        void Start()
        {
            TestRandomRangeInt();
            TestRandomRangeFloat();
            TestRandomValue();
        }

        void TestRandomRangeInt()
        {
            int[] counts = new int[10];
            int trials = 100000;

            for (int i = 0; i < trials; i++)
            {
                int randomInt = Random.Range(0, 10);
                counts[randomInt]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                Debug.Log("Value " + i + ": " + counts[i] + " times");
            }
        }

        void TestRandomRangeFloat()
        {
            int bins = 10;
            int[] counts = new int[bins];
            int trials = 100000;

            for (int i = 0; i < trials; i++)
            {
                float randomFloat = Random.Range(0.0f, 1.0f);
                int bin = Mathf.FloorToInt(randomFloat * bins);
                counts[bin]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                Debug.Log("Range " + (i / (float)bins) + " to " + ((i + 1) / (float)bins) + ": " + counts[i] + " times");
            }
        }

        void TestRandomValue()
        {
            int bins = 10;
            int[] counts = new int[bins];
            int trials = 100000;

            for (int i = 0; i < trials; i++)
            {
                float randomValue = Random.value;
                int bin = Mathf.FloorToInt(randomValue * bins);
                counts[bin]++;
            }

            for (int i = 0; i < counts.Length; i++)
            {
                Debug.Log("Range " + (i / (float)bins) + " to " + ((i + 1) / (float)bins) + ": " + counts[i] + " times");
            }
        }
    }
}