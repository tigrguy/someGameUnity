using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("1Scene");// в кавычках название сцены на которую осуществляется переход
    }

    public void ExitGame()
    {
        Application.Quit();
    }



    public void LoadRandomSceneAsync()
    {
        // Массив сцен, из которых будем выбирать случайную
        string[] scenes = { "1Scene", "2Scene2" };

        // Выбираем случайную сцену
        int randomIndex = Random.Range(0, scenes.Length);
        string randomScene = scenes[randomIndex];

        // Запускаем асинхронную загрузку
        StartCoroutine(LoadSceneAsync(randomScene));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Начинаем асинхронную загрузку сцены
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        // Пока сцена не загружена
        while (!asyncOperation.isDone)
        {
            // Можно добавить код для отображения индикатора загрузки
            // float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            // Debug.Log("Loading progress: " + (progress * 100) + "%");

            yield return null;
        }
    }

}