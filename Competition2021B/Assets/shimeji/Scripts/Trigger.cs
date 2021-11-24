using UnityEngine;
using UnityEngine.Events;
using System;

public class Trigger : MonoBehaviour
{
    public enum Kind{ 
        coin,
        Wall,
        Player,
        Floor,
        GradeUp,
        GradeDown
    }

    [SerializeField] Kind objTag;
    [SerializeField] AudioSource ass;

    [SerializeField] private SEEvent seColEnt = new SEEvent();
    [SerializeField] private SEEvent seColStay = new SEEvent();
    [SerializeField] private SEEvent seTriEnt = new SEEvent();

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == objTag.ToString())
            seColEnt.Invoke();
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == objTag.ToString())
        {
            if(!ass.isPlaying)
                seColStay.Invoke();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == objTag.ToString())
            seTriEnt.Invoke();
    }
    //public void OnCollisionEnter (Collision other){ onConEn.Invoke();}
    //public void OnCollisionExit (Collision other){ onConEx.Invoke();}
    //public void OnCollisionStay (Collision other){ onConSt.Invoke();}

    public void RingSound(AudioClip ac) {
        ass.PlayOneShot(ac);
    }

    [Serializable]
    public class SEEvent : UnityEvent
    {
    }

}


//UnityEventの引数の書き方
//public class TE_Class_Name : UnityEvent<argument>{}
// 以下、例

//public class TE_Class_Name : UnityEvent<Collider>{}
//public class TE_Class_Name : UnityEvent<Vector3>{}
