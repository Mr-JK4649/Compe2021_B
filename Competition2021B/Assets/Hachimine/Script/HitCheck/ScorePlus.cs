using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlus : MonoBehaviour
{

    GameObject CoinManeger;
    CoinGetText coingettext;
    public GameObject getCoinFX;

    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject hit_objplu;

    HitCheckScript hitcheck_scoreplus;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Ball"); //プレイヤーメイ
        }
        if (hitcheck_scoreplus == null)
        {
            hit_objplu = GameObject.Find("CoinManager"); //HitCheckScriptを使いたい
        }
        hitcheck_scoreplus = hit_objplu.GetComponent<HitCheckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinManeger = GameObject.Find("CoinManager");
        coingettext = CoinManeger.GetComponent<CoinGetText>();
        CoinPlus();
    }
    void CoinPlus()
    {
        if (hitcheck_scoreplus.HitCheck(player, this.gameObject))
        {
            coingettext.CoinCollect_Point += 1; //コインを取った時の数値に＋１する。
            GameObject effe = Instantiate(getCoinFX, this.transform.position, Quaternion.identity);
            Destroy(effe, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
