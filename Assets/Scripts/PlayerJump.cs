using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private RigidBody2D rb;
    public float jump = 10;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize rigidbody object
        rb = GetComponent<RigidBody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump))
        }
    }
}
