using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSkill : MonoBehaviour
{
    bool wallSkill;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        wallSkill = player.GetComponent<PlayerSkills>().WallSkill;

        if(wallSkill)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        
        if(Input.GetKey(KeyCode.X) && wallSkill)
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
