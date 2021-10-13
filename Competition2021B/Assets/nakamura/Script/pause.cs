using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject canvas;
    GameObject selectedObj;
    Button button;

    bool pauseFlg = false;

    [SerializeField] Button firstSelected;

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
            // マウスクリックしたときにフォーカスが離れないようにする処理
            if (Input.GetMouseButton(0))
            {
                button.Select();
            }
            else
            {
                selectedObj = eventSystem.currentSelectedGameObject.gameObject;
                button = selectedObj.GetComponent<Button>();
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
    }

    public void GameEnd()
    {
        Debug.Log("しゅうりょう");
        UnityEditor.EditorApplication.isPlaying = false;
        UnityEngine.Application.Quit();
    }
}
