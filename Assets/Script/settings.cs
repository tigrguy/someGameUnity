using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class setings : MonoBehaviour
{

    //// Start is called before the first frame update
    //void Start()
    //{



    //}


    //public void SaveSettingsSoundOn()
    //{
    //    PlayerPrefs.SetInt("", 1);

    //}

    //public void SaveSettingsSoundOff()
    //{
    //    PlayerPrefs.SetInt("", 0);

    //}

    //// Update is called once per frame
    //void Update()
    //{   

    //}

    public static setings Instance { get; private set; }

    private bool isMuted;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadMuteState();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1;
        SaveMuteState();
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    private void LoadMuteState()
    {
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        AudioListener.volume = isMuted ? 0 : 1;
    }

    private void SaveMuteState()
    {
        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }
}
