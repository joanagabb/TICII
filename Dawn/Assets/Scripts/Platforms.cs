using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    bool isPlayerColliding = false;

    private void Start()
    {
        StartCoroutine("Rotation");
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<PlatformEffector2D>().rotationalOffset = 0f;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<PlatformEffector2D>().rotationalOffset = 180f;
        }

        GetComponent<Animator>().SetBool("isPlayerColliding", isPlayerColliding);
    }

    IEnumerator Rotation()
    {
        while (GetComponent<PlatformEffector2D>().rotationalOffset == 0f)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1);
        GetComponent<PlatformEffector2D>().rotationalOffset = 0f;
        StartCoroutine("Rotation");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPlayerColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Player")
        {
            isPlayerColliding = false;
        }
    }
}
