using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDown : MonoBehaviour
{
    [SerializeField] GameObject countDownObj;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Text text;

    void Start()
    {
        Time.timeScale = 0;
        text.text = "3";
        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);

        StartCoroutine("CountDown");
    }

    private IEnumerator CountDown()
    {
        text.text = "3";

        yield return new WaitForSecondsRealtime(1.0f);

        text.text = "2";

        yield return new WaitForSecondsRealtime(1.0f);

        text.text = "1";

        yield return new WaitForSecondsRealtime(1.0f);

        text.text = "  スタート！";

        yield return new WaitForSecondsRealtime(0.5f);
        countDownObj.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 1;

        //コルーチンを終了
        yield break;
    }
}
