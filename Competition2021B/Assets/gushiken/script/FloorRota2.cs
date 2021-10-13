using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRota2 : MonoBehaviour
{

    public Vector3 FloorRota = new Vector3(0,0,0);


    void Start()
    {
        
    }


   


    void Update()
    {
        //ここらへん
        FloorRota.x += -Input.GetAxis("Vertical");
        FloorRota.z += Input.GetAxis("Horizontal");



        //ここらへん

      Quaternion rotate = Quaternion.Euler(FloorRota.x, 0, FloorRota.z);

        this.transform.rotation = rotate;


    }
}
