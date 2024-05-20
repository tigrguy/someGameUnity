    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;
    public GameObject pauseMenu;
    public static bool Help;
    public GameObject HelpKenu;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void PauseHelp()
    {
        HelpKenu.SetActive(true);
        Time.timeScale = 0f;
        Help = true;

    }

    public void ResumeHelp()
    {
        HelpKenu.SetActive(false);
        Time.timeScale = 1f;
        Help = false;
    }

}
