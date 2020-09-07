using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if(collision.gameObject.GetComponent<PlayerBehavior>())
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
            buttonContinue.onClick.AddListener(UnityAdController.ShowRewardAd);
            UnityAdController.obstacle = this;
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*
        var gameOverMenu = GetGameOverMenu();
        gameOverMenu.SetActive(true);

        var botoes = gameOverMenu.transform.GetComponentsInChildren<Button>();
        Button botaoContinue = null;

        foreach (var botao in botoes)
        {
            if (botao.gameObject.name.Equals("BotaoContinuar")) ;
            {
                botaoContinue = botao;
                break;
            }
        }

        if (botaoContinue)
        {
            StartCoroutine(ShowContinue(botaoContinue));

            botaoContinue.onClick.AddListener(UnityAdControle.ShowRewardAd);
            UnityAdControle.obstaculo = this;
        }

        // reinicia o jogo
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        */
    }
    /// <summary>
    /// Continue the game
    /// </summary>
    public void Continue()
    {
        var go = GetGameOverMenu();
        go.SetActive(false);
        plr.SetActive(true);
    }
    /// <summary>
    /// Find menuGameOver
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
