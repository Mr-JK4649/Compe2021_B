#define DEBUG_YAMA_ON_2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackingCamera : MonoBehaviour
{
// 定数の宣言、定義---
    const float BALL_MOVE_FREE_RANGE = 0.15f;  // ボールが自由に動ける範囲

// 変数の宣言---
    Transform trackCamera;         // カメラのトランスフォーム
    public Transform ball;         // ボールのトランスフォーム
    Vector3 disToBall;             // ボールまでの距離
    Vector3 ballStartPos;          // ボールの移動開始地点
    //Vector3 BallStartPosDiff;      // ボールの現在地点から移動開始点の差分
    float interpolationRate;       // ボールとカメラとの距離の補間割合
    bool cameraMoveFlg;            // カメラが移動するかを制御　true:移動する    false:移動しない
    bool cameraPosFitFlg;          // カメラがボールに張り付いたらtrue
    
// 関数ここから---
    // Start is called before the first frame update
    void Start()
    {
        trackCamera = this.transform;
        disToBall = new Vector3(0.0f, 1.4f, 0.4f);
        //disToBall = Vector3.zero;
        f_SetCameraPosAndRotation();
        ballStartPos = ball.position;
        //BallStartPosDiff = Vector3.zero;
        interpolationRate = 0.0f;
        cameraMoveFlg = false;
        cameraPosFitFlg = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ボールが動いているか判断
        f_BallMoveCheck();

        if (cameraMoveFlg == true)
            f_BallTracking();
    }

    /// <summary>
    ///  カメラからボールへの角度を返します
    /// </summary>
    Quaternion f_ReturnAngle_CameraToBall()
    {
        Quaternion angle;

        angle = Quaternion.LookRotation(ball.position - (trackCamera.position + disToBall));

        return angle;
    } 

    /// <summary>
    /// カメラをボールの動きに合わせて移動
    /// ｙ軸の移動は行わない
    /// </summary>
    void f_BallTracking()
    {
        const float ADD_INTER_VALU = 0.03f;    // interpolationValuに加算する値

        Vector2 mv = f_Move();

        trackCamera.position += new Vector3(mv.x, 0, mv.y);
        ballStartPos += new Vector3(mv.x, 0, mv.y);

        /*
        if (cameraPosFitFlg == true)
        {
            trackCamera.position = new Vector3(ball.position.x + disToBall.x,
                                               trackCamera.position.y,
                                               ball.position.z + disToBall.z);
        }
        else
        {
            float dis;              // ボールの初期地点から現在地点までの距離
            dis = Vector3.Distance(ball.position, ballStartPos);

            // カメラを徐々にボールに近づける
            trackCamera.position = Vector3.Lerp(trackCamera.position, 
                                                new Vector3(ball.position.x + disToBall.x,
                                                            trackCamera.position.y,
                                                            ball.position.z + disToBall.z),
                                                interpolationRate);

            // ボールからカメラの補間距離を増やす
            if (interpolationRate < 1.0f)
                interpolationRate += ADD_INTER_VALU;
            else if (interpolationRate > 1.0f)
            {
                interpolationRate = 1.0f;
            }
            else
            {
                interpolationRate = 0.0f;
                cameraPosFitFlg = true;
            }
        }
        */
    }

    /// <summary>
    /// ボールが動いているか判断
    /// </summary>
    /// <returns></returns>
    void f_BallMoveCheck()
    {
        float dis;              // ボールの初期地点から現在地点までの距離
        //dis = Vector3.Distance(ball.position, ballStartPos);
        dis = Vector2.Distance(new Vector2(ball.position.x, ball.position.z), 
                               new Vector2(ballStartPos.x, ballStartPos.z));


        if(dis < BALL_MOVE_FREE_RANGE)
        {
            cameraMoveFlg = false;
            cameraPosFitFlg = false;
            interpolationRate = 0.0f;
        }
        else
        {
            cameraMoveFlg = true;
        }

        /*
        // カメラが動いている場合
        if (cameraMoveFlg == true)
        {
            // 移動距離が条件より小さければ
            if (dis < 0.001f)
            {
                // カメラの追従を止める
                cameraMoveFlg = false;
                cameraPosFitFlg = false;
                //ballStartPos = this.transform.position;
                interpolationRate = 0.0f;
            }

            // ボールが動いている間ボールのスタート地点を更新
            ballStartPos = ball.position;
        }
        else
        {
            // ボールとの距離が一定以上開いたら追従を開始
            if (dis > 0.15f)
            {
                cameraMoveFlg = true;
            }
        }
        */

#if DEBUG_YAMA_ON
        Debug.Log("cameraMoveFlg");
        Debug.Log(cameraMoveFlg);
        Debug.Log("cameraPosFitFlg");
        Debug.Log(cameraPosFitFlg);
#endif
    }

    /// <summary>
    /// カメラの位置と角度を設定
    /// </summary>
    void f_SetCameraPosAndRotation()
    {
        trackCamera.position = ball.position;
        trackCamera.SetPositionAndRotation(ball.position + disToBall, f_ReturnAngle_CameraToBall());
    }

    Vector2 f_Move()
    {
        float dis;
        dis = Vector2.Distance(new Vector2(ball.position.x, ball.position.z),
                               new Vector2(ballStartPos.x, ballStartPos.z));
        float disHowMuch;
        disHowMuch = BALL_MOVE_FREE_RANGE / dis;  // 球初期地点から球までの距離の倍率 = 移動開始距離 / 球初期地点から球までの距離
        disHowMuch = 1 - disHowMuch;              //  球から円周までの距離を求めるのに必要な倍率 = 全体 - 球初期地点から球までの距離の倍率

#if DEBUG_YAMA_ON_2
        Debug.Log(disHowMuch);
#endif

        Vector2 moveVule = new Vector2((ball.position.x - ballStartPos.x) * disHowMuch,
                                       (ball.position.z - ballStartPos.z) * disHowMuch);
        
        return moveVule;
    }
}
