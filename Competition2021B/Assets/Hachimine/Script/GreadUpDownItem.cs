using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreadUpDownItem : MonoBehaviour
{

    [SerializeField] GameObject TextDeployment;
    //[SerializeField] GameObject GreadUpItem;
    [SerializeField] GameObject PlayerBall;

    [SerializeField] public float Mu; //球の大きさの倍数

    bool Itemflg;
    float Unko = 0.2f;
    float Unko2 = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
        Itemflg = false; //アイテムを使って450フレームまでTrue
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GradeUp" && Itemflg == false)
        {
            Unko *= Mu;
            Itemflg = true;
            PlayerBall.transform.localScale = new Vector3(Unko, Unko, Unko);
            Invoke("TimeDownGread", 7.5f);
           
        }
    }
    private void TimeDownGread()
    {
        Unko = 0.2f;
        Vector3 Playery = transform.position;
        Playery.y -= Unko2;
        transform.position = Playery;


        Itemflg = false;
        PlayerBall.transform.localScale = new Vector3(Unko, Unko, Unko);
        TextDeployment.SetActive(true);
    }
}
