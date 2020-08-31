using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // reference to the Rigidbody component
    private Rigidbody2D rb;

    [Tooltip("horizontal speed of the player")]
    public float horizontalSpeed = 2.0f;

    [Tooltip("torque")]
    public float torque = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var force = new Vector2(horizontalSpeed, 0);

        rb.AddForce(force);
        rb.AddTorque(-torque);
        
    }
}
