using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class CoinGetText : MonoBehaviour
{

    /* GameObject CoinGrope; 
     ParObject Coin_Collect;
     GameObject coin;
     GetCoin coin_Qua;
     */

    [SerializeField] GameObject GameClear; //ゲームクリアキャンバス
    [SerializeField] GameObject GameResult; //ゲームリザルト
    [SerializeField] GameObject PointResult;//ゲーム中に出てるポイント表示を消す。
    [SerializeField] GameObject FX_Confetti = null;
    [SerializeField] GameObject ChildObject;//コインの子オブジェクトの数を数えるために使う。
    //bool GameRestart=false;

    GameObject PlayerSphere;
    PlayerPoint playerpoint;

    ParObject ChilOb;

    public GameObject disa_coin = null; //コイン数のテキスト
    public GameObject Result_coin = null; //リザルト時に出るテキスト
    public GameObject TimerResult = null; //タイムのリザルト
    
    


    public int CoinCollect_Point = 0;

   public int ResultStart;
    // Start is called before the first frame update
    void Start()
    {
       /* CoinGrope = GameObject.Find("CoinGroup");
        Coin_Collect = CoinGrope.GetComponent<ParObject>();
        coin = GameObject.FindGameObjectWithTag("coin");
        coin_Qua = coin.GetComponent<GetCoin>();
       */


        PlayerSphere = GameObject.Find("Ball");
        playerpoint = PlayerSphere.GetComponent<PlayerPoint>();
        FX_Confetti = GameObject.Find("Confetti");
        FX_Confetti.SetActive(false);
        ResultStart = 0;
        ChildObject = GameObject.Find("CoinGroup 1");
        ChilOb = ChildObject.GetComponent<ParObject>();
    }



    // Update is called once per frame
    void Update()
    {   
        //オブジェクトからTextコンポーネントを取得
        Text disa_Text = disa_coin.GetComponent<Text>();
        //テキストの表示を入れ替える
        disa_Text.text =  CoinCollect_Point + "/" + ParObject.Unkomorimori;
        Text Ris_coin = Result_coin.GetComponent<Text>();
        Ris_coin.text = "取得したコイン" + "  " + CoinCollect_Point + " / " + ParObject.Unkomorimori;

        

        if (ParObject.Coinkazu == 0)
        {
            GameClear.SetActive(true);
            Time.timeScale = 0;
            ResultStart++;
            if (ResultStart == 60)
            {
                GameClear.SetActive(false);
                PointResult.SetActive(false);
                GameResult.SetActive(true);
            }
            FX_Confetti.SetActive(true);
        }
        //Debug.Log(CoinCollect_Point);
    }



    void Restart()
    {
        //SceneManager.LoadScene("TitleScene");
    }

}
