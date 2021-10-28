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
        
        //壁に当たってなければ床の斜面に沿って移動する
        //当たった場合速度を減衰させる
        if (!isWall)
        {
            moveVec.x += floorNor.x * spd * Time.deltaTime;
            moveVec.z += floorNor.z * spd * Time.deltaTime;
        }
        if (isWall) {
            moveVec.x /= refAtt;
            moveVec.y /= refAtt;
            moveVec.z /= refAtt;
        }

        //傾き0だったばあい速度を減衰していく
        if (floorNor.y == 1.0f) {
            moveVec = Vector3.Lerp(moveVec, Vector3.zero, friAtt);
        }


        if (isFall)
        {
            moveVec.y = gravity;
            gravity += -0.098f * Time.deltaTime;
        }
        else {
            gravity = 0;
        }

        this.transform.position += moveVec;

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
