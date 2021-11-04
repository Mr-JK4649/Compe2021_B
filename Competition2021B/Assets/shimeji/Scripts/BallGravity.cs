using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    //現在の落下力
    private float gravity = 0f;

    [SerializeField,Tooltip("落ちる力(毎秒毎秒)")] 
    private float speed = 0f;

    [SerializeField,Tooltip("反射時の速度減衰(高い程減衰)")]
    private float refAtt = 0f;

    [SerializeField, Tooltip("摩擦による速度減衰(高い程減衰)")]
    private float friAtt = 0f;

    //落下中フラグ
    private bool isFall = true;

    //壁衝突フラグ
    private bool isWall = false;

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

    public AudioProcess ap;

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
        
        //斜面に沿って移動する
        moveVec.x += floorNor.x * spd * Time.deltaTime;
        moveVec.z += floorNor.z * spd * Time.deltaTime;

        
        if (floorNor.y == 1.0f && moveVec != Vector3.zero)//傾き0だったばあい速度を減衰していく
        {
            moveVec = Vector3.Lerp(moveVec, Vector3.zero, friAtt);
            if (moveVec.x + moveVec.y <= 0.0005f)
                moveVec = Vector3.zero;
        }
        else if(moveVec != Vector3.zero){                 //それ以外の場合、摩擦による速度減衰
            moveVec = Vector3.Lerp(moveVec, Vector3.zero, friAtt/5.0f);
        }

        //重力
        if (isFall)
        {
            moveVec.y = gravity;
            gravity += -0.098f * Time.deltaTime;
        }
        else {
            gravity = 0;
        }

        if(moveVec != Vector3.zero)
            this.transform.position += moveVec;

        Debug.DrawRay(this.transform.position, moveVec*10,new Color(255,0,0));

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFall = false;
        }

        if(collision.gameObject.tag == "Wall"){
            isWall = true;
            Vector3 wn = collision.contacts[0].normal;
            moveVec = Vector3.Reflect(moveVec, wn);
            Debug.Log(wn);
            ap.ShotSE(0);
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
        if (collision.gameObject.tag == "Wall")
            isWall = false;
    }

}
