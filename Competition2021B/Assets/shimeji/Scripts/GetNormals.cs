using UnityEngine;

//キューブの法線ベクトルを求めるスクリプト
public class GetNormals : MonoBehaviour
{
    private Vector3 cPos;
    private Vector3 aPos;
    private Vector3 bPos;

    private Vector3 normalVec;

    public bool ray = true;
    
    private void Start()
    {

        cPos = this.transform.localPosition;
        aPos = this.transform.GetChild(0).position;
        bPos = this.transform.GetChild(1).position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cPos = this.transform.position;
        aPos = this.transform.GetChild(0).position;
        bPos = this.transform.GetChild(1).position;
        normalVec = CalcNormalVector();
        normalVec.Normalize();

        //フラグがオンならレイで法線を表示
        if(ray) Debug.DrawRay(cPos, normalVec);
        Debug.Log("床の法線" + normalVec);
        
    }

    public Vector3 GetNormal() {
        return normalVec;
    }

    //法線ベクトルを求める関数
    private Vector3 CalcNormalVector() {

        //法線ベクトル
        Vector3 normalVec;

        //ベクトルA to B
        Vector3 ctoa = SubVec3(cPos, aPos);

        //ベクトルA to C
        Vector3 ctob = SubVec3(cPos, bPos);

        //外積(法線ベクトル)を求める
        normalVec = Vector3.Cross(ctoa, ctob);
        

        return normalVec;
    }

    //Vector3同士の引き算関数
    private Vector3 SubVec3(Vector3 a, Vector3 b) {

        Vector3 re;

        re = new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

        return re;
    }

}
