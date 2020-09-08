using System;
using UnityEngine;

//#if UNITY_ADS
using UnityEngine.Advertisements;
//#endif

public class UnityAdController : MonoBehaviour
{
    [Tooltip("Control to show ads")]
    public static Boolean showAds = true;

    public static DateTime? nextTimeReward = null;

    // Obstacle reference
    public static ObstacleBehavior obstacle;

    public static void ShowAd1()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    public static void ShowAd()
    {
        // ad options
        ShowOptions options = new ShowOptions();
        options.resultCallback = Unpause;

        if (Advertisement.IsReady())
        {
            Advertisement.Show(options);
        }

        // pause the game while the ad is being displayed
        MenuPauseBehavior.paused = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Method responsible for showing ad with reward
    /// </summary>
    public static void ShowRewardAd()
    {
        nextTimeReward = DateTime.Now.AddSeconds(15f);
        if (Advertisement.IsReady())
        {
            MenuPauseBehavior.paused = true;
            Time.timeScale = 0;

            var options = new ShowOptions
            {
                resultCallback = TreatShowResult
            };
            Advertisement.Show(options);
        }
    }

    public static void TreatShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                obstacle.Continue();
                break;

            case ShowResult.Skipped:
                Debug.Log("Ad skipped. No nothing");
                break;

            case ShowResult.Failed:
                Debug.Log("Ad error. Do nothing");
                break;
        }

        MenuPauseBehavior.paused = false;
        Time.timeScale = 1f;
    }

    public static void Unpause(ShowResult result)
    {
        // leave pause mode
        MenuPauseBehavior.paused = false;
        Time.timeScale = 1f;
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
