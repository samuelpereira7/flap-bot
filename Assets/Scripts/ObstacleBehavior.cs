using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehavior : MonoBehaviour
{
    [Tooltip("time to wait before the game starts")]
    public float waitingTime = 2.0f;
    /// <summary>
    /// Reference to player
    /// </summary>
    private GameObject plr;

    [Tooltip("explosion particle system")]
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehavior>())
        {
            collision.gameObject.SetActive(false);
            plr = collision.gameObject;

            if (explosion != null)
            {
                var particles = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(particles, 0.7f);
            }

            //Destroy(collision.gameObject);
            Invoke("ResetGame", waitingTime);
        }
    }

    /// <summary>
    ///  Restart the game
    /// </summary>
    void ResetGame()
    {
        var gameOverMenu = GetGameOverMenu();

        gameOverMenu.SetActive(true);

        var btns = gameOverMenu.transform.GetComponentsInChildren<Button>();
        Button buttonContinue = null;

        foreach (var button in btns)
        {
            if (button.gameObject.name.Equals("ButtonContinue"))
            {
                buttonContinue = button;
                break;
            }
        }

        if (buttonContinue)
        {
            StartCoroutine(ShowContinue(buttonContinue));
            buttonContinue.onClick.AddListener(UnityAdController.ShowRewardAd);
            UnityAdController.obstacle = this;
        }
    }

    public IEnumerator ShowContinue(Button buttonContinue)
    {
        var btnText = buttonContinue.GetComponentInChildren<Text>();

        while (true)
        {
            if (UnityAdController.nextTimeReward.HasValue && (DateTime.Now < UnityAdController.nextTimeReward.Value))
            {
                buttonContinue.interactable = false;

                TimeSpan rem = UnityAdController.nextTimeReward.Value - DateTime.Now;

                var contagemRegressiva = string.Format("{0:D2}:{1:D2}", rem.Minutes, rem.Seconds);
                btnText.text = contagemRegressiva;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                buttonContinue.interactable = true;
                buttonContinue.onClick.AddListener(UnityAdController.ShowRewardAd);
                UnityAdController.obstacle = this;
                btnText.text = "Continue (Ad)";
                break;
            }
        }
    }


    /// <summary>
    /// Continue the game
    /// </summary>
    public void Continue()
    {
        var go = GetGameOverMenu();
        go.SetActive(false);
        plr.SetActive(true);
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Get menuGameOver
    /// </summary>
    /// <returns> gameObject MenuGameOver</returns>
    GameObject GetGameOverMenu()
    {
        return GameObject.Find("Canvas").transform.Find("MenuGameOver").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
