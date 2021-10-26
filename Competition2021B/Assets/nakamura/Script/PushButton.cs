using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour
{

    void Update()
    {
        
    }

    public void NextMain()
    {
        Debug.Log("めいん");
        SceneManager.LoadScene("MainScene");
    }
}
