using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWall : MonoBehaviour
{
    
    //衝撃波
    [SerializeField] GameObject fx_hitWall = null;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            GameObject obj;
            obj = Instantiate(fx_hitWall, this.transform.position, Quaternion.identity);
        }
    }
}
