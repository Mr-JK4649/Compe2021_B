﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    [SerializeField] private float gravity = 9.81f;

    private void FixedUpdate()
    {
        Vector3 movePos = Vector3.zero;
        movePos.x = 0;
        movePos.y = gravity;
        movePos.z = 0;
        this.transform.position += movePos;
    }
}
