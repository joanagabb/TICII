using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    Transform checkpoint;
    public Transform start;
    public Transform lightCollider;

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            checkpoint = collision.gameObject.transform.GetChild(0);
        }

        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().estado != "stun")
        {
            if(gameObject.GetComponent<HeartSystem>().health <= 0)
            {
                //gameObject.transform.position = start.position;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                gameObject.transform.position = checkpoint.position;
            }
        }
    }
}
