using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Button muteButton; // ������, ������� ����� ������ �����������
    public Image buttonImage; // ��������� Image, ������� ����� �������� ����������� �� ������
    public Sprite soundOnSprite; // ������ ��� ��������� "���� �������"
    public Sprite soundOffSprite; // ������ ��� ��������� "���� ��������"

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
            buttonImage.sprite = soundOffSprite; // ������������� ������ ��� ��������� "���� ��������"
        }
        else
        {
            buttonImage.sprite = soundOnSprite; // ������������� ������ ��� ��������� "���� �������"
        }
    }
}