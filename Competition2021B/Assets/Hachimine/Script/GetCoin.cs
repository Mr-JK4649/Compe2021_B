using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetCoin : MonoBehaviour
{
    GameObject CoinText;
    CoinGetText GetPointText;
    public GameObject getCoinFX;


    //int CoinObject = 0;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        CoinText = GameObject.Find("CoinText");
        GetPointText = CoinText.GetComponent<CoinGetText>();  
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hello World");

            Instantiate(getCoinFX, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
