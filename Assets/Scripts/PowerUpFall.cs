using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PowerUpFall : MonoBehaviour
{
       private Rigidbody2D rb;
    public LayerMask platformLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the power-up is falling and if it hits a platform
        if (rb.velocity.y < 0f)  // If the power-up is falling
        {
            // Raycast downwards to check for platform
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, platformLayer);
            if (hit.collider != null)
            {
                // Stop falling once it hits the platform
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f; // Disable gravity
            }
        }
    }

}
