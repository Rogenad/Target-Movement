using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainRandomPointProvider : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    public Vector3 GetPoint()
    {
        var minPoint = Vector3.zero;
        var maxPoint = terrain.terrainData.size;
        var randomXPoint = Random.Range(minPoint.x, maxPoint.x);
        var randomZPoint = Random.Range(minPoint.z, maxPoint.z);
        return new Vector3(randomXPoint, 0, randomZPoint);
    }
}
