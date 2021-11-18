using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;   // イベントシステム
    [SerializeField] GameObject canvas;         // キャンバス
    GameObject selectedObj;                     // 現在の選択されているオブジェクト

    bool pauseFlg = false;

    [SerializeField] Text cursor;               // カーソル
    [SerializeField] Button firstSelected;      // 最初に選択されるボタン

    [SerializeField] GameObject clear;

    Trigger trigger;
    [SerializeField] AudioClip move;
    [SerializeField] AudioClip enter;

    void Start()
    {
        pauseFlg = false;
        //Time.timeScale = 1;
        trigger = GameObject.Find("Ball").GetComponent<Trigger>();
    }

    void Update()
    {
        if ((Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.T)) && clear.activeInHierarchy == false)
        {
            if (pauseFlg == false && Time.timeScale == 1)
            {
                // ポーズ画面on
                trigger.RingSound(enter);
                canvas.SetActive(true);
                firstSelected.Select();
                Time.timeScale = 0;
                pauseFlg = true;
            }
            else if(pauseFlg == true && Time.timeScale == 0)
            {
                // ポーズ画面off
                trigger.RingSound(enter);
                EventSystem.current.SetSelectedGameObject(null);
                canvas.SetActive(false);
                Time.timeScale = 1;
                pauseFlg = false;
            }
        }

        if(pauseFlg == true)
        {

            // カーソル移動
            if(selectedObj != eventSystem.currentSelectedGameObject.gameObject)
            {
                trigger.RingSound(move);
                selectedObj = eventSystem.currentSelectedGameObject.gameObject;
            }
            switch (selectedObj.name)
            {
                case "RestartButton":
                    cursor.rectTransform.localPosition = new Vector3(-300.0f, 30.0f, 0.0f);
                    break;

                case "BackTitleButton":
                    cursor.rectTransform.localPosition = new Vector3(-300.0f, -40.0f, 0.0f);
                    break;

                case "GameEndButton":
                    cursor.rectTransform.localPosition = new Vector3(-300.0f, -110.0f, 0.0f);
                    break;

                case null:
                    cursor.rectTransform.localPosition = new Vector3(-300.0f, 30.0f, 0.0f);
                    break;
            }

        }
    }

    // ポーズのフラグを取得
    public bool IsPause()
    {
        return pauseFlg;
    }

    public void PauseButton()
    {
        eventSystem.sendNavigationEvents = false;
        StartCoroutine("NextScene");
    }

//    public void Restart()
//    {
//        Debug.Log("りすたーと");
//        StartCoroutine("NextScene");
//        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//    }

//    public void BackTitle()
//    {
//        Debug.Log("たいとる");
//        StartCoroutine("NextScene");

//        //SceneManager.LoadScene("TitleScene");
//    }

//    public void GameEnd()
//    {
//        Debug.Log("しゅうりょう");
//        StartCoroutine("NextScene");
////#if UNITY_EDITOR
////        UnityEditor.EditorApplication.isPlaying = false;
////#else
////        UnityEngine.Application.Quit();
////#endif // UNITY_EDITOR
//    }

    private IEnumerator NextScene()
    {
        // 音を鳴らすためのコルーチン
        trigger.RingSound(enter);

        yield return new WaitForSecondsRealtime(0.5f);

        switch (selectedObj.name)
        {
            case "RestartButton":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "BackTitleButton":
                SceneManager.LoadScene("TitleScene");
                break;

            case "GameEndButton":
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif // UNITY_EDITOR
                break;

            case null:
                break;
        }

        //コルーチンを終了
        yield break;
    }
}
