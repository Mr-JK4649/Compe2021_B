using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheckScript : MonoBehaviour
{
    public bool HitCheck(GameObject p, GameObject item)
    {
        Vector3 item_pos = item.transform.position;//座標保存

        Vector3 p_pos = p.transform.position;//プレイヤー座標
       // Debug.Log(item);
        Vector3 Def = p_pos - item_pos;

        float d = Def.magnitude;

        float p_radius = p.transform.localScale.x / 2;
        float item_radius = item.transform.localScale.x / 2;

        bool hit_flg = false;
        if (d <= p_radius + item_radius)
        {
            hit_flg = true;
            //Debug.Log(p.transform.tag);
        }
        else
        {
            hit_flg = false;
        }

        return hit_flg;
    }

}