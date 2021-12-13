using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewUpDownScript : MonoBehaviour
{
    const float FX_MAX_TIME = 0.3f;    // エフェクト再生時間

    [SerializeField] GameObject player;
    [SerializeField] GameObject hit_obj_item;

    [SerializeField] MeshRenderer ItemMesh;

    [SerializeField] AudioClip kinoko_se;

    [SerializeField]
    AudioSource audiosource_kinoko; 


    [SerializeField] public float Mu;//球の大きさの倍数

    private GameObject FX_SizeUp = null;

    //GameObject PlayerBall;

    GameObject PlayerSphereSpd;
    BallGravity GravitySpd;

    bool Itemflgunko;//バフ
    bool Itemflgunko2;//デバフ
    float Unko = 0.2f;
    float Unko2 = 0.2f;
    float Speed = 0;
    int buffTime = 0; //バフ時間
    int dbuffTIme = 0;//デバフ時間

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

        Itemflgunko = false;//バフ
        Itemflgunko2 = false;//デバフ

        ItemMesh = GetComponent<MeshRenderer>();

       

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Debug.Log(hitcheck_bufdbuf);
        hitcheck_bufdbuf = hit_obj_item.GetComponent<HitCheckScript>();
        HitBallBuff();
        //Big();
        //Debug.Log(this.gameObject.tag);
        //Debug.Log(hitcheck_bufdbuf.HitCheck(player, this.gameObject));
        //Debug.Log(this.gameObject.transform.localScale);
        //Debug.Log(player);
        //Debug.Log(FX_SizeUp);
        Debug.Log(buffTime);
        Debug.Log(dbuffTIme);
        Debug.Log(Itemflgunko);
    }

    private void HitBallBuff()
    {
        if (hitcheck_bufdbuf.HitCheck(player, this.gameObject) && ItemMesh.enabled == true)
        {
            
            if (this.gameObject.tag == "GradeUp" && Itemflgunko == false)
            {

                Unko *= Mu;
                Itemflgunko = true;
                player.transform.localScale = new Vector3(Unko, Unko, Unko);

                FX_SizeUp.SetActive(true);

                ItemMesh.enabled = false;

                audiosource_kinoko.PlayOneShot(kinoko_se);

                Invoke("FXSizeUpSetActive_False", FX_MAX_TIME);


            }else if (this.gameObject.tag == "GradeUp" && Itemflgunko == true)
            {
                buffTime = 0;
            }
            if (this.gameObject.tag == "GreadDown" && Itemflgunko2 == false)
            {
                Itemflgunko2 = true;
                GameObject.Find("Ball").GetComponent<Rigidbody>().drag = 8;
                audiosource_kinoko.PlayOneShot(kinoko_se);
                ItemMesh.enabled = false;

            } else if (this.gameObject.tag == "GreadDown" && Itemflgunko2 == true)
            {
                dbuffTIme = 0;
            }
        }
        if (Itemflgunko == true )
        {
            buffTime++;
        }
        if (Itemflgunko2 == true)
        {
            dbuffTIme++;
        }
        if (buffTime > 450)
        {
            TimeDownGread();
        }
        if (dbuffTIme > 90)
        {
            TimeUpGread();
        }

    }

    void TimeDownGread() //大きさが戻る
    {
        Unko = 0.2f;
        Vector3 Playery = player.transform.position;

        Itemflgunko = false;
        player.transform.localScale = new Vector3(Unko, Unko, Unko);

        //Playery.y -= Unko2;
        //player.transform.position = Playery;
        buffTime = 0;
        Destroy(gameObject);
    }

    void TimeUpGread() //速さが戻る
    {
        /* GravitySpd.moveVec *= 2;
         GravitySpd.spd *= 2;*/
        GameObject.Find("Ball").GetComponent<Rigidbody>().drag = 2;
        Itemflgunko2 = false;
        dbuffTIme = 0;
        Destroy(gameObject);
    }

    void FXSizeUpSetActive_False()
    {

        FX_SizeUp.SetActive(false);
    }
}

