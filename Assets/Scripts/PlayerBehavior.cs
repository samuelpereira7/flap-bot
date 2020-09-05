using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehavior : MonoBehaviour
{
    // reference to the Rigidbody component
    private Rigidbody2D rb;

    [Tooltip("horizontal speed of the player")]
    public float horizontalSpeed = 2.0f;

    [Tooltip("jump speed of the player")]
    public float jumpSpeed = 7.0f;

    [Tooltip("torque")]
    public float torque = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.SetRotation(90);
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuPauseBehavior.paused)
            return;

        // boost on X axis
        transform.position += new Vector3(Time.deltaTime * horizontalSpeed, 0, 0);

        if (WasTouchedOrClicked())
        {
            // boost on Y axis
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpSpeed);
        }



        //rb.AddTorque(-torque);
    }

    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButton(0) ||
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }
}
