using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Tip1;
    public GameObject Tip2;
    private int steps = 0;
    


    // Update is called once per frame
    void Update()
    {
        if (steps <= 3)
        {
            if (Input.GetKeyDown("space"))
            {
                steps++;

                if (steps >= 3)
                {
                    Tip1.SetActive(false);
                    //Tip2.SetActive(true);
                }
            }

        }
        /*
        if(GameObject.FindGameObjectWithTag("player").GetComponent<Points>().GetPoints() >= 2)
        {
            Tip2.SetActive(false);
        }
        */

    }
}
