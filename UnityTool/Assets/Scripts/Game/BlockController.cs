using Mignon.Util;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Mignon.Game
{
    public class BlockController : ControlBase
    {
        [SerializeField]
        private GameObject      blockPrefab;
        [SerializeField]
        private Transform[]     blockSlotTrans;

        [Header("블록 데이터")]
        [SerializeField]
        private List<BlockData> blockDatas = new List<BlockData>();
        
        private List<Block>     spawnBlocks = new List<Block>();


        public override void Init()
        {
            CreateRandomBlocks();
        }

        public override void Dispose()
        {
        }

        public void CreateRandomBlocks()
        {
            for(int i = 0; i < blockSlotTrans.Length; ++i)
            {
                var newBlock = blockPrefab.SpawnObject(blockSlotTrans[i]).GetComponent<Block>();
                newBlock.LoadData(blockDatas[Random.Range(0, blockDatas.Count)]);
                newBlock.Init();
                
                spawnBlocks.Add(newBlock);
            }
        }
    }
}
