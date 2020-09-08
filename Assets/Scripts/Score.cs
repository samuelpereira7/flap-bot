using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("new score1 agr vai porra");

        if (other.GetComponent<PlayerBehavior>())
        {
            score += 100;
            Debug.Log("new score2" + score.ToString());
            GameObject.Find("Canvas").transform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        }
    }

    /*  private void OnTriggerEnter2D(Collider2D other)
      {
          // check if the player has passed through the end of the BasicTile
          if (other.GetComponent<PlayerBehavior>())
          {
              GameObject.FindObjectOfType<GameController>().SpawnNextTile();

              // destroy the BasicTile
              Destroy(transform.parent.gameObject, timeDestroy);
          }
      }*/

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
