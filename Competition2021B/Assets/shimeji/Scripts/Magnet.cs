using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    bool isMagnet = true;
    Transform tra;
    Vector3 pos;

    private void Start()
    {
        tra = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        

        if (isMagnet) {
            pos = tra.position;

            this.transform.position = Vector3.Lerp(this.transform.position, pos, 0.05f);
        }
    }
}
