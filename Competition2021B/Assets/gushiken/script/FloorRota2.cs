using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRota2 : MonoBehaviour
{

    public Vector3 FloorRota = new Vector3(0,0,0);

    public float speed = 0;

    private float testFlame = 0;
    private float Box = 0.0f;

    private float tiltx=0; //x軸の傾いている方向を入れる
    private float tiltz=0; //y軸の傾いている方向を入れる
    //private float adc = speed / 60;

    //private float Pspeed =;



    void Start()
    {
        
    }


   


    void FixedUpdate()
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
        //Debug.Log(tiltx);
       // Debug.Log(tiltz);

        //Quaternion rotate = Quaternion.Euler(FloorRota.x, 0, FloorRota.z);

        transform.rotation = Quaternion.Euler(FloorRota.x, 0, FloorRota.z);

        //this.transform.rotation = rotate;


    }

    void TiltSpeed()//床の傾きのスピードの処理
    {

        float OneFlamemove = 30.0f/8100.0f;  //水平から30度までの
        

        tiltx = Input.GetAxis("Vertical");
        tiltz = Input.GetAxis("Horizontal");

        if (tiltx==1 && tiltz ==1 || tiltx==-1 && tiltz==-1 || tiltx==-1 && tiltz==1 || tiltx==1 && tiltz==-1)//斜めの操作を制限
        {
            
          speed = 0.0f;

        }else if(tiltx==0&&tiltz==0){//ニュートラルの時

            if (speed>0)
            {

            }

            if (FloorRota.x!=0||FloorRota.z!=0) {///////傾いていたら

                ///////////**************x軸を0に戻す処理
                if (FloorRota.x < 0)
                {
                    //FloorRota.x += 0.3f;
                    Box +=OneFlamemove;
                    FloorRota.x += Box;
                    if (FloorRota.x > 0)
                    {
                        Box = 0.0f;
                        speed = 0.0f;
                        FloorRota.x = 0.0f;
                    }
                }
                if (FloorRota.x > 0)
                {
                    //FloorRota.x -= 0.3f;
                    Box += OneFlamemove;
                    FloorRota.x -= Box;
                    if (FloorRota.x < 0)
                    {
                        Box = 0.0f;
                        speed = 0.0f;
                        FloorRota.x = 0.0f;
                    }
                }
                /////////*******************ここまで

                ///////////----------------------z軸を0に戻す処理
                if (FloorRota.z < 0)
                {
                    //FloorRota.z += 0.3f;
                    Box += OneFlamemove;
                    FloorRota.z += Box;
                    if (FloorRota.z > 0)
                    {
                        Box = 0.0f;
                        speed = 0.0f;
                        FloorRota.z = 0.0f;
                    }
                }
                if (FloorRota.z > 0)
                {
                    //FloorRota.z -= 0.3f;
                    Box += OneFlamemove;
                    FloorRota.z -= Box;
                    if (FloorRota.z < 0)
                    {
                        Box = 0.0f;
                        speed = 0.0f;
                        FloorRota.z = 0.0f;
                    }
                }
                /////////--------------------------ここまで

                Debug.Log(Box);
            }/////////傾いていたら

        }
        else{//十字キーを操作している時
            testFlame++;
         
            speed += OneFlamemove;

            if (FloorRota.x>=30)
            {
                Debug.Log(testFlame);
            }



           // Debug.Log(testFlame);
        }
    }

    void Frame()
    {

    }

}


