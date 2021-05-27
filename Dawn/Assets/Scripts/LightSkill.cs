using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSkill : MonoBehaviour
{
    GameObject player;
    bool lightSkill;
    bool isOn;
    GameObject playerLight;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine("LightOff");
    }

    void Update()
    {
        lightSkill = player.GetComponent<PlayerSkills>().LightSkill;

        if (Input.GetKey(KeyCode.C) && lightSkill && !isOn)
        {
            isOn = true;
        }

        Animations();
    }

    private IEnumerator LightOff()
    {
        while (!isOn)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1);
        isOn = false;
        StartCoroutine("LightOff");
    }

    private void Animations()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isOn", isOn);
    }
}
