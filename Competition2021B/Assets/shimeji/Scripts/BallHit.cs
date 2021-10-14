using UnityEngine;

public class BallHit : MonoBehaviour, ICollider
{
    [SerializeField]
    private Vector3 _center = Vector3.zero;
    public Vector3 Center { get { return _center; } }
    [SerializeField]
    private Vector3 _size = Vector3.one;
    public Vector2 Size { get { return _size; } }

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    /// <summary>
    /// 球との当たり判定
    /// </summary>
    public bool CheckSphere(ISphere collider)
    {
        var cubeToLocal = Matrix4x4.TRS(_center, Quaternion.identity, Vector3.one);
        var worldToCube = cubeToLocal.inverse * transform.worldToLocalMatrix;

        // Cubeの空間における球の中心点
        var sphereCenter = worldToCube.MultiplyPoint(collider.WorldCenter);
        
        // 距離の二乗を求める
        var sqLength = 0.0f;
        for (int i = 0; i < 3; i++)
        {
            var point = sphereCenter[i];
            var boxMin = _size[i] * -0.5f;
            var boxMax = _size[i] * 0.5f;
            if (point < boxMin)
            {
                sqLength += (point - boxMin) * (point - boxMin);
            }
            if (point > boxMax)
            {
                sqLength += (point - boxMax) * (point - boxMax);
            }
        }

        // 距離の二乗が0だったらCubeの内部にSphereの中心があるということ
        if (sqLength == 0.0f)
        {
            this.gameObject.SetActive(false);
            return true;
        }

        return sqLength <= collider.Radius * collider.Radius;
    }
}
