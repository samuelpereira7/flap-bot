using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Target to be followed by the camera")]
    public Transform target;

    private float cameraZ;

    // Use this for initialization
    void Start()
    {
        cameraZ = transform.position.z;
    }


    void Update()
    {
        if(target)
            transform.position = new Vector3(target.position.x + 0.5f, 0, cameraZ);
    }
}
