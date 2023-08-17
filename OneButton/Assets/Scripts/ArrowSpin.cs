using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpin : MonoBehaviour
{
    private GameObject arrow;
    private GameObject player;
    private float speed;
    private float maxSpeed = 6.5f;
    private float acc;

    private bool stop;

    public GameObject grid;
    private float tileSize;
    private int rows;
    private int cols;

    public AudioSource slap;


    public int offsetY;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        acc = 0.04f;
        arrow = GameObject.FindGameObjectWithTag("arrow");
        player = GameObject.FindGameObjectWithTag("player");

        tileSize = grid.GetComponent<GridManager>().GetTileSize();
        cols = grid.GetComponent<GridManager>().GetColumns();
        rows = grid.GetComponent<GridManager>().GetRows();

        offsetY = -2;

    }

    void FixedUpdate()
    {
        Debug.Log(speed);
        if (!player.GetComponent<PlayerState>().GetFail())
        {
            if (speed < maxSpeed)
            {
                speed += Time.deltaTime * acc;
            }
        }

        if (!Input.GetKey("space"))
        {
            arrow.transform.Rotate(0f, 0f, -speed, Space.Self);

            if (arrow.transform.rotation.eulerAngles.z < 45 || arrow.transform.rotation.eulerAngles.z >= 315)
            {
                player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            else if (arrow.transform.rotation.eulerAngles.z < 315 && arrow.transform.rotation.eulerAngles.z >= 225)
            {
                player.transform.eulerAngles = new Vector3(0f, 0f, 270f);
            }
            else if (arrow.transform.rotation.eulerAngles.z < 225 && arrow.transform.rotation.eulerAngles.z >= 135)
            {
                player.transform.eulerAngles = new Vector3(0f, 0f, 180f);
            }
            else if (arrow.transform.rotation.eulerAngles.z < 135 && arrow.transform.rotation.eulerAngles.z >= 45)
            {
                player.transform.eulerAngles = new Vector3(0f, 0f, 90f);
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<PlayerState>().GetFail())
        {

            if (Input.GetKeyDown("space"))
            {
                slap.Play();

                if(arrow.transform.rotation.eulerAngles.z < 45 || arrow.transform.rotation.eulerAngles.z >= 315 )
                {
                    //Debug.Log("Up.");
                    if(player.transform.position.y < tileSize * (int)(rows/2) - offsetY)
                    {
                       player.transform.position += new Vector3(0f, tileSize, 0f);
                    }
                }
                else if(arrow.transform.rotation.eulerAngles.z < 315 && arrow.transform.rotation.eulerAngles.z >= 225)
                {
                    //Debug.Log("Right.");
                    if (player.transform.position.x < (tileSize * (int)(cols / 2)))
                    {
                        player.transform.position += new Vector3(tileSize, 0f, 0f);

                    }
                }
                else if(arrow.transform.rotation.eulerAngles.z < 225  && arrow.transform.rotation.eulerAngles.z >= 135)
                {
                    //Debug.Log("Down.");
                    if(player.transform.position.y > - (tileSize * (int)(rows / 2)) - offsetY)
                    {
                      player.transform.position += new Vector3(0f, -tileSize, 0f);

                    }
                }
                else if(arrow.transform.rotation.eulerAngles.z < 135 && arrow.transform.rotation.eulerAngles.z >= 45)
                {
                    //Debug.Log("Left.");
                    if (player.transform.position.x > -(tileSize * (int)(cols / 2)))
                    {
                        player.transform.position += new Vector3(-tileSize, 0f, 0f);

                    }
                }

            
            }

        }


    }
}
