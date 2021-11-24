using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHitCheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform PlayerBall;//プレイヤー
    [SerializeField]
    public Transform ObjectMe;//自分を入れる
    
    


    float dist; //球と球の距離

    float dist2;//球と球の距離のべき乗計算
    
    /*[SerializeField, Tooltip("半径の大きさ :")]
    Vector3 pmsize;
    */
    [SerializeField, Tooltip("大きさ　:")]
    float Pookisa;
    [SerializeField, Tooltip("アイテムの大きさ :")]
    float Mookisa;

    public bool hitcflg;

    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        hitcflg = false;
        Example();
        
    }
    void Example()
    {
        /*dist = Vector3.Distance(PlayerBall.position, transform.position);
        dist2 = Mathf.Pow(dist, 2.0f);
        */
        

        Vector3 Player = PlayerBall.transform.position;
        Vector3 Me = ObjectMe.transform.position;


        Vector3 PSca = PlayerBall.transform.localScale;
        Vector3 MSca = ObjectMe.transform.localScale;

        

        Pookisa = PlayerBall.transform.localScale.x;
        Mookisa = ObjectMe.transform.localScale.x;

        float Pookisa2 = Pookisa / 2;
        float Mookisa2 = Mookisa / 2;
        
        float pmsizekari = Pookisa2 + Mookisa2;
        

        //Debug.Log("unko" + Pookisa);
        
        //pmsize = PSca + MSca; //半径同士を図る
        //Debug.Log("今日の大きさ :" + pmsize);


        float pmsizekari2 = Mathf.Pow(pmsizekari,2.0f);


        float disX = Player.x - Me.x;
        float disY = Player.y - Me.y;
        float disZ = Player.z - Me.z;

        float disx2 = Mathf.Pow(disX, 2.0f);
        float disy2 = Mathf.Pow(disY, 2.0f);
        float disz2 = Mathf.Pow(disZ, 2.0f);



        if (disx2 + disy2 + disz2 <= pmsizekari2)
        {
            hitcflg = true; //当たり判定
            //Destroy(this.gameObject);
        }

        //Debug.Log("確認用 Distance to other :" + dist);
    }
}
