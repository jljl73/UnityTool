using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Mignon
{
    /// <summary>
    /// UI에서 Layout을 부모 자식이 같이 쓰고 있으면 동시에 적용이 안되므로 그때 사용
    /// </summary>
    public class AutoLayoutRebuilder : MonoBehaviour
    {
        private void Awake()
        {
            Rebuild();
        }

        private async void Rebuild()
        {
            await UniTask.Yield();
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
        }
    }
}
