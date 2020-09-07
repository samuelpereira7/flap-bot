using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// method to load the scene.
    /// </summary>
    /// <param name="nameScene">Name of scene to load</param>
    public void loadScene(string nameScene)
    {
        if (UnityAdController.showAds)
        {
            // show an ad
            UnityAdController.ShowAd();
        }

        SceneManager.LoadScene(nameScene);

    }
}
