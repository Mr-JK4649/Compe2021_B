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
        if (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.z) > 0.05f)
        {
            if (ass.isPlaying == false)
                ass.Play();
        }
        else
        {
            ass.Stop();
        }
    }
}
