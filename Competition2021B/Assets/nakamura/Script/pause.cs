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

    void Start()
    {
        pauseFlg = false;
        Time.timeScale = 1;
    }

    void Update()
    {

        if (Input.GetKeyDown("joystick button 7"))
        {
            if (pauseFlg == false)
            {
                // ポーズ画面on
                canvas.SetActive(true);
                firstSelected.Select();
                Time.timeScale = 0;
                pauseFlg = true;
            }
            else
            {
                // ポーズ画面off
                EventSystem.current.SetSelectedGameObject(null);
                canvas.SetActive(false);
                Time.timeScale = 1;
                pauseFlg = false;
            }
        }

        if(pauseFlg == true)
        {

            // カーソル移動
            selectedObj = eventSystem.currentSelectedGameObject.gameObject;
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

    public void Restart()
    {
        Debug.Log("りすたーと");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackTitle()
    {
        Debug.Log("たいとる");
        SceneManager.LoadScene("TitleScene");
    }

    public void GameEnd()
    {
        Debug.Log("しゅうりょう");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif // UNITY_EDITOR
    }
}
