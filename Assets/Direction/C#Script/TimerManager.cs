using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private int minute;
    [SerializeField] private float seconds;

    private float oldseconds;
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldseconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

        if((int)seconds != (int)oldseconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldseconds = seconds;
    }
}
