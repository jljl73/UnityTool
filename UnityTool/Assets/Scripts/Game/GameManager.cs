using Mignon.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mignon
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [Header("Controller")]
        [SerializeField]
        private MapController   mapController;
        public MapController    MapController       => mapController;

        [SerializeField]
        private BlockController blockController;
        public BlockController  BlockController     => blockController;

        public void Initialize()
        {
            mapController.Init();
            blockController.Init();
        }

        public void Dispose()
        {
            mapController.Dispose();
            blockController.Dispose();
        }
    }
}
