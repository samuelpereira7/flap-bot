using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehavior : MonoBehaviour
{
    [Tooltip("time to wait before the game starts")]
    public float waitingTime = 2.0f;

    [Tooltip("explosion particle system")]
    public GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerBehavior>())
        {
            if (explosion != null)
            {
                var particles = Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
                Destroy(particles, 1.0f);
            }

            Destroy(collision.gameObject);
            Invoke("ResetGame", waitingTime);
        }
    }

    /// <summary>
    ///  Restart the game
    /// </summary>
    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
