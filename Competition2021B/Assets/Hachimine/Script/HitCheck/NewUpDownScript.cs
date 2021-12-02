using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUpDownScript : MonoBehaviour
{
    const float FX_MAX_TIME = 0.3f;    // エフェクト再生時間

    [SerializeField] GameObject player;
    [SerializeField] GameObject hit_obj_item;
    

    [SerializeField] public float Mu;//球の大きさの倍数

    private GameObject FX_SizeUp = null;

    //GameObject PlayerBall;

    GameObject PlayerSphereSpd;
    BallGravity GravitySpd;

    bool Itemflg;//バフ
    bool Itemflg2;//デバフ
    float Unko = 0.2f;
    float Unko2 = 0.1f;
    float Speed = 0;
    
    HitCheckScript hitcheck_bufdbuf;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Ball"); //プレイヤーメイ
        }
        /*if (hit_obj_item == null)
        {
            hit_obj_item = GameObject.Find("CoinManager"); //HitCheckScriptを使いたい
        }*/

        PlayerSphereSpd = GameObject.Find("Ball");
        GravitySpd = PlayerSphereSpd.GetComponent<BallGravity>();

        Rigidbody rb = GetComponent<Rigidbody>();

        //FX_SizeUp = GameObject.Find("SizeUp");
        FX_SizeUp = player.transform.Find("SizeUp").gameObject;
        Debug.Log(FX_SizeUp);
        FX_SizeUp.SetActive(false);

        Itemflg = false; //アイテムを取得してから450フレームまでTrue
        Itemflg2 = false; //アイテムを取得してから120フレームまでTrue

        


    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(hitcheck_bufdbuf);
        hitcheck_bufdbuf = hit_obj_item.GetComponent<HitCheckScript>();
        HitBallBuff();
        
        Debug.Log(this.gameObject.tag);
        Debug.Log(hitcheck_bufdbuf.HitCheck(player, this.gameObject));
        Debug.Log(this.gameObject.transform.localScale);
        //Debug.Log(player);
        Debug.Log(FX_SizeUp);
    }

    private void HitBallBuff()
    {
        if (hitcheck_bufdbuf.HitCheck(player, this.gameObject))
        {
            if (this.gameObject.tag == "GradeUp" && Itemflg == false)
            {
                Unko *= Mu;
                Itemflg = true;
                player.transform.localScale = new Vector3(Unko, Unko, Unko);

                FX_SizeUp.SetActive(true);

                this.gameObject.SetActive(false);
                Invoke("FXSizeUpSetActive_False", FX_MAX_TIME);
                Invoke("TimeDownGread", 7.5f);
            }
            if (this.gameObject.tag == "GreadDown" && Itemflg2 == false)
            {
                Itemflg2 = true;
                //sdi /= 2;
                /*GravitySpd.moveVec /= 4f;
                GravitySpd.spd /= 4;*/
                //GameObject.Find("Ball").GetComponent<Rigidbody>().velocity /= 4;
                GameObject.Find("Ball").GetComponent<Rigidbody>().drag = 8;
                this.gameObject.SetActive(false);
                Invoke("TimeUpGread", 2.0f);
            }
        }
    }
    
    private void TimeDownGread()　//大きさが戻る
    {
        Unko = 0.2f;
        Vector3 Playery = transform.position;
        Playery.y -= Unko2;
        transform.position = Playery;


        Itemflg = false;
        player.transform.localScale = new Vector3(Unko, Unko, Unko);
        Destroy(gameObject);
    }

    private void TimeUpGread() //速さが戻る
    {
        /* GravitySpd.moveVec *= 2;
         GravitySpd.spd *= 2;*/
        GameObject.Find("Ball").GetComponent<Rigidbody>().drag = 0;
        Itemflg2 = false;
        Destroy(gameObject);
    }

    void FXSizeUpSetActive_False()
    {

            FX_SizeUp.SetActive(false);
    }
}
