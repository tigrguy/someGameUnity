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
    public void Change1Scene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void Change2Scene2()
    {
        SceneManager.LoadScene(5);
    }

    public void Change2Scene()
    {
        SceneManager.LoadScene(2);
    }

    public void Change3Scene()
    {
        SceneManager.LoadScene(3);
    }

    public void ChangeBattleScene_1()
    {
        SceneManager.LoadScene(4);
    }

    public void ChangeBattleScene_2Mob()
    {
        SceneManager.LoadScene(6);
    }
    public void ChangeBattleScene_3Booss()
    {
        SceneManager.LoadScene(7);
    }

    public void Change3Scene1()
    {
        SceneManager.LoadScene(8);
    }

    public void Back()
	{
		Application.Quit ();
	}
}
