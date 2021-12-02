using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheat : MonoBehaviour
{
    
    void Start()
    {
        GameObject coins = GameObject.Find("CoinGroup 1");
        int num = coins.transform.childCount;
        for (int i = 0; i < num; i++) {
            coins.transform.GetChild(i).gameObject.AddComponent<Magnet>();
        }
    }
}
