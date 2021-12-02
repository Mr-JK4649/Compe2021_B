using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBall : MonoBehaviour
{
    Transform ball;

    private void Start()
    {
        ball = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        this.transform.LookAt(ball);
    }
}
