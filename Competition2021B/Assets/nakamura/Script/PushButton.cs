using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject titleCanvas;
    [SerializeField] GameObject StageSelectCanvas;
    [SerializeField] Button Stage1_Button;
    [SerializeField] Button Stage2_Button;
    [SerializeField] Button Stage3_Button;
    [SerializeField] Button Stage4_Button;
    [SerializeField] Button Stage5_Button;
    GameObject selectedObj;

    [SerializeField] Trigger trigger;
    [SerializeField] AudioClip move;
    [SerializeField] AudioClip enter;
    string stageName;

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
            titleCanvas.SetActive(false);
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
        SceneManager.LoadScene(stageName);
    }

    public void Stage1()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        GoStage(1,"MainScene");
    }
    public void Stage2()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        GoStage(2,"Stage2");
    }
    public void Stage3()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        GoStage(3,"Stage3");
    }
    public void Stage4()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        GoStage(4,"Stage4");
    }

    public void Stage5()
    {
        trigger.RingSound(enter);
        eventSystem.sendNavigationEvents = false;
        GoStage(5,"NightStage");
    }

    void GoStage(int num,string name) { 
        
        if(num != 1) Stage1_Button.interactable = false;
        if(num != 2) Stage2_Button.interactable = false;
        if(num != 3) Stage3_Button.interactable = false;
        if(num != 4) Stage4_Button.interactable = false;
        if(num != 5) Stage5_Button.interactable = false;

        stageName = name;
        Invoke("NextMain", 1f);
    }
}
