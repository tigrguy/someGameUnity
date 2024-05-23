using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanelController : MonoBehaviour
{
    public Button backButton;
    public Button nextButton;
    public Image guideImage;
    public TextMeshProUGUI guideText; // �������� �� TextMeshProUGUI

    public Sprite[] guideImages;
    public string[] guideTexts;

    private int currentSlideIndex = 0;

    private void Start()
    {
        StartCoroutine(waiter());
        // ������������� ���������� ���������
        UpdateSlide();
        UpdateButtons();

        // ���������� ���������� � �������
        backButton.onClick.AddListener(PreviousSlide);
        nextButton.onClick.AddListener(NextSlide);
    }

    private void PreviousSlide()
    {
        if (currentSlideIndex > 0)
        {
            currentSlideIndex--;
            UpdateSlide();
            UpdateButtons();
        }
    }

    private void NextSlide()
    {
        if (currentSlideIndex < guideImages.Length - 1)
        {
            currentSlideIndex++;
            UpdateSlide();
            UpdateButtons();
        }
    }

    private void UpdateSlide()
    {
        // ��������� ����������� � �����
        guideImage.sprite = guideImages[currentSlideIndex];
        guideText.text = guideTexts[currentSlideIndex];
    }

    private void UpdateButtons()
    {

        // ��������� ��������� ������
        backButton.gameObject.SetActive(currentSlideIndex > 0);
        nextButton.gameObject.SetActive(currentSlideIndex < guideImages.Length - 1);
    }
    IEnumerator waiter()
    {
        
        yield return new WaitForSeconds(2);

    }

}
