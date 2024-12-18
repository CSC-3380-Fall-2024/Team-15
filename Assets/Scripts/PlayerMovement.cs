using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float horizontalInput;
    public float moveSpeed = 5f;
    bool isFacingLeft = false;
    public float jumpPower = 5f;
    bool isGrounded = false;
    Rigidbody2D rb;
    Animator animator;
    public LayerMask groundLayer;
    public Transform groundCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();
        if(Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if(isFacingLeft && horizontalInput > 0f || !isFacingLeft && horizontalInput < 0f)
        {
            isFacingLeft = !isFacingLeft;
            Vector3 jp = transform.localScale;
            jp.x *= -1f;
            transform.localScale = jp;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }

}