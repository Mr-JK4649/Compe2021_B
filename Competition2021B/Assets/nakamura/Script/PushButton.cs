using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour
{

    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public void NextMain()
    {
        Debug.Log("めいん");
        SceneManager.LoadScene("MainScene");
    }
}
