using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounder : MonoBehaviour
{
    public enum t
    {
        ColliderEnter,
        ColliderStay,
        TriggerEnter
    }

    public struct au {
        public AudioClip clip;
        public t timing;
        public string objTag;
    }

   public au[] sounds;


    public void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < sounds.Length; i++) { 
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < sounds.Length; i++)
        {

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < sounds.Length; i++)
        {

        }
    }
}
