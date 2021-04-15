using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public void LoadInGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void LoadControles()
    {
        SceneManager.LoadScene("Controles");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            Application.Quit();
        }
    }
}
