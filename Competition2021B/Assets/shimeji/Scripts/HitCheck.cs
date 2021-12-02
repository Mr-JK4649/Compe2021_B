using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct OBB {
    Vector3[] scale;
}

public class HitCheck : MonoBehaviour
{
    Transform sphere;   //球のtransform
    Vector3 spherePos;  //球の座標
    float sphereSca;    //球のスケール

    BallGravity bg;     //球の移動を司るスクリプト

    Vector3 cpo;        //ボールとの最近接点

    Transform tra;      //床のtransform
    Vector3 pos;        //床の座標
    Vector3[] ang = new Vector3[3]; //各座標軸の傾きを表すベクトル
    float[] sca = new float[3];     //中心から各軸方向へのサイズの半径

    

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
        cpo = ClosestPtPointOBB(spherePos);      //最近接点の座標を求める

        if (nonColRef)
        {
            Vector3 a, b;
            (a, b) = bg.GetLength();
            float num = 0.0f;
            while (num < 1.0f) {
                Vector3 pos = Vector3.Lerp(a, b, num);
                cpo = ClosestPtPointOBB(pos);           //最近接点の座標を求める

                if (Vector3.Distance(cpo, spherePos) <= sphereSca) //Vector3.Dot(v, v) <= sphereSca * sphereSca
                {
                    sphere.position = pos;
                    Vector3 nor = pos - cpo;  //ぶつかった壁との座標の差でベクトルを出す
                    nor.Normalize();                //法線ベクトルの正規化
                    if (ableRefFlag)
                    {
                        bg.PassNormalRefrection(nor);   //法線ベクトルをボールの移動制御スクリプトに渡して反射させる
                        ableRefFlag = false;            //反射フラグを立てる
                    }
                    else
                    { //壁から押し出す力
                        bg.PushSamePower(nor);
                    }

                    return;
                }

                //壁に衝突しなかったら反射フラグを倒す
                ableRefFlag = true;

                num += 0.1f;
            }
           
            
        }

    }

    Vector3 ClosestPtPointOBB(Vector3 sphePos)
    {
        Vector3 d = sphePos - pos;
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
        if (collision.gameObject.tag == "Player" && !nonColRef) {
            Vector3 sPos = collision.transform.position;
            cpo = ClosestPtPointOBB(sPos);  //最近接点の座標を求める
            Vector3 nor = sPos - cpo;       //ぶつかった壁との座標の差でベクトルを出す
            nor.Normalize();
            bg.PassNormalRefrection(nor);   //反射
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !nonColRef) {
            Vector3 sPos = collision.transform.position;
            cpo = ClosestPtPointOBB(sPos);  //最近接点の座標を求める
            Vector3 nor = sPos - cpo;       //ぶつかった壁との座標の差でベクトルを出す
            nor.Normalize();
            bg.PushSamePower(nor);
        }
    }
}
