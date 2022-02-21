using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeVal = 180;

    public TMP_Text timeT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeVal > 0)
        {
            timeVal -= Time.deltaTime;
        }
        else {
            // fix to zero
            timeVal = 0;
            // we can reset the game once the time runs out.

        }

        DisplayTime(timeVal);

    }

    void DisplayTime(float timeTD) {
        if (timeTD < 0)
        {
            timeTD = 0;
        }

        float min = Mathf.FloorToInt(timeVal /60 );
        float sec = Mathf.FloorToInt(timeTD % 60);

        timeT.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
