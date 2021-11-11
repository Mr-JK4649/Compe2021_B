using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [SerializeField] private int minute;
    [SerializeField] private float seconds;

    public GameObject minute_tx = null;
   // public GameObject seconds_tx = null;

    private Text Time_Text;
  
    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Text minute_text = minute_tx.GetComponent<Text>();
        //Text seconds_text = seconds_tx.GetComponent<Text>();

        minute_text.text = minute.ToString("00") + ":"+((int)seconds).ToString("00");
    }

    void FixedUpdate()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

    }
}
