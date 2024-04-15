using UnityEngine;

namespace Mignon.Util
{
    public class SafeArea : MonoBehaviour
    {
        private RectTransform panel;
        private Rect lastSafeArea = new Rect(0, 0, 0, 0);
        private Vector2Int lastScreenSize = new Vector2Int(0, 0);
        private ScreenOrientation lastOrientation = ScreenOrientation.AutoRotation;

        // 해상도 좌우 대응
        [SerializeField]
        private bool left = true;
        [SerializeField]
        private bool right = true;

        [SerializeField]
        private bool top = true;
        [SerializeField]
        private bool bottom = true;

        void Awake()
        {
            panel = transform as RectTransform;

            if (panel == null)
            {
                Debug.LogError("No RectTransform" + gameObject.name);
                return;
            }

            Refresh();
        }

        /// <summary>
        /// 변화 감지
        /// </summary>
        //private void Update()
        //{
        //    Refresh();
        //}

        private void Refresh()
        {
            Rect safeArea = Screen.safeArea;

            if (safeArea != lastSafeArea || Screen.width != lastScreenSize.x || Screen.height != lastScreenSize.y || Screen.orientation != lastOrientation)
            {
                lastScreenSize.x = Screen.width;
                lastScreenSize.y = Screen.height;
                lastOrientation = Screen.orientation;

                ApplySafeArea(safeArea);
            }
        }

        private void ApplySafeArea(Rect r)
        {
            lastSafeArea = r;
            if (Screen.width > 0 && Screen.height > 0)
            {
                Vector2 anchorMin = r.position;
                Vector2 anchorMax = r.position + r.size;

                if (!left)
                    anchorMin.x = 0;

                if (!right)
                    anchorMax.x = Screen.width;

                if (!bottom)
                    anchorMin.y = 0;

                if (!top)
                    anchorMax.y = Screen.height;

                anchorMin.x /= Screen.width;
                anchorMax.x /= Screen.width;
                anchorMin.y /= Screen.height;
                anchorMax.y /= Screen.height;

                if (anchorMin.x >= 0 && anchorMin.y >= 0 && anchorMax.x >= 0 && anchorMax.y >= 0)
                {
                    panel.anchorMin = anchorMin;
                    panel.anchorMax = anchorMax;
                }
            }

        }
    }
}
