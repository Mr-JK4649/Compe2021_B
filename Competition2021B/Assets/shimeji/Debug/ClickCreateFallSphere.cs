using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCreateFallSphere : MonoBehaviour
{
    public GameObject fallSphere;
    public Vector3 position;

    private void FixedUpdate()
    {
        //マウスのヒダリクリック
        if (Input.GetMouseButtonDown(0)) {
            GameObject instance = Instantiate(fallSphere);
        }
    }
}
