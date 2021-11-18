using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct OBB {
    Vector3[] scale;
}

public class HitCheck : MonoBehaviour
{

    //球の位置
    [SerializeField]
    Transform sphere;
    Vector3 spherePos;  //球の座標
    float sphereSca;  //球のスケール

    //ボールとの最近接点s
    Vector3 cpo;

    //床
    Transform tra;
    Vector3 pos;
    Vector3[] ang = new Vector3[3]; //各座標軸の傾きを表すやつ
    float[] sca = new float[3];     //さいず

    [SerializeField]
    BallGravity bg;

    //反射フラグ
    bool ableRefFlag = true;

    [SerializeField]
    bool nonColRef;

    // Start is called before the first frame update
    void Start()
    {
        //ボールのtransformを取得
        sphere = GameObject.FindWithTag("Player").transform;

        //ボールの移動スクリプトを山椒
        bg = GameObject.FindWithTag("Player").GetComponent<BallGravity>();

        //ボールのスケール
        sphereSca = sphere.localScale.x/2;
        sphereSca *= 1.1f;


        //自分のtransformを取得
        tra = this.transform;

        //xyzのスケールの半分
        sca[0] = tra.localScale.x / 2;
        sca[1] = tra.localScale.y / 2;
        sca[2] = tra.localScale.z / 2;

    }

    private void FixedUpdate()
    {
        //球の座標を取得
        spherePos = sphere.position;

        //床の位置
        pos = tra.position;

        //床の角度
        ang[0] = tra.right;
        ang[1] = tra.up;
        ang[2] = tra.forward;

        cpo = ClosestPtPointOBB();      //最近接点の座標を求める
        Vector3 v = cpo - spherePos;            //衝突

        if (nonColRef)
        {
           
            if (Vector3.Distance(cpo, spherePos) <= sphereSca) //Vector3.Dot(v, v) <= sphereSca * sphereSca
            {
                Vector3 nor = spherePos - cpo;  //ぶつかった壁との座標の差でベクトルを出す
                nor = Vector3.Normalize(nor);   //法線ベクトルの正規化
                if (ableRefFlag)
                {
                    bg.PassNormalRefrection(nor);   //法線ベクトルをボールの移動制御スクリプトに渡して反射させる
                    ableRefFlag = false;            //反射フラグを立てる
                    Debug.Log(nor);
                }
                else
                { //壁から押し出す力
                  //bg.PushSamePower(nor);
                }

                return;
            }

            //壁に衝突しなかったら反射フラグを倒す
            ableRefFlag = true;
        }

    }

    Vector3 ClosestPtPointOBB()
    {
        Vector3 d = spherePos - pos;
        Vector3 retvec = pos;
        float dist;
        for (int i = 0; i < 3; i++)
        {
            dist = Vector3.Dot(d, ang[i]);
            if (dist > sca[i])
            {
                dist = sca[i];
            }
            if (dist < -sca[i])
            {
                dist = -sca[i];
            }
            retvec += dist * ang[i];
        }

        return retvec;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Vector3 nor = spherePos - cpo;  //ぶつかった壁との座標の差でベクトルを出す
            nor = Vector3.Normalize(nor);   //法線ベクトルの正規化
            bg.PassNormalRefrection(nor);   //反射
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            Vector3 nor = spherePos - cpo;  //ぶつかった壁との座標の差でベクトルを出す
            nor = Vector3.Normalize(nor);   //法線ベクトルの正規化
            //壁から押す処理
            bg.PushSamePower(nor);
        }
    }
}
