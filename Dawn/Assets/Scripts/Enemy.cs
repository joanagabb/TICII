using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string estado;
    public float patrolSpeed = 5;
    private bool movingRight = true;

    void Start()
    {
        estado = "patrulha";
    }

    private void Update()
    {

        if (estado == "patrulha")
        {
            Patrulha();
        }
        else if(estado == "derrota")
        {
            Derrota();
        }
        else
        {
            Stun();
        }
    }

    void Stun()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
    }

    void Patrulha()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
    }

    void Derrota()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyStop")
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        if(collision.gameObject.tag == "EnemyTrigger")
        {
            estado = "stun";
        }

        if(collision.gameObject.tag == "EnemyDefeat")
        {
            estado = "derrota";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTrigger")
        {
            estado = "patrulha";
        }

        if (collision.gameObject.tag == "EnemyDefeat")
        {
            estado = "patrulha";
        }
    }
}
