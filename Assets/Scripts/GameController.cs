using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Tooltip("Reference to BasicTile")]
    public Transform tile;

    [Tooltip("Point to place the first BasicTile")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Total of tiles to be created in the begining")]
    [Range(1, 20)]
    public int numSpawnIni;

    private Vector3 nextTilePos;

    private Quaternion nextTileRot;

    // Start is called before the first frame update
    void Start()
    {
        nextTilePos = startPoint;
        nextTileRot = Quaternion.identity;

        for (int i = 0; i < numSpawnIni; i++)
        {
            SpawnNextTile();
        }
    }

    public void SpawnNextTile()
    {
        var newTile = Instantiate(tile, nextTilePos, nextTileRot);
        var nextTile = newTile.Find("SpawnPoint");
        nextTilePos = nextTile.position;
        nextTileRot = nextTile.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
