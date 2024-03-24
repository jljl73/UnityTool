using Mignon.Game;
using Mignon.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private GameObject tilePrefab;
        [SerializeField]
        private Transform tileTrans;

        public void LoadData(BlockData blockData)
        {
            int width = blockData.Size.x;
            int height = blockData.Size.y;

            for (int i = 0; i < blockData.Size.x; ++i)
            {
                for (int j = 0; j < blockData.Size.y; ++j)
                {
                    int id = MapUtil.PointToId(i, j, blockData.Size.y);
                    if (blockData.Data[id])
                    {
                        var newTile = tilePrefab.SpawnObject(tileTrans);
                        newTile.transform.localPosition = new Vector3(i - (height >> 1), j - (width >> 1), 0);
                    }
                }
            }
        }

        public void Init()
        {
            tileTrans.localScale = Vector3.one * 0.5f;
        }


        public void Dispose()
        {

        }
    }
}
