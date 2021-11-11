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
        if ( Mathf.Abs(moveVec.x + moveVec.z) < 0.05f){
            moveVec += (Vector3.down + floorNor) * spd * Time.deltaTime;
        }

        //重力
        if (isFall)
        {
            moveVec.y = gravity;
            gravity += -0.098f * Time.deltaTime;
        }
        else
        {
            gravity = 0;
        }


        //最終的なやつ
        transform.position += moveVec;

        //現在のベクトルを算出
        nowVec = transform.position - oldPos;

        //現在の位置を保存
        oldPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFall = false;
        }

        if(collision.gameObject.tag == "Wall"){
            // = collision.gameObject.GetComponent<GetNormals>().GetNormal();
            wn = collision.contacts[0].normal;

            //前のフレームの座標と現在のフレームの座標から進行ベクトルを割り出す

            moveVec = Vector3.Reflect(nowVec, wn);
            moveVec *= refAtt;

            GameObject effe = Instantiate(showWave, this.transform.position, Quaternion.identity);
            Destroy(effe, 1.0f);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //床の法線を取得
            floorNor = gn.GetNormal();
        }

        //壁に触れている間、壁に向かう力の大きさによって、速度減衰をさせる。
        if (collision.gameObject.tag == "Wall")
        {
            //壁の法線を取得
            wn = collision.gameObject.GetComponent<GetNormals>().GetNormal();

            //壁に触れている間速度を減衰させる
            //moveVec = Vector3.Reflect(moveVec, wallNormal);
            //moveVec += wallNormal;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
            isFall = true;
    }

    private Vector3 PowVec3(Vector3 a, Vector3 b) {

        a.x *= b.x;
        a.y *= b.y;
        a.z *= b.z;

        return a;
    }

}
