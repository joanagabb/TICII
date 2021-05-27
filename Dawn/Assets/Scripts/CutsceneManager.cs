using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    bool LanternSkill = false;
    bool WallSkill = false;
    bool LightSkill = false;
    public GameObject player;
    public GameObject startDirector;
    public GameObject LanternSkillDirector;
    public GameObject WallSkillDirector;
    public GameObject LightSkillDirector;

    private void Start()
    {
        startDirector.GetComponent<PlayableDirector>().Play();
        StartCoroutine("LanternSkillCutscene");
        StartCoroutine("WallSkillCutscene");
        StartCoroutine("LightSkillCutscene");
    }

    void Update()
    {
        LanternSkill = player.GetComponent<PlayerSkills>().LanternSkill;
        WallSkill = player.GetComponent<PlayerSkills>().WallSkill;
        LightSkill = player.GetComponent<PlayerSkills>().LightSkill;
    }

    IEnumerator LanternSkillCutscene()
    {
        while (!LanternSkill)
        {
            yield return null;
        }

        LanternSkillDirector.GetComponent<PlayableDirector>().Play();
    }

    IEnumerator WallSkillCutscene()
    {
        while (!WallSkill)
        {
            yield return null;
        }

        WallSkillDirector.GetComponent<PlayableDirector>().Play();
    }

    IEnumerator LightSkillCutscene()
    {
        while (!LightSkill)
        {
            yield return null;
        }

        LightSkillDirector.GetComponent<PlayableDirector>().Play();
    }
}
