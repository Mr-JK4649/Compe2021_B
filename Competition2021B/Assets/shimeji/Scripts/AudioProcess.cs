﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProcess : MonoBehaviour
{
    public enum Object
    {
        Ball = 0,
        Wall,
        Floor,
        Coin
    }

    public enum Kind
    { 
        Enter,
        Exit,
        Stay
    }

    public Kind kind;
    public Object objectA;
    public Object objectB;

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
        if (pauseCls.IsPause() == true) bgmAudioSource.Pause();
        else if(!bgmAudioSource.isPlaying)bgmAudioSource.Play();
        Debug.Log(pauseCls.IsPause());
        
    }

    public void ShotSE(int num){
        if(num < seClip.Length)
            audioSource.PlayOneShot(seClip[num]);
    }
}
