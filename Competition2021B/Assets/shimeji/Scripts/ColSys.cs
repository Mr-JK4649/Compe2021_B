using UnityEngine;


public interface ICollider
{
    /// <summary>
    /// 球との当たり判定
    /// </summary>
    bool CheckSphere(ISphere collider);
}

public interface ISphere
{
    /// <summary>
    /// 中心のローカル座標
    /// </summary>
    Vector3 Center { get; }
    /// <summary>
    /// 半径
    /// </summary>
    float Radius { get; }
    /// <summary>
    /// 中心のワールド座標
    /// </summary>
    Vector3 WorldCenter { get; }
}