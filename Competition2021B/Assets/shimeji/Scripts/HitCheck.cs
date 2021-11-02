using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct OBB {
    Vector3[] scale;
}

public class HitCheck : MonoBehaviour
{

    //球の位置
    Vector3 spherePos;  //球の座標
    Vector3 sphereSca;  //球のスケール

    //床
    [SerializeField]
    Transform floor;
    Vector3 flPos;
    Vector3[] flAng;
    Vector3[] flSca;


    //壁ども
    [SerializeField]
    Transform[] wall;
    Vector3[] waPos;
    Vector3[][] waAng;
    Vector3[][] waSca; 

    // Start is called before the first frame update
    void Start()
    {
        //ボールのスケール
        sphereSca = transform.localScale;

        //床の初期化
        FloorUpdate(true, true, true);

        //床の初期化
        WallUpdate(true, true, true);
    }

    private void FixedUpdate()
    {
        //球の座標を取得
        spherePos = transform.position;

        //床の更新
        FloorUpdate(true, true, false);

        //壁の更新
        WallUpdate(true, true, false);
    }


    //void ClosestPtPointOBB(int num)
    //{
    //    Vector3 d = spherePos - waPos[num];
    //    Vector3 retvec = waPos[num];
    //    float dist;
    //    for (int i = 0; i < 3; i++)
    //    {
    //        dist = Vector3.Dot(d, waAng[num][i]);
    //        if (dist > waSca[num][i])
    //        {
    //            dist = obb.m_Size[i];
    //        }
    //        if (dist < -obb.m_Size[i])
    //        {
    //            dist = -obb.m_Size[i];
    //        }
    //        retvec += dist * obb.m_Rot[i];
    //    }
    //}


    void FloorUpdate(bool a, bool b, bool c) {
        if(a)flPos = floor.position;
        //if(b)flAng = floor.eulerAngles;
       // if(c)flSca = floor.localScale / 2.0f;
    }

    void WallUpdate(bool a, bool b, bool c) {
        for (int i = 0; i < wall.Length; i++)
        {
            if(a)waPos[i] = wall[i].position;
            //if(b)waAng[i] = wall[i].eulerAngles;
            //if(c)waSca[i] = wall[i].localScale / 2.0f;
        }
    }
}
