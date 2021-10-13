using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRota2 : MonoBehaviour
{

    public Vector3 FloorRota = new Vector3(0,0,0);

    public float speed = 0;
    private float tiltx=0;
    private float tiltz=0;



    void Start()
    {
        
    }


   


    void Update()
    {
        //ここらへん
        TiltSpeed();
        FloorRota.x += speed*-Input.GetAxis("Vertical");
        FloorRota.z += speed* Input.GetAxis("Horizontal");


        if (FloorRota.x > 30)       //**xの傾きをを制限かける処理
        {
            FloorRota.x = 30.0f;
        }

        if (FloorRota.x < -30)
        {
            FloorRota.x = -30.0f;
        }                         //**ここまで

        if (FloorRota.z > 30)       //--yの傾きを制限かける処理
        {
            FloorRota.z = 30.0f;
        }

        if (FloorRota.z < -30)
        {
            FloorRota.z = -30.0f;
        }                           //--ここまで




        //ここらへん


        Debug.Log(speed);

        Quaternion rotate = Quaternion.Euler(FloorRota.x, 0, FloorRota.z);

        this.transform.rotation = rotate;


    }

    void TiltSpeed()//床の傾きのスピードの処理
    {
        tiltx = Input.GetAxis("Vertical");
        tiltz = Input.GetAxis("Horizontal");

        if (tiltx==1 && tiltz ==1 || tiltx==-1 && tiltz==-1 || tiltx==-1 && tiltz==1 || tiltx==1 && tiltz==-1 || tiltx==0 &&tiltz==0)//斜めの操作を制限
        {
            speed = 0.0f;//speedに0を代入して止める
        }else{
            if (speed <= 1.0f)
            {
                speed += 0.005f;
            }
        }
    }

}



