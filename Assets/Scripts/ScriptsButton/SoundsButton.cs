using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsButton : MonoBehaviour
{
    public AudioSource src;
    public AudioClip next,money,soundTwo;


    public void Next()
    {
        src.clip = next;
        src.Play();
    }

    public void Money()
    {
        src.clip = money;
        src.Play();
    }

    public void SoundTwo()
    {
        src.clip = soundTwo;
        src.Play();
    }

}
