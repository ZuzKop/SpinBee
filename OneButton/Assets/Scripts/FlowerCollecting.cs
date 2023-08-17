using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlowerCollecting : MonoBehaviour
{
    private int cols;
    private int rows;
    private float tile;

    private Vector3 newLocation;

    private int randR;
    private int randC;

    private int prewC;
    private int prewR;

    public GameObject spiders;

    public AudioSource collectSound;


    //from script arrowspin connect to variable y offset = -2

    // Start is called before the first frame update
    void Start()
    {
        cols = GameObject.FindGameObjectWithTag("grid").GetComponent<GridManager>().GetColumns();
        rows = GameObject.FindGameObjectWithTag("grid").GetComponent<GridManager>().GetRows();
        tile = GameObject.FindGameObjectWithTag("grid").GetComponent<GridManager>().GetTileSize();

        prewC = (int)(rows / 2) + 1;
        prewC = (int)(rows / 2) + 1;

        GenerateFlowerLocation();
    }


    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.tag == "player")
        {
            Debug.Log("Flower!");
            collectSound.Play();
            GameObject.FindGameObjectWithTag("player").GetComponent<Points>().AddPoints(1);
            GenerateFlowerLocation();

            if(GameObject.FindGameObjectWithTag("player").GetComponent<Points>().GetPoints() == 2)
            {
                spiders.SetActive(true);
            }

        }
    }

    void GenerateFlowerLocation()
    {        
        System.Random rnd = new System.Random();
        randR = rnd.Next(0, rows);
        randC = rnd.Next(0, cols);

        while(randR == prewR && randC == prewC)
        {
            randR = rnd.Next(0, rows);
            randC = rnd.Next(0, cols);

        }

        prewR = randR;
        prewC = randC;

        randC -= (int)(cols / 2);
        randR -= (int)(rows / 2) - 2; //+2 is y offset from ArrowSpin.cs

        newLocation = new Vector2((randC*tile), (randR*tile) - 0.25f);

        transform.position = newLocation;


    }
}
