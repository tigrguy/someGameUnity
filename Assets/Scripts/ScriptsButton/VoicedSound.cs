using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource[] allAudioSources;


    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>(); // Найти все AudioSource в сцене
    }

    public void MuteAllSounds()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = true; // Выключить все AudioSource
        }
    }

    public void UnmuteAllSounds()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = false; // Включить все AudioSource
        }
    }
}