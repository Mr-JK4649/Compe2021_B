using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    [SerializeField] private float gravity = 0f;
    [SerializeField,Tooltip("落ちる速さ(毎秒毎秒)")] private float speed = 0f;
    [SerializeField] private bool isFall = true;

    //床の法線ベクトルのやし
    public GetNormals gn;

    public float spd;

    //進行方向
    private Vector3 moveVec;

    //床の法線
    private Vector3 floorNor;

    private void FixedUpdate()
    {

        moveVec.x = floorNor.x * spd;
        moveVec.y = 0;
        moveVec.z = floorNor.z * spd;

        if (isFall)
        {
            moveVec.y = gravity;
            gravity += -0.098f * Time.deltaTime;
        }
        else {
            gravity = 0;
        }

        this.transform.position += moveVec;

    }

    private void OnCollisionEnter(Collision collision)
    {
        isFall = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        floorNor = gn.GetNormal();
    }

    private void OnCollisionExit(Collision collision)
    {
        isFall = true;
    }

}
