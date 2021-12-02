using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    AudioSource ass;

    Rigidbody rb;

    private void Start()
    {
        ass = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x + rb.velocity.z != 0.0f)
            if(!ass.isPlaying)ass.Play();
        else
            ass.Stop();
    }
}
