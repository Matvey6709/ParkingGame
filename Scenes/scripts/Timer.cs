using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeStart = 60;
    public float timeStart2 = 0;
    public Text timerText;
    public Image timerImageGreen;
    public int redLine = 45;

    void Start()
    {
        timerText.text = timeStart.ToString();
        timeStart2 = timeStart;
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timeStart2 -= Time.deltaTime;
        
        timerText.text = Mathf.Round(timeStart).ToString();
        if(timeStart2 < redLine)
        {
            timerImageGreen.gameObject.SetActive(false);
        }
        else
        {
            timerImageGreen.gameObject.SetActive(true);
        }
        timeStart2 = timeStart;
    }

    public float getTime()
    {
        return Mathf.Round(timeStart2);
    }
}
