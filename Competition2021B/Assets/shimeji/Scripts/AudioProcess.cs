using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProcess : MonoBehaviour
{
    public AudioClip[] seClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void ShotSE(int num){
        if(num < seClip.Length)
            audioSource.PlayOneShot(seClip[num]);
    }
}
