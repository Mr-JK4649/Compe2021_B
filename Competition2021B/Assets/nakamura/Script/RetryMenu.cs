using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        if (GameClearCanvas.activeInHierarchy == true && Input.GetKeyDown("joystick button 0"))
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
                    cursor.rectTransform.localPosition = new Vector3(-300.0f, 30.0f, 0.0f);
                    break;
            }

        }
    }
}
