using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParObject : MonoBehaviour
{
    public static int childCoin = 0;
    //int i = 3;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        childCoin = this.transform.childCount; //子オブジェクトを数える

        Debug.Log(childCoin);
    }
}
