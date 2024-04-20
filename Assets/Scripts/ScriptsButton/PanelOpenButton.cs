using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel; 

    public void OpenPanel()
    {
        panel.SetActive(true); 
    }

    public void ClosePanel()
    {
        panel.SetActive(false); 
    }
}