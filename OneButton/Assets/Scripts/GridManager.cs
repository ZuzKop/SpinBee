using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 9;
    private int cols = 9;
    private float tileSize = 1.15f;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    public int GetRows()
    {
        return rows;
    }
    public int GetColumns()
    {
        return cols;

    }
    public float GetTileSize()
    {
        return tileSize;
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("grid"));

        for(int row = 0; row < rows ; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                GameObject tile  = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }

        Destroy(referenceTile);

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;

        transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);

    }

}
