using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*
    [Tooltip("alvo a ser acompanhado pela camera")]
    public Transform alvo;

    [Tooltip("offset da camera em relacao ao alvo")]
    public Vector3 offset = new Vector3(3, 0, -6);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alvo != null)
        {
            // altera a posicao da camera
            transform.position = alvo.position + offset;

            // altera a rotacao da camera em relacao ao jogador
            transform.LookAt(alvo);
        }
    }*/


    public Transform alvo;
    float cameraZ;

    // Use this for initialization
    void Start()
    {
        cameraZ = transform.position.z;
    }


    void Update()
    {
        transform.position = new Vector3(alvo.position.x + 0.5f, 0, cameraZ);

    }


    
}
