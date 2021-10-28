﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProcess : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioSource bgmAudioSource;
    public AudioClip[] seClip;

    //ポーズ処理
    pause pauseCls;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        pauseCls = GameObject.Find("Pause").GetComponent<pause>();
    }

    private void Update()
    {
        if (pauseCls.IsPause() == true) bgmAudioSource.Stop();
        else if(!bgmAudioSource.isPlaying)bgmAudioSource.Play();
        Debug.Log(pauseCls.IsPause());
        
    }

    public void ShotSE(int num){
        if(num < seClip.Length)
            audioSource.PlayOneShot(seClip[num]);
    }
}
