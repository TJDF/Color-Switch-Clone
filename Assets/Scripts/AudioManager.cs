using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    public void PointAudioPlay() 
    {
        audioSource1.Play();
    }
    public void JumpAudioPlay() 
    {
        audioSource2.Play();
    }

    public void ChangeColorAudioPlay()
    {
        audioSource3.Play();
    }

    public void LoseAudioPlay()
    {
        audioSource4.Play();
    }
}
