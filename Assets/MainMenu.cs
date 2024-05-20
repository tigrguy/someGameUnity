using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("1Scene");// � �������� �������� ����� �� ������� �������������� �������
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    public void LoadRandomSceneAsync()
    {
        // ������ ����, �� ������� ����� �������� ���������
        string[] scenes = { "1Scene", "2Scene2" };

        // �������� ��������� �����
        int randomIndex = Random.Range(0, scenes.Length);
        string randomScene = scenes[randomIndex];

        // ��������� ����������� ��������
        StartCoroutine(LoadSceneAsync(randomScene));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // �������� ����������� �������� �����
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // ���� ����� �� ���������
        while (!asyncOperation.isDone)
        {
            // ����� �������� ��� ��� ����������� ���������� ��������
            // float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            // Debug.Log("Loading progress: " + (progress * 100) + "%");

            yield return null;
        }
    }

}