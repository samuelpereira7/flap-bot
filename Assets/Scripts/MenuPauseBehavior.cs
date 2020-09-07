using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseBehavior: MonoBehaviour
{
    
    public static bool paused;

    [SerializeField]
    private GameObject menuPausePanel;
    /// <summary>
    /// Method to restart the scene.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    /// <summary>
    /// Method to pause the game.
    /// </summary>
    /// <param name="isPaused"></param>
    public void Pause(bool isPaused)
    {
        paused = isPaused;
        
        Time.timeScale = (paused) ? 0 : 1;

        menuPausePanel.SetActive(paused);

    }
    /// <summary>
    /// method to load the scene.
    /// </summary>
    /// <param name="nameScene">Name of scene to load</param>
    public void loadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);

    }

    // Start is called before the first frame update
    void Start()
    {
        //paused = false;
        Pause(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
