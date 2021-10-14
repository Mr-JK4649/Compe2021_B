using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    Transform trackingCamera;      // カメラのトランスフォーム
    public Transform ball;         // ボールのトランスフォーム
    Vector3 disToBall;             // ボールまでの距離
    Vector3 ballStartPos;          // ボールの移動開始地点
    Vector3 BallStartPosDiff;      // ボールの現在地点から移動開始点の差分
    Vector3 count;                 // ボールの移動量
    bool cameraMoveFlg;            // カメラが移動するかを制御　true:移動する    false:移動しない

    public float dis;              // カメラからボールまでの距離


    // Start is called before the first frame update
    void Start()
    {
        trackingCamera = this.transform; 
        SetCameraPosAndRotation();
        ballStartPos = ball.position;
        BallStartPosDiff = Vector3.zero;
        count = Vector3.zero;
        cameraMoveFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        // ボールが動いているか判断
        BallMoveCheck();

        if (cameraMoveFlg == true)
            BallTracking();
    }

    /// <summary>
    ///  カメラからボールへの角度を返します
    /// </summary>
    Quaternion ReturnAngle_CameraToBall()
    {
        Quaternion angle;

        angle = Quaternion.LookRotation(ball.position - trackingCamera.position);

        return angle;
    } 

    /// <summary>
    /// カメラをボールの動きに合わせて移動
    /// ｙ軸の移動は行わない
    /// </summary>
    void BallTracking()
    {
        //trackingCamera.position = new Vector3(ball.position.x + disToBall.x, 
        //                                      trackingCamera.position.y, 
        //                                      ball.position.z + disToBall.z);
        
        // カメラを徐々にボールに近づける
        trackingCamera.position = Vector3.Lerp(trackingCamera.position, ball.position + disToBall, 0.005f);
    }

    /// <summary>
    /// ボールが動いているか判断
    /// </summary>
    /// <returns></returns>
    void BallMoveCheck()
    {
        Vector3 moveAmount;

        if (cameraMoveFlg == true)
        {
            return;
        }

        moveAmount = ball.position - (ballStartPos + BallStartPosDiff);
        BallStartPosDiff += moveAmount;
        count.x += Mathf.Abs(moveAmount.x);
        count.y += Mathf.Abs(moveAmount.y);
        count.z += Mathf.Abs(moveAmount.z);


        dis = Vector3.Distance(ball.position, ballStartPos);
        //if(count.x + count.y + count.z > 0.15f)
        //{
        //    cameraMoveFlg = true;
        //}
        if (dis > 0.15f) {
            cameraMoveFlg = true;
        }

        if (cameraMoveFlg) {
            if (dis == 0) {
                ballStartPos = this.transform.position;
                cameraMoveFlg = false;
            }
        }

    }

    /// <summary>
    /// カメラの位置と角度を設定
    /// </summary>
    void SetCameraPosAndRotation()
    {
        disToBall = trackingCamera.position - ball.position;
        trackingCamera.SetPositionAndRotation(ball.position + disToBall, ReturnAngle_CameraToBall());
    }
}
