using Mignon.Util;
using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Mignon.Game
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private GameObject          tilePrefab;
        [SerializeField]
        private Transform           tileTrans;

        private Vector3             originPosition;
        private Vector2Int          onMapId;

        private List<IDisposable>   mouseSubscription = new List<IDisposable>();
        private List<GameObject>    tiles = new List<GameObject>();

        public BlockData BlockData { get; private set; }

        public void LoadData(BlockData blockData)
        {
            this.BlockData  = blockData;
            int width       = blockData.Size.x;
            int height      = blockData.Size.y;

            for (int i = 0; i < blockData.Size.x; ++i)
            {
                for (int j = 0; j < blockData.Size.y; ++j)
                {
                    int id = MapUtil.PointToId(i, j, blockData.Size.y);
                    if (blockData.Data[id])
                    {
                        var newTile = tilePrefab.SpawnObject(tileTrans);
                        newTile.transform.localPosition = new Vector3(i - (height >> 1), j - (width >> 1), 0);
                        tiles.Add(newTile);
                    }
                }
            }
        }

        public void Init()
        {
            originPosition          = transform.localPosition;
            tileTrans.localScale    = Vector3.one * 0.5f;

            var downSub = gameObject.OnMouseDownAsObservable()
                .Subscribe(_ => tileTrans.localScale = Vector3.one);

            var dragSub = gameObject.OnMouseDragAsObservable()
                .Select(_ => Camera.main.ScreenToWorldPoint(Input.mousePosition))
                .Subscribe(pos =>
                {
                    pos.z = 0;
                    pos += new Vector3(0, 1.0f, 0);
                    transform.position = pos;
                    OnTileEnter(pos);
                });

            var upSub = gameObject.OnMouseUpAsObservable()
                .Subscribe(_ =>
                {
                    tileTrans.localScale = Vector3.one * 0.5f;
                    transform.localPosition = originPosition;
                    ChangeTile();
                });

            mouseSubscription.Add(downSub);
            mouseSubscription.Add(dragSub);
            mouseSubscription.Add(upSub);
        }


        public void Dispose()
        {
            BlockData = null;
            tileTrans.localScale = Vector3.one;
            transform.localPosition = originPosition;

            for (int i = 0; i < tiles.Count; ++i)
                tiles[i].DespawnObject();
            tiles.Clear();

            for (int i = 0; i < mouseSubscription.Count; ++i)
                mouseSubscription[i].Dispose();
            mouseSubscription.Clear();
        }

        public void OnTileEnter(Vector3 position)
        {
            if (GameManager.Instance.MapController.RayCastTile(position, out onMapId))
                GameManager.Instance.MapController.MouseOnTile(onMapId, BlockData);
            else
                GameManager.Instance.MapController.RefreshMapData();
        }

        public void ChangeTile()
        {
            if (GameManager.Instance.MapController.ChangeTile(onMapId, BlockData))
                GameManager.Instance.BlockController.UseBlock(this);
        }
    }
}
