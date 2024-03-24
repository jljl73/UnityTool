using UnityEngine;

namespace Mignon.Game
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
