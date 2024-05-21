using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene0()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeScene1()
    {
        SceneManager.LoadScene(1);
    }
    public void Change2Scene2()
    {
        SceneManager.LoadScene(6);
    }

    public void ChangeScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void Change2Scene2()
    {
        SceneManager.LoadScene(6);
    }

    public void Back()
	{
		Application.Quit ();
	}
}
