using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHitCheck2 : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerBall; //プレイヤー
    [SerializeField]
    GameObject[] ItemObj; //オブジェクトを入れる

    Vector3 Player; //プレイヤーの座標
    float Pookisa;  //プレイヤーの大きさ
    float disX;
    float disY;
    float disZ;
    float pmsizekari2;
    public bool Itemflg;

    /*リスト*/
    List<Vector3> ItemObjTmp = new List<Vector3>(); //リスト宣言　アイテム
    List<Vector3> ItemObjScale = new List<Vector3>(); //大きさ
   

    [SerializeField]
    public int objnumber; //オブジェクトのナンバー

    //public bool hitcflg;
    /*他の関数*/
    GameObject ChildObject;
    ParObject ChilOb;

    // Start is called before the first frame update
    void Start()
    {
        ChildObject = GameObject.Find("CoinGroup 1");
        ChilOb = ChildObject.GetComponent<ParObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Itemflg = false;
        Example();
    }
    void Example()
    {
        Player = PlayerBall.transform.position;
        Pookisa = PlayerBall.transform.localScale.x;
        for (int i = 0; i < objnumber; i++)
        {
            ItemObjTmp.Add(ItemObj[i].transform.position); //Listに座標の値を格納する。
            ItemObjScale.Add(ItemObj[i].transform.localScale); //Listに大きさの値を格納する。
            //Debug.Log("座標" + ItemObjTmp[i]);
            //Debug.Log("大きさ" + ItemObjScale[i]);

            float Pookisa2 = Pookisa / 2;
            float ItemObj2 = ItemObjScale[i].x / 2;

            float pmsizekari = Pookisa2 + ItemObj2;
            pmsizekari2 = Mathf.Pow(pmsizekari, 2.0f);
        }

        for (int i=0; i < objnumber; i++)
        {
             disX = Player.x - ItemObjTmp[i].x;
             disY = Player.y - ItemObjTmp[i].y;
             disZ = Player.z - ItemObjTmp[i].z;

            if (disX * disX + disY * disY + disZ * disZ <= pmsizekari2)
            {
                Debug.Log("こいつは:" + ItemObj[i]);

                ItemObj[i].SetActive(false);
            }
            
        }
    }
}
