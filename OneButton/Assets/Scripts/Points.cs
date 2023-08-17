using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    private int points;
    public Text PointsUI;

    public GameObject spiders;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;   
    }

    public void AddPoints(int p)
    {
        points += p;
        PointsUI.text = points.ToString();

        if(points == 2 || points == 6 || points == 12 || points == 18)
        {
            spiders.GetComponent<SpiderGeneration>().AddSpider();
        }
        
    }

    public int GetPoints()
    {
        return points;
    }
}
