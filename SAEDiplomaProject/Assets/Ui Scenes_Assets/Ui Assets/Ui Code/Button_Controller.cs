using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controller : MonoBehaviour
{

    public void Load_Game()
    {
        SceneManager.LoadScene("");
    }

    public void Load_Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Load_Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit_Game()
    {
        Application.Quit();
    }
}
