using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject StageSelectCanvas;
    [SerializeField] Button Stage1_Button;
    [SerializeField] Button Stage2_Button;
    [SerializeField] Button Stage3_Button;
    [SerializeField] Button Stage4_Button;
    GameObject selectedObj;

    [SerializeField] Trigger trigger;
    [SerializeField] AudioClip move;
    [SerializeField] AudioClip enter;

    private void Start()
    {
        Time.timeScale = 1;
        StageSelectCanvas.SetActive(false);
        selectedObj = Stage1_Button.gameObject;
    }
    void Update()
    {
        if(Input.anyKeyDown && StageSelectCanvas.activeInHierarchy == false)
        {
            trigger.RingSound(enter);
            StageSelectCanvas.SetActive(true);
            Stage1_Button.Select();
        }

        if (StageSelectCanvas.activeInHierarchy)
        {
            if (selectedObj != eventSystem.currentSelectedGameObject.gameObject)
            {
                trigger.RingSound(move);
                selectedObj = eventSystem.currentSelectedGameObject.gameObject;
            }
        }

    }

    public void NextMain()
    {
        Debug.Log("めいん");
        SceneManager.LoadScene("MainScene");
    }

    public void Stage1()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        Stage2_Button.interactable = false;
        Stage3_Button.interactable = false;
        Stage4_Button.interactable = false;
        Invoke("NextMain", 1f);
    }
    public void Stage2()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        Stage1_Button.interactable = false;
        Stage3_Button.interactable = false;
        Stage4_Button.interactable = false;
        Invoke("NextMain", 1f);
    }
    public void Stage3()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        Stage1_Button.interactable = false;
        Stage2_Button.interactable = false;
        Stage4_Button.interactable = false;
        Invoke("NextMain", 1f);
    }
    public void Stage4()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        Stage1_Button.interactable = false;
        Stage2_Button.interactable = false;
        Stage3_Button.interactable = false;
        Invoke("NextMain", 1f);
    }
}
