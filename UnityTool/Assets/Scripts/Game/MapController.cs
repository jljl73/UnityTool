using Mignon.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon.Game
{
    public class MapData
    {
        public int Id;
        public GameObject MapTile;

        public MapData(int id)
        {
            this.Id = id;
            MapTile = null;
        }
    }

    public class MapController : ControlBase
    {
        [SerializeField]
        private GameObject tilePrefab;


        private Dictionary<int, MapData> MapDatas = new Dictionary<int, MapData>();
        
        private readonly int width = 9;
        private readonly int height = 9;

        public override void Init()
        {
            CreateMapData();

            foreach (var mapData in MapDatas.Values)
            {
                (int x, int y) = MapUtil.IdToPoint(mapData.Id, width);
                
                var newTile = tilePrefab.SpawnObject(transform);
                newTile.transform.localPosition = new Vector3(x - (height >> 1), y - (width >> 1), 0);

                mapData.MapTile = newTile;
            }
        }

        public override void Dispose()
        {
            foreach (var mapData in MapDatas.Values)
            {
                if (mapData.MapTile != null)
                    mapData.MapTile.DespawnObject();
            }

            MapDatas.Clear();
        }

        private void CreateMapData()
        {
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    int mapId = MapUtil.PointToId(i, j, width);
                    MapDatas.Add(mapId, new MapData(mapId));
                }
            }
        }
    }
}
