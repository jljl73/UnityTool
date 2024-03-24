using UnityEngine;

namespace Mignon.Game
{
    public class BlockTile : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;
        private int tileValue;

        public void SetTile(int tile)
        {
            tileValue = tile;
            if (tile == 0)
                spriteRenderer.color = new Color(1, 1, 1, 0.2f);
            else
                spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        public void SetOnTile()
        {
            if (tileValue == 0)
                spriteRenderer.color = new Color(1, 1, 1, 0.7f);
        }
    }
}
