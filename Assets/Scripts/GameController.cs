using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour
{
    [Tooltip("Reference to BasicTile")]
    public Transform tile;

    [Tooltip("Point to place the first BasicTile")]
    public Vector3 startPoint = new Vector3(0, 0, 0);

    [Tooltip("Total of tiles to be created in the begining")]
    [Range(1, 20)]
    public int numSpawnIni;

    [Tooltip("Reference to Obstacle")]
    public Transform obstacle;

    private Vector3 nextTilePos;

    private Quaternion nextTileRot;

    private Vector3 nextObsPos;

    private Quaternion nextObsRot;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("3810017");

        nextTilePos = startPoint;
        nextTileRot = Quaternion.identity;

        nextObsPos = startPoint + new Vector3(3, 0, 0);
        nextObsRot = Quaternion.identity;

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

        Instantiate(obstacle, nextObsPos, nextObsRot);
        nextObsPos = nextTile.position + new Vector3(3, Random.Range(0f, -4.5f), 0);
        nextObsRot = nextTile.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
