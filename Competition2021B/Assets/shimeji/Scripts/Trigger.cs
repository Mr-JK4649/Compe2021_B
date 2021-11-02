using UnityEngine;
using UnityEngine.Events;
using System;

public class Trigger : MonoBehaviour
{
    [SerializeField] private TriggerEvent te = new TriggerEvent();
    [SerializeField] private TriggerEvent onConEn = new TriggerEvent();
    [SerializeField] private TriggerEvent onConEx = new TriggerEvent();
    [SerializeField] private TriggerEvent onConSt = new TriggerEvent();

    public void FuncA(){ te.Invoke();}
    public void OnCollisionEnter (Collision other){ onConEn.Invoke();}
    public void OnCollisionExit (Collision other){ onConEx.Invoke();}
    public void OnCollisionStay (Collision other){ onConSt.Invoke();}

    [Serializable]
    public class TriggerEvent : UnityEvent
    {
    }

}


//UnityEventの引数の書き方
//public class TE_Class_Name : UnityEvent<argument>{}
// 以下、例

//public class TE_Class_Name : UnityEvent<Collider>{}
//public class TE_Class_Name : UnityEvent<Vector3>{}
