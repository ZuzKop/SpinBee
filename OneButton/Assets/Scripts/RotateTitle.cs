using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTitle : MonoBehaviour
{
    private bool clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.rotation.eulerAngles.z >= 230)
        {
            clock = true;
        }
        if(transform.rotation.eulerAngles.z <= 180)
        {
            clock = false;
        }

        if(clock)
        {
            transform.Rotate(new Vector3(0f, 0f, -1f), 30 * Time.deltaTime);

        }
        else 
        {
            transform.Rotate(new Vector3(0f, 0f, 1f), 30 * Time.deltaTime);

        }

    }
}
