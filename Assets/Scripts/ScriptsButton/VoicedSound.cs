using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource[] allAudioSources;


    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>(); // ����� ��� AudioSource � �����
    }

    public void MuteAllSounds()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = true; // ��������� ��� AudioSource
        }
    }

    public void UnmuteAllSounds()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.mute = false; // �������� ��� AudioSource
        }
    }
}