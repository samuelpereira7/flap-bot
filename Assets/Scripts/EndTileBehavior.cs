using UnityEngine;

public class EndTileBehavior : MonoBehaviour
{
    [Tooltip("time waited to destroy BasicTile")]
    public float timeDestroy = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the player has passed through the end of the BasicTile
        if (other.GetComponent<PlayerBehavior>())
        {
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();

            // destroy the BasicTile
            Destroy(transform.parent.gameObject, timeDestroy);
        }
    }
}
