using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<GameObject> specialLanterns; 
    bool isOpen = false; 

    void Update()
    {
        if (isOpen) 
        {
            AnimateGate(); 
        }

        OpenGate(); 
    }

    void OpenGate()
    {
        List<bool> areOn = new List<bool>(); 

        for (int i = 0; i < specialLanterns.Count; i++) 
        {
            areOn.Add(specialLanterns[i].GetComponent<Lantern>().isOn); 
        }

        if (!areOn.Contains(false))
        {
            isOpen = true;
        }
    }

    void AnimateGate()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isOpen", isOpen);
    }
}
