using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGeneration : MonoBehaviour
{
    public List<GameObject> spiders;
    private int spidersInGame;

    void Start()
    {
        spidersInGame = 0;

        foreach (Transform child in transform)
        {
            spiders.Add(child.gameObject);
        }
    }

    public int GetSpiders()
    {
        return spidersInGame;
    }

    public void AddSpider()
    {
        if(spidersInGame < spiders.Count)
        {
            spiders[spidersInGame].SetActive(true);

            spidersInGame++;
        }
    }

}
