using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    GameObject CoinManeger;
    CoinGetText coingettext;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CoinManeger = GameObject.Find("CoinManager");
        coingettext = CoinManeger.GetComponent<CoinGetText>();
    }
    void OnTriggerEnter(Collider coin)
    {
        if (coin.gameObject.tag == "coin")
        {
            Debug.Log("Hello World");
            coingettext.CoinCollect_Point += 1 ; //コインを取った時の数値に＋１する。
        }
    }
}
