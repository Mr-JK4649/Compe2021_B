using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOutLine : MonoBehaviour
{

    private void Start()
    {
        transform.parent.gameObject.GetComponent<Outline>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {

            transform.parent.gameObject.GetComponent<Outline>().enabled = true;
            
        }
    }
}
