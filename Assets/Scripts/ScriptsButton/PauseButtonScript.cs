using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    private bool IsPaused = false;
    [SerializeField] private GameObject pausePanel;



    void Update()
    {
        if (IsPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(IsPaused);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(IsPaused);

        }
    }
    public void PauseButton()
    {
        IsPaused = !IsPaused;
    }


}
