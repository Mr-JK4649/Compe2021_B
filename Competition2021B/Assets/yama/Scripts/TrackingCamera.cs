using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrackingCamera : MonoBehaviour
{
    Transform trackCamera;         // カメラのトランスフォーム
    public Transform ball;         // ボールのトランスフォーム
    Vector3 disToBall;             // ボールまでの距離
    Vector3 ballStartPos;          // ボールの移動開始地点
    Vector3 BallStartPosDiff;      // ボールの現在地点から移動開始点の差分
    Vector3 count;                 // ボールの移動量
    bool cameraMoveFlg;            // カメラが移動するかを制御　true:移動する    false:移動しない
    bool cameraPosFitFlg;          // カメラがボールに張り付いたらtrue

    public float dis;              // カメラからボールまでの距離


    // Start is called before the first frame update
    void Start()
    {
        trackCamera = this.transform;
        disToBall = new Vector3(0.0f, 0.5f, 0.5f);
        SetCameraPosAndRotation();
        ballStartPos = ball.position;
        BallStartPosDiff = Vector3.zero;
        count = Vector3.zero;
        cameraMoveFlg = false;
        cameraPosFitFlg = false;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        angle = Quaternion.LookRotation(ball.position - (trackCamera.position + disToBall));

        return angle;
    } 

    /// <summary>
    /// カメラをボールの動きに合わせて移動
    /// ｙ軸の移動は行わない
    /// </summary>
    void BallTracking()
    {

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
                                                   0.05f);
            if (trackCamera.position == (ball.position + disToBall))
                cameraPosFitFlg = true;
        }
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

        //if (cameraMoveFlg) {
        //    if (dis == 0) {
        //        ballStartPos = this.transform.position;
        //        cameraMoveFlg = false;
        //    }
        //}

    }

    /// <summary>
    /// カメラの位置と角度を設定
    /// </summary>
    void SetCameraPosAndRotation()
    {
        trackCamera.position = ball.position;
        //trackCamera.position += disToBall;
        //disToBall = trackCamera.position - ball.position;
        trackCamera.SetPositionAndRotation(ball.position + disToBall, ReturnAngle_CameraToBall());
    }
}
