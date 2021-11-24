using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustFX : MonoBehaviour
{
    const int MAX_TIME = 600;    // 再生時間

    ParticleSystem ps_dust;  // このオブジェクトのパーティクルシステム
    private int frameCount;      // 再生しているフレームを格納
    Vector3 buf_dustPos;

    // Start is called before the first frame update
    void Start()
    {
        // 変数の初期化
        ps_dust = this.gameObject.GetComponent<ParticleSystem>();
        frameCount = 0;

        GetDustParam();

        ps_dust.Play();

        Debug.Log(ps_dust);
    }

    // Update is called once per frame
    void Update()
    {
        SetDustParam();

    }

    /// <summary>
    /// 砂埃の情報を取得
    /// </summary>
    private void GetDustParam()
    {
        buf_dustPos = this.gameObject.transform.position;

    }

    /// <summary>
    /// 砂埃の方向と速度の計算
    /// </summary>
    private (float, Quaternion) CalculationDustDirectionAndSpeed()
    {
        //Vector3 dustVec;
        float dustDis;
        Quaternion dustAngle;

        //dustVec = this.gameObject.transform.position - buf_dustPos;
        dustDis = Vector3.Distance(buf_dustPos, this.gameObject.transform.position);
        dustAngle = Quaternion.LookRotation(this.gameObject.transform.position - buf_dustPos);

        return (dustDis, dustAngle);

    }

    /// <summary>
    /// 砂埃の状態を設定
    /// </summary>
    [System.Obsolete]
    private void SetDustParam()
    {
        // エフェクトの生成量の設定
        int maxParNum = (int)(CalculationDustDirectionAndSpeed().Item1 * 10000.0f);
        ps_dust.maxParticles = maxParNum;
        //Debug.Log(maxParNum);
        ps_dust.playbackSpeed = 0.5f;

        //角度の設定
        Vector3 dustAngle = CalculationDustDirectionAndSpeed().Item2.eulerAngles;
        dustAngle.y += 90.0f;

        var sh = ps_dust.shape;
        sh.rotation = dustAngle;


        GetDustParam();

    }
}
