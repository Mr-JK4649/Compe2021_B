using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHitCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerBall;
    [SerializeField, Tooltip("オブジェクトとオブジェクトの距離：")]
    float dist; //球と球の距離
    [SerializeField, Tooltip("オブジェクトとオブジェクトの距離： 2乗")]
    float dist2;//球と球の距離のべき乗計算
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Example();
    }
    void Example()
    {
        dist = Vector3.Distance(PlayerBall.position, transform.position);
        dist2 = Mathf.Pow(dist, 2.0f);

        Debug.Log("確認用 Distance to other :" + dist);
    }
}
