using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private Image healthBarFill;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth(float amount)
    {
        currentHealth += amount;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        if (currentHealth > maxHealth)
        {
            
            Debug.Log(currentHealth);
        }
        else
        {
            Debug.Log(currentHealth);
        }
        if (currentHealth == 0)
        {
            
            Debug.Log(currentHealth);
        }


    }
}
