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
    //bool GameRestart=false;

    GameObject PlayerSphere;
    PlayerPoint playerpoint;

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
        ResultStart = 0;
    }



    // Update is called once per frame
    void Update()
    {   
        //オブジェクトからTextコンポーネントを取得
        Text disa_Text = disa_coin.GetComponent<Text>();
        //テキストの表示を入れ替える
        disa_Text.text =  CoinCollect_Point + "/ 12";
        Text Ris_coin = Result_coin.GetComponent<Text>();
        Ris_coin.text = "取得したコイン" + "  " + CoinCollect_Point + " / 12";

        

        if (CoinCollect_Point == 12)
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
        }
        //Debug.Log(CoinCollect_Point);
    }



    void Restart()
    {
        //SceneManager.LoadScene("TitleScene");
    }

}
