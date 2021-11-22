using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreadUpDownItem : MonoBehaviour
{


    //[SerializeField] GameObject GreadUpItem;
    [SerializeField] GameObject PlayerBall;

    [SerializeField] public float Mu; //球の大きさの倍数
    //[SerializeField] public float sdi=0; //球の速さを半分にする

    GameObject PlayerSphreSpd;
    BallGravity GravitySpd;


    bool Itemflg;
    float Unko = 0.2f;
    float Unko2 = 0.1f;
    float Speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSphreSpd = GameObject.Find("Ball");
        GravitySpd = PlayerSphreSpd.GetComponent<BallGravity>();
        Itemflg = false; //アイテムを使って450フレームまでTrue
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GradeUp" && Itemflg == false)
        {
            Unko *= Mu;
            Itemflg = true;
            PlayerBall.transform.localScale = new Vector3(Unko, Unko, Unko);
            Invoke("TimeDownGread", 7.5f);
           
        }
        if (other.gameObject.tag=="GreadDown" && Itemflg==false) {
            Itemflg = true;
            //sdi /= 2;
            GravitySpd.spd /= 2f;
            Invoke("TimeUpGread",2.0f);
        }
    }
    private void TimeDownGread()　//大きさが戻る
    {
        Unko = 0.2f;
        Vector3 Playery = transform.position;
        Playery.y -= Unko2;
        transform.position = Playery;


        Itemflg = false;
        PlayerBall.transform.localScale = new Vector3(Unko, Unko, Unko);
    }

    private void TimeUpGread() //速さが戻る
    {
        GravitySpd.spd *= 2;
        Itemflg = true;
    }
}
