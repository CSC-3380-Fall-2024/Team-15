using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 15;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    public int jump = 10;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(speed, speed);
        characterBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if(Input.GetButtonDown("Jump"))
        {
            characterBody.AddForce(new Vector2(characterBody.velocity.x, jump));
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 delta = inputMovement * velocity * Time.deltaTime;
        Vector2 newPosition = characterBody.position + delta;
        characterBody.MovePosition(newPosition);
    }
}