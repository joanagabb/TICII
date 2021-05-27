using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 15;
    float jumpForce = 20;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    } 

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        Walk(movementX);

        if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            Jump();
        }
    }

    void Walk(float movementX)
    {
        Vector2 movement = new Vector2(movementX * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
