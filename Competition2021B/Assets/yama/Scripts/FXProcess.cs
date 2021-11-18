using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FXProcess : MonoBehaviour
{
    enum ET
    {
        BALL_MOVE = 0,
        BALL_HIT_WALL,
        GET_COIN,
        GAME_CLEAR,
        MAX,
    }

    //public GameObject getCoinFX;
    //public GameObject fx_hitWall;
    //public GameObject[] FX = new GameObject[(int)ET.MAX];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //    if (getCoinFX.isStopped) //パーティクルが終了したか判別
    //    {
    //        Destroy(this.gameObject);//パーティクル用ゲームオブジェクトを削除
    //    }
    }

    /// <summary>
    /// オブジェクトが別オブジェクトに衝突した座標を返します
    /// </summary>
    /// <param name="collision"></param>
    public void ReturnHitPos(Collision collision, string tag)
    {
        Vector3 hitPos;
        foreach (ContactPoint point in collision.contacts)
            //if (collision.gameObject.tag == "Wall")
            if (collision.gameObject.tag == tag)
                hitPos = point.point;
    }

    /// <summary>
    /// エフェクトを再生
    /// </summary>
    public void name()
    {

    }
}
/*

    Vector3 hitPos = ReturnHitPos(collision, "Wall");



/// <summary>
/// オブジェクトが別オブジェクトに衝突した座標を返します
/// </summary>
public Vector3 ReturnHitPos(Collision collision, string tag)
{
    Vector3 hitPos = Vector3.zero;
    foreach (ContactPoint point in collision.contacts)
        //if (collision.gameObject.tag == "Wall")
        if (collision.gameObject.tag == tag)
            hitPos = point.point;
    Debug.Log(tag);

    return hitPos;
}
*/
