using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmotionDiceTurn : MonoBehaviour
{
    public Sprite[] numberSprites; // ������ Sprite ��� ������� �����
    public Image imageComponent;    // UI Image, ������� ����� ���������� ��������

    public void UpdateImage(int randomNumber)
    {
        // ���������, ��� randomNumber ��������� � �������� ������� numberSprites
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
