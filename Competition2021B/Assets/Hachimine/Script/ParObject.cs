using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParObject : MonoBehaviour
{
    public static int childCoin;
    [SerializeField] public static int Coinkazu;　//現在のオブジェクトの数を数える
    [SerializeField] public static int Unkomorimori; //最初の子オブジェクトの数を数える
    //public bool cgetflag;
    //int i = 3;
    // Start is called before the first frame update
    void Start()
    {
        //cgetflag = false;
        Unkomorimori = this.transform.childCount;
    }
    // Update is called once per frame
    void Update()
    {
        //int childCoin = this.transform.childCount; //子オブジェクトを数える
        int childCoin = this.transform.childCount; //子オブジェクトを数える
        Coinkazu = childCoin;
        //Debug.Log(childCoin);
    }
}
