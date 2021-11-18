using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetConfetti : MonoBehaviour
{
    const int MAX_TIME = 99999600;    // 再生時間

    ParticleSystem ps_confetti;  // このオブジェクトのパーティクルシステム
     private int frameCount;     // フレームを格納


    void OnEnable()
    {
        // 変数の初期化
        ps_confetti = this.gameObject.GetComponent<ParticleSystem>();
        frameCount = 0;

        // 座標の指定
        this.gameObject.transform.position = new Vector3(0.0f, 2.0f, 0.0f);

        // エフェクトの開始
        StartEffectAnimation();

        SetColorMaterial();

    }

    // Update is called once per frame
    void Update()
    {
        // エフェクト停止の判断と実行
        JudgmentAndExecutionOfEffectStop();

        SetColorMaterial();
    }

    /// <summary>
    /// 時間の加算
    /// </summary>
    private void AddTimeTo_timeCount()
    {
        frameCount++;
    }

    /// <summary>
    /// エフェクト停止の判断と実行
    /// </summary>
    private void JudgmentAndExecutionOfEffectStop()
    {
        if (frameCount < MAX_TIME)
            // 時間の加算
            AddTimeTo_timeCount();
        else
            // エフェクトの停止
            StopEffectAnimation();

    }

    /// <summary>
    /// エフェクトの開始
    /// </summary>
    private void StartEffectAnimation()
    {
        ps_confetti.Play();
    }

    /// <summary>
    /// エフェクトの停止
    /// </summary>
    private void StopEffectAnimation()
    {
        ps_confetti.Stop();
        this.gameObject.SetActive(false);
    }


    private void SetColorMaterial()
    {
        //int a = (int)Random.Range(0, 1);
        //if(a == 0)
        //this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        //else
        //this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
}
