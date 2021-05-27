using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Lantern : MonoBehaviour
{
    public bool isPlayerColliding = false;
    public bool isOn = false;
    GameObject player;
    bool lanternSkill;
    public GameObject luz;

    void Start()
    {
        StartCoroutine("LanternsOff");
        player = GameObject.Find("Player");
    }

    void Update()
    {
        lanternSkill = player.GetComponent<PlayerSkills>().LanternSkill;

        if (Input.GetKey(KeyCode.Z) && isPlayerColliding)
        {
            if(lanternSkill)
            {
                isOn = true;
            }
        }

        Animations();
    }

    private void Animations()
    {
        Animator anim = GetComponent<Animator>(); 
        anim.SetBool("isOn", isOn); 

        if(gameObject.tag == "Special Lantern" && !lanternSkill)
        {
            anim.SetBool("isPlayerColliding", isPlayerColliding);
        }
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
