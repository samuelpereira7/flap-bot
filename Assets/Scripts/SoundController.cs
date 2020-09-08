using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController soundCtrl = null;

    private void Awake()
    {
        if (soundCtrl != null)
        {
            Destroy(gameObject);
        }
        else
        {
            soundCtrl = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("score0");
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
