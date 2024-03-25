using Cysharp.Threading.Tasks;
using Mignon.Data;
using Mignon.Util;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UIElements;

namespace Mignon.Game
{
    public class MapData
    {
        public Vector2Int Id;
        public int Tile;
        public BlockTile MapTile;

        public MapData(Vector2Int id, int tile)
        {
            this.Id = id;
            this.Tile = tile;
            MapTile = null;
        }

        public void SetTile(int tile)
        {
            this.Tile = tile;
            MapTile?.SetTile(Tile);
        }

        public void SetOnTile()
        {
            MapTile?.SetOnTile();
        }

        public void Refresh()
        {
            MapTile?.SetTile(Tile);
        }
    }

    public class MapController : ControlBase
    {
        [SerializeField]
        private GameObject tilePrefab;

        private Dictionary<Vector2Int, MapData> MapDatas = new Dictionary<Vector2Int, MapData>();
        
        private readonly int width  = 9;
        private readonly int height = 9;

        public override void Init()
        {
            CreateMapData();

            foreach (var mapData in MapDatas.Values)
            {
                int x = mapData.Id.x;
                int y = mapData.Id.y;

                var newTile = tilePrefab.SpawnObject(transform).GetComponent<BlockTile>();
                newTile.transform.localPosition = new Vector3(x - (height >> 1), y - (width >> 1), 0);

                mapData.MapTile = newTile;
                mapData.Refresh();
            }

            //this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.A)).Subscribe(_ => RefreshMap());
            //this.UpdateAsObservable().Where(_ => Input.GetKeyDown(KeyCode.A)).Subscribe(_ => RefreshMap());
        }

        public override void Dispose()
        {
            foreach (var mapData in MapDatas.Values)
            {
                if (mapData.MapTile != null)
                    mapData.MapTile.gameObject.DespawnObject();
            }

            MapDatas.Clear();
        }

        private void CreateMapData()
        {
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    var mapId = new Vector2Int(i, j);
                    MapDatas.Add(mapId, new MapData(mapId, 0));
                }
            }
        }

        public async UniTask RefreshMapData()
        {
            foreach (var mapData in MapDatas.Values)
                mapData.Refresh();

            await UniTask.Delay(1000);
            CheckLine();
        }

        private void CheckLine()
        {
            List<int> lineX = Enumerable.Range(0, width).ToList();
            List<int> lineY = Enumerable.Range(0, height).ToList();

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    var mapId = new Vector2Int(i, j);
                    if (MapDatas[mapId].Tile == 0)
                    {
                        lineX.Remove(i);
                        lineY.Remove(j);
                    }
                }
            }

            int sum = 0;

            for (int x = 0; x < lineX.Count; ++x)
            {
                for (int j = 0; j < height; ++j)
                {
                    var mapId = new Vector2Int(lineX[x], j);
                    if (MapDatas[mapId].Tile == 0)
                        Debug.LogError(mapId);
                    MapDatas[mapId].SetTile(0);
                }
                ++sum;
            }

            for (int y = 0; y < lineY.Count; ++y)
            {
                for (int i = 0; i < width; ++i)
                {
                    var mapId = new Vector2Int(i, lineY[y]);
                    if (MapDatas[mapId].Tile == 0)
                        Debug.LogError(mapId);
                    MapDatas[mapId].SetTile(0);
                }
                ++sum;
            }

            if (sum > 0)
                DataCenter.Instance.UserData.Score.Value += 1 << (sum - 1);
        }

        public bool CheckBlockAllMap(BlockData blockData)
        {
            foreach (var mapData in MapDatas.Values)
            {
                var isAvailable = CheckBlock(mapData.Id, blockData);
                if (isAvailable)
                    return true;
            }

            return false;
        }



        private bool CheckBlock(Vector2Int mapId, BlockData blockData)
        {
            for (int i = 0; i < blockData.Data.Count; ++i)
            {
                (int x, int y) = MapUtil.IdToCentPoint(i, blockData.Size.y);

                int nx = x + mapId.x;
                int ny = y + mapId.y;

                Vector2Int nMapId = new Vector2Int(nx, ny);
                if (blockData.Data[i] == false)
                    continue;

                if (MapDatas.ContainsKey(nMapId) == false)
                    return false;
                else if (MapDatas[nMapId].Tile > 0)
                    return false;
            }

            return true;
        }

        public bool RayCastTile(Vector2 position, out Vector2Int mapId)
        {
            mapId = new Vector2Int();

            // 쓸 데 없이 다 체크중...
            // TODO: position 주변만 체크하도록 나중에 수정
            foreach (var mapData in MapDatas.Values)
            {
                Vector3 target = mapData.MapTile.transform.position;
                if(Vector3.Distance(position, target) < 0.5f)
                {
                    mapId = mapData.Id;
                    return true;
                }
            }
            return false;
        }

        public void MouseOnTile(Vector2Int mapId, BlockData blockData)
        {
            if (CheckBlock(mapId, blockData) == false)
                return;

            RefreshMapData().Forget();

            for (int i = 0; i < blockData.Data.Count; ++i)
            {
                (int x, int y) = MapUtil.IdToCentPoint(i, blockData.Size.y);

                int nx = x + mapId.x;
                int ny = y + mapId.y;

                Vector2Int nMapId = new Vector2Int(nx, ny);
                if (blockData.Data[i] && MapDatas.ContainsKey(nMapId))
                    MapDatas[nMapId].SetOnTile();
            }
        }


        public bool ChangeTile(Vector2Int mapId, BlockData blockData)
        {
            if (CheckBlock(mapId, blockData) == false)
                return false;

            for (int i = 0; i < blockData.Data.Count; ++i)
            {
                (int x, int y) = MapUtil.IdToCentPoint(i, blockData.Size.y);

                int nx = x + mapId.x;
                int ny = y + mapId.y;

                Vector2Int nMapId = new Vector2Int(nx, ny);
                if (blockData.Data[i] && MapDatas.ContainsKey(nMapId))
                    MapDatas[nMapId].SetTile(1);
            }

            RefreshMapData();
            return true;
        }
    }
}
