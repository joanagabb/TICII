using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    string estado;
    public float patrolSpeed = 5;
    private bool movingRight = true;

    void Start()
    {
        estado = "patrulha";
        StartCoroutine("StunOff");
    }

    private void Update()
    {

        if (estado == "patrulha")
        {
            Patrulha();
        }
        else
        {
            Stun();
        }
    }

    void Stun()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        GetComponent<Collider2D>().isTrigger = true;
    }

    void Patrulha()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        GetComponent<Collider2D>().isTrigger = false;

        transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
    }

    /*private IEnumerator StunOff()
    {
        while (estado != "stun")
        {
            yield return null;
        }

        yield return new WaitForSeconds(5);
        estado = "patrulha";
        StartCoroutine("StunOff");
    }*/

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTrigger")
        {
            estado = "patrulha";
        }
    }
}
