using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    bool LanternSkill = false;
    bool WallSkill = false;
    bool LightSkill = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Z))
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
                    break;

                default:
                    break;
            }
        }
    }
}
