using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderKill : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D o)
    {
        if(o.tag == "player")
        {
            o.GetComponent<PlayerState>().GOver();
        }
    }
}
