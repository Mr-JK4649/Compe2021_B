using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParObject : MonoBehaviour
{
    public static int childCoin = 0;
    //public bool cgetflag;
    //int i = 3;
    // Start is called before the first frame update
    void Start()
    {
        //cgetflag = false;
    }
    // Update is called once per frame
    void Update()
    {
        childCoin = this.transform.childCount; //子オブジェクトを数える
        
        //Debug.Log(childCoin);
    }
}
