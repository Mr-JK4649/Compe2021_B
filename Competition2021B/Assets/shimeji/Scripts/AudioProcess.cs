using System.Collections;
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
        if (pauseCls.IsPause()) bgmAudioSource.Stop();
        if (!pauseCls.IsPause()) bgmAudioSource.Play();
        
    }

    public void ShotSE(int num){
        if(num < seClip.Length)
            audioSource.PlayOneShot(seClip[num]);
    }
}
