using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheVirtualBall : MonoBehaviour
{
    Transform obj;
    Vector3 moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        obj = this.transform;
        moveSpeed = new Vector3(0.001f, -0.000f, 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        obj.position += moveSpeed;
        obj.SetPositionAndRotation(obj.position, obj.rotation);
    }
}
