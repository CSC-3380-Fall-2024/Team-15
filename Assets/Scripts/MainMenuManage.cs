using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManage : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void quit()
    {
        // Application.Quit();
    }
}