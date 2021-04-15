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
        float movement = Input.GetAxis("Horizontal");
        Walk(movement);

        if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            Jump();
        }
    }

    void Walk(float movement)
    {
        transform.position += new Vector3(movement, 0) * Time.deltaTime * speed;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
