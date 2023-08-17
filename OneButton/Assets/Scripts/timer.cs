using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private float time;
    private int mins;
    private int secs;
    public Text text;


    // Update is called once per frame
    void Update()
    {
        if(!GameObject.FindGameObjectWithTag("player").GetComponent<PlayerState>().GetFail())
        {
            time = time + Time.deltaTime;

            mins = (int)time / 60;
            secs = (int)time % 60;

            if (secs < 10)
            {
                text.text = mins.ToString() + ':' + '0' + secs.ToString();
            }
            else text.text = mins.ToString() + ':' + secs.ToString();

        }

    }

    public float GetTime()
    {
        return time;
    }
}
