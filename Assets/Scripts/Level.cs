using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level inst;

    [Header("UI Feedback")] 
    public Text timeFeedback;
    public Text coinFeedback;

    private int coinCounter;
    void Start()
    {
        inst = this;
        StartCoroutine(TimeTick());
        coinFeedback.text = coinCounter.ToString();
    }
    
    void Update()
    {
        
    }

    public void UpdateCoinCounter(int value)
    {
        coinCounter += value;
        coinFeedback.text = coinCounter.ToString();
    }

    IEnumerator TimeTick(int sec = 0, int min = 0)
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSeconds(1);
            if (sec == 59)
            {
                sec = 0;
                min++;
            }
            else
            {
                sec++;
            }

            if (sec < 10)
            {
                timeFeedback.text = min + ":0" + sec;
            }
            else
            {
                timeFeedback.text = min + ":" + sec;
            }
        }
        StopCoroutine(TimeTick());
    }
}
