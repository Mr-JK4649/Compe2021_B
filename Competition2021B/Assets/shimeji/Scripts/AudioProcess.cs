using System.Collections;
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
    private AudioSource bgmAudioSource;
    public AudioClip[] seClip;

    //ポーズ処理
    pause pauseCls;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        pauseCls = GameObject.Find("Pause").GetComponent<pause>();
        bgmAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool ip = pauseCls.IsPause();
        if (ip) bgmAudioSource.Pause();
        else if(!bgmAudioSource.isPlaying && !ip)bgmAudioSource.Play();
        Debug.Log(ip);
        
    }

    public void ShotSE(int num){
        if(num < seClip.Length)
            audioSource.PlayOneShot(seClip[num]);
    }

    public void SSSSS(AudioSource aas, AudioClip aac) {
        aas.PlayOneShot(aac);
    }
}
