﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    //現在の落下力
    private float nowGravity = 0f;

    [SerializeField,Tooltip("落ちる力(毎秒毎秒)")] 
    private float gravity = 0f;

    [SerializeField,Tooltip("反射時の速度減衰(高い程減衰)")]
    private float refAtt = 0f;

    [SerializeField, Tooltip("摩擦による速度減衰(高い程減衰)")]
    private float friAtt = 0f;

    //落下中フラグ
    private bool isFall = true;

    //自身のRididBody
    private Rigidbody rb;

    //床の法線ベクトルのやし
    public GetNormals gn;

    //移動力
    public float spd;

    //進行方向
    [SerializeField]
    private Vector3 moveVec;

    //床の法線
    private Vector3 floorNor;


    public Vector3 wn;

    //1フレーム前の座標
    public Vector3 oldPos;

    public Vector3 nowVec;


    //衝撃は
    [SerializeField] GameObject showWave;

    //転がってる音
    [SerializeField]
    AudioClip ac;

    [SerializeField]
    AudioSource ass;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        //ボールのRigidbodyがSleep状態なら起こす
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }

        //ちから　ごうせい　すごい 
        if (floorNor.y < 1.0f)
        {
            Vector3 gravityVelocity = new Vector3(0, -gravity, 0);
            moveVec += (gravityVelocity + floorNor) * spd * Time.deltaTime;
        }
        else {
            //床との摩擦
            moveVec *= friAtt;
        }

        //ある程度速度が下がったら0にする
        {
            if (Mathf.Abs(moveVec.x) < 0.0003f) moveVec.x = 0;
            if (Mathf.Abs(moveVec.y) < 0.0003f) moveVec.y = 0;
            if (Mathf.Abs(moveVec.z) < 0.0003f) moveVec.z = 0;
        }

        //重力
        if (isFall)
        {
            moveVec.y = nowGravity;
            nowGravity += -0.098f * Time.deltaTime;
        }
        else
        {
            nowGravity = 0;
        }


        //最終的なやつ
        transform.position += moveVec;

        //現在のベクトルを算出
        nowVec = transform.position - oldPos;

        //現在の位置を保存
        oldPos = transform.position;



        //ボールが転がる音
        if (Mathf.Abs(moveVec.x) + Mathf.Abs(moveVec.z) > 0)
        {
            if (ass.isPlaying == false)
                ass.Play();
        }
        else
        {
            if (ass.isPlaying) ass.Pause();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFall = false;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //床の法線を取得
            floorNor = gn.GetNormal();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            isFall = true;
    }

    //速度を0にする
    public void ResetBallVelocity() {
        moveVec = Vector3.zero;
    }


    //渡された法線ベクトルで反射
    public void PassNormalRefrection(Vector3 nor) {

        GameObject effe = Instantiate(showWave, this.transform.position, Quaternion.identity);
        Destroy(effe, 1.0f);
        moveVec = Vector3.Reflect(moveVec, nor);
        moveVec *= refAtt;
    }

    //壁から同僚の力で押してもらう
    public void PushSamePower(Vector3 nor) {
        //if (Mathf.Abs(moveVec.x) + Mathf.Abs(moveVec.z) > 0.01f)
        //moveVec *= 0.5f;
        { }
    }

    public (Vector3 old, Vector3 now) GetLength() {

        return (oldPos, transform.position);
    }
}
