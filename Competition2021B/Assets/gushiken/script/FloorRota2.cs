
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FloorRota2 : MonoBehaviour
{

    public Vector3 FloorRota = new Vector3(0,0,0);

    public float speed = 0;
    //private float speedBox = 0;

    private float testFlame = 0;   //テスト用
    private float Box = 0.0f;      //床の角度を0度にするための処理に使う変数
    private float Box2 = 0.0f;

    private float tiltx=0; //x軸の傾けている方向を入れる
    private float tiltz=0; //y軸の傾けている方向を入れる
    private float tilta = 0;
    private float Oldtilta = 0;

    private float OldInputx = 0; //前回入力したx軸入力を入れる
    private float OldInputz = 0; //前回入力したｚ軸の入力を入れる
    private int  stopp=0; 
    


    //private float adc = speed / 60;

    //private float Pspeed =;



    void Start()
    {
        
    }


   


    void FixedUpdate()
    {
        //ここらへん
        //TiltSpeed();

        //GETAXISを使ってスピードを上げる
        //GETAXISは負の位置：-1 ニュートラル：0 正の位置：1になる
        //どの方向でも傾いている間にスピードだけが加算されていき逆に入力すると減算した後に入力した方向に移動する

        //testFlame=Mathf.Abs(speed*Input.GetAxis("Vertical"));

        //if (FloorRota.x < 30 && FloorRota.x > -30 && FloorRota.z < 30 && FloorRota.z > -30) {
        //    if (stopp == 0)
        //    {
                FloorRota.x += speed * -Input.GetAxisRaw("Vertical");
                FloorRota.z += speed * Input.GetAxisRaw("Horizontal");
        //    }
        //    else {
        //        FloorRota.x += speed * +Input.GetAxisRaw("Vertical");
        //        FloorRota.z += speed * -Input.GetAxisRaw("Horizontal");

        //    }
        //}



    TiltSpeed();

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


        //Debug.Log(testFlame);
        //Debug.Log(tiltx);
       // Debug.Log(tiltz);

        //Quaternion rotate = Quaternion.Euler(FloorRota.x, 0, FloorRota.z);

        transform.rotation = Quaternion.Euler(FloorRota.x, 0, FloorRota.z);

        //this.transform.rotation = rotate;


    }

    void TiltSpeed()//床の傾きのスピードの処理
    {

        float OneFlamemove = 30.0f/8100.0f;  //水平から30度までの
        
        
        //tilt
        tiltx = Input.GetAxisRaw("Vertical");
        tilta = tiltx;
        tiltz = 3 + Input.GetAxisRaw("Horizontal");

        if (tiltx == 0)
        {
            tilta = tiltz;
        }

        
        



        if (tiltx==1 && tiltz ==4 || tiltx==-1 && tiltz==2 || tiltx==-1 && tiltz==4 || tiltx==1 && tiltz==2)//斜めの操作を制限
        {
            
          speed = 0.0f;

        }else if(tiltx==0&&tiltz==3){//ニュートラルの時

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

               // Debug.Log(Box);
            }//////////////////////////////////////////////////////////傾いていたら

        }
        else{//十字キーを操作している時
            testFlame++;


            if (speed>0&&tilta!=Oldtilta)
            {

                speed -= OneFlamemove*1.6f;
                stopp = 1;
            }
            else
            {
                speed += OneFlamemove;
                Oldtilta = tilta;
                stopp = 0;
            }

            if (testFlame==90)
            {
                //フレームを測る用、ブレークポイントを着けて使用
                //xが30度傾いたら止める
                Debug.Log(FloorRota.x);
            }

           // Debug.Log(testFlame);
        }

    }


}


