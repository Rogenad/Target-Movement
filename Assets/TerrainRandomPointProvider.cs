using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainRandomPointProvider : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    public static TerrainRandomPointProvider Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public Vector3 GetPoint()
    {
        //TODO: не спавнить за большую дверь
        var minPoint = Vector3.zero;
        var maxPoint = terrain.terrainData.size;
        var randomXPoint = Random.Range(minPoint.x, maxPoint.x);
        var randomZPoint = Random.Range(minPoint.z, maxPoint.z);
        return new Vector3(randomXPoint, 0, randomZPoint);
    }
}
