using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Mignon
{
    /// <summary>
    /// UI���� Layout�� �θ� �ڽ��� ���� ���� ������ ���ÿ� ������ �ȵǹǷ� �׶� ���
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
