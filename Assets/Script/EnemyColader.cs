using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("BattleScene_1");
        }
    }
}