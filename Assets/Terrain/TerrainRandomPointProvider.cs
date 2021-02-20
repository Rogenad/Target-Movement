using UnityEngine;
using Random = UnityEngine.Random;

namespace Terrain
{
    public class TerrainRandomPointProvider : MonoBehaviour
    {
        [SerializeField] 
        private UnityEngine.Terrain _terrain;
        public static TerrainRandomPointProvider Instance { get; private set; }

        public void Awake()
        {
            Instance = this;
        }

        public Vector3 GetPoint()
        {
            //TODO: не спавнить за большую дверь
            var minPoint = Vector3.zero;
            var maxPoint = _terrain.terrainData.size;
            var randomXPoint = Random.Range(minPoint.x, maxPoint.x);
            var randomZPoint = Random.Range(minPoint.z, maxPoint.z);
            return new Vector3(randomXPoint, 0, randomZPoint);
        }
    }
}
