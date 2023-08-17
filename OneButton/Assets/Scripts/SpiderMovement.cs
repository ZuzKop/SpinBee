using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private Vector3 destination;
    private Vector3 position;
    private Vector3 newPos;

    private GameObject spider;
    private float lerpDuration = 0.3f;

    private int cols;
    private int rows;
    private float tile;

    private bool flag;
    private bool xSpider; //Y axis locked, moves by axis X

    public float turnSpeed = 1f;


     // Start is called before the first frame update
    void OnEnable()
    {
        cols = GameObject.FindGameObjectWithTag("grid").GetComponent<GridManager>().GetColumns();
        rows = GameObject.FindGameObjectWithTag("grid").GetComponent<GridManager>().GetRows();
        tile = GameObject.FindGameObjectWithTag("grid").GetComponent<GridManager>().GetTileSize();

        spider = gameObject.transform.parent.gameObject;
        flag = false;

        if(gameObject.transform.parent.gameObject.transform.parent.GetComponent<SpiderGeneration>().GetSpiders()%2 == 0)
        {
            xSpider = true;
        }
        else
        {
            xSpider = false;
        }

        GenerateFirstPosition();
        StartCoroutine(Move());

    }

    private void GenerateSpiders()
    {
        flag = !flag;
        transform.position = spider.transform.position;
        StartCoroutine(SpiderRotate());

    }

    IEnumerator SpiderRotate()
    {
        /*
        Vector3 current = spider.transform.forward;
        Vector3 to = transform.position - spider.transform.position;

        Debug.Log(current + "  " + to);
        spider.transform.forward = Vector3.RotateTowards(current, to, turnSpeed * Time.deltaTime, 0.0f);
        yield return null;
        */
        yield return new WaitForSeconds(0.5f);
        float angle;
        if (flag) angle = 180; else angle = -180;

        Vector3 oldR = spider.transform.eulerAngles;
        Vector3 newR = spider.transform.eulerAngles + new Vector3(0f, 0f, angle);
        float lerpSpeed = 1f;

        float lerpTime = 0;
        while (lerpTime <= 1)
        {
            spider.transform.eulerAngles = Vector3.Lerp(oldR, newR, lerpTime);
            lerpTime += Time.deltaTime * lerpSpeed;
            yield return null;
        }

        spider.transform.eulerAngles = newR;

        GenerateNextPosition();
        StartCoroutine(Move());


    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1f);
        position = spider.transform.position;
        destination = transform.position;
        float lerpTime = 0;

        while(lerpTime <=1)
        {
            spider.transform.position = Vector3.Lerp(position, destination, lerpTime);
            lerpTime += Time.deltaTime * lerpDuration;
            yield return null;
        }

        spider.transform.position = destination;
        yield return new WaitForSeconds(1f);
        GenerateSpiders();
    }

    private void GenerateFirstPosition()
    {
        float xO = 0;
        float yO = 0;

        float xD = 0;
        float yD = 0;

        int randCol, randRow;

        switch(xSpider)
        {
            case false:
                yO = ((int)(rows / 2) +1 + 2 - 0.3f) * tile;
                randCol = Random.Range(-1, cols);
                xO = (randCol - (int)(cols / 2)) * tile;

                yD = (-(int)(rows / 2) - 1 + 2 - 0.3f) * tile;
                randCol = Random.Range(-cols +2, 1);
                xD = -(randCol + (int)(cols / 2) - 1) * tile;

                break;

            case true:
                xO = (-(int)(cols / 2) - 1) * tile;
                randRow = Random.Range(1, rows + 1);
                yO = (randRow - (int)(rows / 2)) * tile;

                xD = ((int)(cols / 2) + 1) * tile;
                randRow = Random.Range(-1, rows-2);
                yD = (randRow - (int)(rows / 2) + 1 + 2 - 0.3f) * tile;

                break;
        }

        spider.transform.position = new Vector2(xO, yO);
        transform.position = new Vector2(xD, yD);
    }

    private void GenerateNextPosition()
    {

        float xD = 0;
        float yD = 0;

        int randCol, randRow;

        switch (xSpider)
        {
            case false://lewa i prawa
                if (!flag)//z prawej na lewo
                {
                    yD = (-(int)(rows / 2) - 1 + 2 - 0.3f) * tile;
                    randCol = Random.Range(-cols + 2, 1);
                    xD = -(randCol + (int)(cols / 2) - 1) * tile;
                }
                else
                {
                    yD = ((int)(rows / 2) + 1 + 2 - 0.3f) * tile;
                    randCol = Random.Range(-1, cols);
                    xD = (randCol - (int)(cols / 2)) * tile;
                }

                break;

            case true://gora i dol
                if (flag)//z dolu na gore
                {
                    xD = (-(int)(cols / 2) - 1) * tile;
                    randRow = Random.Range(1, rows + 1);
                    yD = (randRow - (int)(rows / 2)) * tile;
                }
                else//z gory na dol
                {
                    xD = ((int)(cols / 2) + 1) * tile;
                    randRow = Random.Range(-1, rows - 2);
                    yD = (randRow - (int)(rows / 2) + 1 + 2 - 0.3f) * tile;
                }

                break;
        }

        transform.position = new Vector2(xD, yD);
    }
}
