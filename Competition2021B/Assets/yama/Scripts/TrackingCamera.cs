#define DEBUG_YAMA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    Transform trackCamera;         // カメラのトランスフォーム
    public Transform ball;         // ボールのトランスフォーム
    Vector3 disToBall;             // ボールまでの距離
    Vector3 ballStartPos;          // ボールの移動開始地点
    //Vector3 BallStartPosDiff;      // ボールの現在地点から移動開始点の差分
    float interpolationValu;       // ボールとカメラとの距離の補間割合
    bool cameraMoveFlg;            // カメラが移動するかを制御　true:移動する    false:移動しない
    bool cameraPosFitFlg;          // カメラがボールに張り付いたらtrue



    // Start is called before the first frame update
    void Start()
    {
        trackCamera = this.transform;
        disToBall = new Vector3(0.0f, 1.4f, 0.4f);
        f_SetCameraPosAndRotation();
        ballStartPos = ball.position;
        //BallStartPosDiff = Vector3.zero;
        interpolationValu = 0.0f;
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

        if (cameraPosFitFlg == true)
        {
            trackCamera.position = new Vector3(ball.position.x + disToBall.x,
                                               trackCamera.position.y,
                                               ball.position.z + disToBall.z);
        }
        else
        {
            // カメラを徐々にボールに近づける
            trackCamera.position = Vector3.Lerp(trackCamera.position, 
                                                new Vector3(ball.position.x + disToBall.x,
                                                            trackCamera.position.y,
                                                            ball.position.z + disToBall.z),
                                                interpolationValu);

            // ボールからカメラ帆の補間距離を増やす
            if (interpolationValu < 1.0f)
                interpolationValu += ADD_INTER_VALU;
            else if (interpolationValu > 1.0f)
            {
                interpolationValu = 1.0f;
            }
            else
            {
                interpolationValu = 0.0f;
                cameraPosFitFlg = true;
            }
        }
    }

    /// <summary>
    /// ボールが動いているか判断
    /// </summary>
    /// <returns></returns>
    void f_BallMoveCheck()
    {
        float dis;              // ボールの初期地点から現在地点までの距離
        dis = Vector3.Distance(ball.position, ballStartPos);
        
        if (cameraMoveFlg == true)
        {
            if (dis == 0.0f)
            {
                //ballStartPos = this.transform.position;
                cameraMoveFlg = false;
                cameraPosFitFlg = false;
            }

            // ボールが動いている間ボールのスタート地点を更新
            ballStartPos = ball.position;
        }
        else
        {
            if (dis > 0.15f)
            {
                cameraMoveFlg = true;
            }
        }
#if DEBUG_YAMA
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
}
