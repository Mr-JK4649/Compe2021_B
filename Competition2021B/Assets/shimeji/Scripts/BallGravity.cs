using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    [SerializeField] private float gravity = 0f;
    [SerializeField,Tooltip("落ちる速さ(毎秒毎秒)")] private float speed = 0f;
    [SerializeField] private bool isFall = true;
    [SerializeField] private bool isWall = false;

    //自身のRididBody
    private Rigidbody rb;

    //床の法線ベクトルのやし
    public GetNormals gn;

    public float spd;

    //進行方向
    private Vector3 moveVec;

    //床の法線
    private Vector3 floorNor;

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
            moveVec.x /= 2.0f;
            moveVec.y /= 2.0f;
            moveVec.z /= 2.0f;
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
