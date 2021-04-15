using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public bool isPlayerColliding = false;
    public bool isOn = false;

    void Start()
    {
        StartCoroutine("LanternsOff");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && isPlayerColliding)
        {
            isOn = true;
        }

        Animations();
    }

    private void Animations()
    {
        Animator anim = GetComponent<Animator>(); 
        anim.SetBool("isOn", isOn); 
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerColliding = false;
        }
    }

    private IEnumerator LanternsOff() 
    {
        while (!isOn)
        {
            yield return null;
        }

        yield return new WaitForSeconds(7);
        isOn = false;
        StartCoroutine("LanternsOff");
    }
}
