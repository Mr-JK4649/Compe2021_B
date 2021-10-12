using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRota: MonoBehaviour
{
    Transform Floor;

    // ワールド座標を基準に、回転を取得
    Vector3 FloorRota1 = new Vector3(0, 0, 0);

    private void Start()
    {
        Floor = this.transform;
    }


    void Update()
    {

        if (Floor.rotation.x*180<=30.0f && Floor.rotation.x*180>=-30) {
            FloorRota1.x = -Input.GetAxis("Vertical");
            FloorRota1.y = 0;
           // FloorRota1.z = Input.GetAxis("Horizontal");

            Floor.transform.Rotate(FloorRota1);
        }

       Debug.Log(Floor.localEulerAngles);
        // transform.Rotate(new Vector3(0, 0, 5));
    }
}
