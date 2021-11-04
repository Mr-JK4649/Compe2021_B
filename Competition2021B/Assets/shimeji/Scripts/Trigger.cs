using UnityEngine;
using UnityEngine.Events;
using System;

public class Trigger : MonoBehaviour
{
    [SerializeField] private SEEvent seEve = new SEEvent();

    public void FuncA(){ seEve.Invoke();}
    //public void OnCollisionEnter (Collision other){ onConEn.Invoke();}
    //public void OnCollisionExit (Collision other){ onConEx.Invoke();}
    //public void OnCollisionStay (Collision other){ onConSt.Invoke();}

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
