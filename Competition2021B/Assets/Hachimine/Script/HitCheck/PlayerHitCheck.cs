using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCheck : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject hit_obj;


    HitCheckScript hitchek;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Ball"); //プレイヤー名
        }

        if (hitchek == null)
        {
            hit_obj = GameObject.Find("CoinManager"); //オブジェクト名前
        }

        hitchek = hit_obj.GetComponent<HitCheckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitchek.HitCheck(player, this.gameObject))
        {
            Debug.Log("当たっている");
            //Destroy(this.gameObject);

        }
        else
        {
            Debug.Log("当たってない");
        }

    }
}
