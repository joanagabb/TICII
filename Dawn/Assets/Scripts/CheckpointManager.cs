using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    Transform checkpoint;
    public Transform start;
    public Transform lightCollider;

    void Update()
    {
        //Physics2D.IgnoreCollision(lightCollider.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            checkpoint = collision.gameObject.transform.GetChild(0);
        }

        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().estado != "stun")
        {
            Debug.Log("encosto");

            if(gameObject.GetComponent<HeartSystem>().health <= 0)
            {
                gameObject.transform.position = start.position;
            }
            else
            {
                gameObject.transform.position = checkpoint.position;
            }
        }
    }
}
