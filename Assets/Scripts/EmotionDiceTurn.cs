using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmotionDiceTurn : MonoBehaviour
{
    public Sprite[] numberSprites; // ћассив Sprite дл€ каждого числа
    public Image imageComponent;    // UI Image, который будет отображать картинку

    public void UpdateImage(int randomNumber)
    {
        // ѕровер€ем, что randomNumber находитс€ в пределах массива numberSprites
        if (randomNumber >= 0 && randomNumber < numberSprites.Length)
        {
            imageComponent.sprite = numberSprites[randomNumber];
        }
        else
        {
            Debug.LogWarning("Random number is out of range!");
        }
    }
}
