using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Button muteButton; // Кнопка, которая будет менять изображение
    public Image buttonImage; // Компонент Image, который будет изменять изображение на кнопке
    public Sprite soundOnSprite; // Спрайт для состояния "звук включен"
    public Sprite soundOffSprite; // Спрайт для состояния "звук выключен"

    private void Start()
    {
        if (muteButton == null || buttonImage == null || soundOnSprite == null || soundOffSprite == null)
        {
            Debug.LogError("One or more references are not set in the inspector");
            return;
        }

        UpdateButtonState();
        muteButton.onClick.AddListener(OnMuteButtonClick);
    }

    private void OnMuteButtonClick()
    {
        if (SoundManager.Instance == null)
        {
            Debug.LogError("SoundManager.Instance is null");
            return;
        }

        SoundManager.Instance.ToggleMute();
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        if (SoundManager.Instance == null)
        {
            Debug.LogError("SoundManager.Instance is null");
            return;
        }

        if (SoundManager.Instance.IsMuted())
        {
            buttonImage.sprite = soundOffSprite; // Устанавливаем спрайт для состояния "звук выключен"
        }
        else
        {
            buttonImage.sprite = soundOnSprite; // Устанавливаем спрайт для состояния "звук включен"
        }
    }
}