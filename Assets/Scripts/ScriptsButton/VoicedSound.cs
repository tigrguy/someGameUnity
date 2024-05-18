using UnityEngine;

using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //public static SoundManager instance;

    //private AudioSource[] allAudioSources;


    //private void Start()
    //{
    //    allAudioSources = FindObjectsOfType<AudioSource>(); // ����� ��� AudioSource � �����



    //}

    //public void MuteAllSounds()
    //{
    //    foreach (AudioSource audioSource in allAudioSources)
    //    {
    //        audioSource.mute = true; // ��������� ��� AudioSource
    //    }
    //}

    //public void UnmuteAllSounds()
    //{
    //    foreach (AudioSource audioSource in allAudioSources)
    //    {
    //        audioSource.mute = false; // �������� ��� AudioSource
    //    }
    //}




    public static SoundManager Instance { get; private set; }

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