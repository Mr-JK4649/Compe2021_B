using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRota: MonoBehaviour
{
    Transform Floor;

    // ワールド座標を基準に、回転を取得
    public Vector3 FloorRota1 = new Vector3(0, 0, 0);

    private float oriYpos = 0;

    public float speed = 0;

    

    private void Start()
    {
        Floor = this.transform;

        //開始時のｙ座標を格納
        oriYpos = Floor.transform.rotation.y;
    }


    void Update()
    {
   
       // if (Floor.rotation.x * 180 <= 46.0f && Floor.rotation.x * 180 >= -46.0f && Floor.rotation.z * 180 < 46.0f && Floor.rotation.z * 180 > -46.0f)
        //{


            FloorRota1.x += speed * -Input.GetAxis("Vertical");
            FloorRota1.y = oriYpos;
            FloorRota1.z += speed * Input.GetAxis("Horizontal");


        // }



        //transform.rotation = new Quaternion(transform.rotation.x,0,transform.rotation.z,0);
        //transform.SetPositionAndRotation(Floor.position, Quaternion.e);/*(Floor.rotation.x,0.0f,Floor.rotation.z,0.0f)*/


        if (Mathf.Abs(Floor.rotation.x * 180  +  FloorRota1.x)> 46.0f)
        {
            FloorRota1.x = 0.0f;
           
        }
        Debug.Log(Mathf.Abs(Floor.rotation.x * 180 + FloorRota1.x));

        if (Mathf.Abs(Floor.rotation.z * 180 + FloorRota1.z) > 46.0f) {

            FloorRota1.z = 0.0f;

        }

        Floor.transform.Rotate(FloorRota1,Space.World);

       // Debug.Log(Floor.rotation.x);
        // transform.Rotate(new Vector3(0, 0, 5));
    }
}
