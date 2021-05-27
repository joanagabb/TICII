using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSkills : MonoBehaviour
{
    public bool LanternSkill = false;
    public bool WallSkill = false;
    public bool LightSkill = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
            switch (collision.gameObject.name)
            {
                case "Lantern Skill":
                    LanternSkill = true;
                    Debug.Log("LanternSkill");
                    Destroy(collision.gameObject);
                    break;

                case "Wall Skill":
                    WallSkill = true;
                    Debug.Log("WallSkill");
                    Destroy(collision.gameObject);
                    break;

                case "Light Skill":
                    LightSkill = true;
                    Debug.Log("LightSkill");
                    Destroy(collision.gameObject);
                    SceneManager.LoadScene("Win");
                    break;

                case "Win":
                    SceneManager.LoadScene("Win");
                    break;

                default:
                    break;
            }
    }
}
