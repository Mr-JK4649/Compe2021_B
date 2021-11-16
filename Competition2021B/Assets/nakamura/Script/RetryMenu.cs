using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;   // イベントシステム
    [SerializeField] GameObject retryCanvas;
    GameObject selectedObj;
    [SerializeField] Text cursor;               // カーソル

    [SerializeField] Button firstSelected;      // 最初に選択されるボタン

    [SerializeField] GameObject GameClearCanvas;

    Trigger trigger;
    [SerializeField] AudioClip move;
    [SerializeField] AudioClip enter;

    void Start()
    {
        retryCanvas.SetActive(false);
        trigger = GameObject.Find("Ball").GetComponent<Trigger>();
    }
    void Update()
    {
        if (GameClearCanvas.activeInHierarchy == true &&
            retryCanvas.activeInHierarchy == false &&
            Input.GetKeyDown("joystick button 0"))
        {
            trigger.RingSound(enter);
            retryCanvas.SetActive(true);
            firstSelected.Select();
        }

        if (retryCanvas.activeInHierarchy == true)
        {

            // カーソル移動
            if (selectedObj != eventSystem.currentSelectedGameObject.gameObject)
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
                    break;
            }

        }
    }

    public void RetryButton()
    {
        eventSystem.sendNavigationEvents = false;
        StartCoroutine("NextScene");
    }

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
