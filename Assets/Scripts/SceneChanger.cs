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
    public void Back()
	{
		Application.Quit ();
	}
}
