using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public GameObject gOverScreen;
    public Text score;
    public Text s1;
    public Text s2;
    public Text s3;


    public AudioSource failure;
    private bool fail;
    private bool guard;

    private int scoreInt;


    // Start is called before the first frame update
    void Start()
    {
        fail = false;
        guard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fail && guard)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GOver();
            if(fail && guard)
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    public bool GetFail()
    {
        return fail;
    }

    public void GOver()
    {
        if(!fail)
        {
            fail = true;
            failure.Play();
            StartCoroutine(Screen());

            scoreInt = gameObject.GetComponent<Points>().GetPoints() * (int)GameObject.FindGameObjectWithTag("timer").GetComponent<timer>().GetTime();
            Debug.Log(scoreInt);
            Debug.Log(scoreInt.ToString());
            Debug.Log("your points: " + scoreInt.ToString());
            score.text = "your points: " + scoreInt.ToString();

            UpdateHighScores();
        }


        IEnumerator Screen()
        {
            Vector2 position = gOverScreen.transform.position;
            Vector2 destination = gOverScreen.transform.parent.transform.position;
            float lerpTotalTime = 1.5f;
            //yield return new WaitForSeconds(1f);
            float lerpTime = 0;

            while (lerpTime <= 1)
            {
                gOverScreen.transform.position = Vector3.Lerp(position, destination, lerpTime);
                lerpTime += Time.deltaTime * lerpTotalTime;
                yield return null;
            }

            gOverScreen.transform.position = destination;

            guard = true;

        }
    }

    private void UpdateHighScores()
    {
        int hs1, hs2, hs3;

        hs1 = PlayerPrefs.GetInt("hScore1");
        hs2 = PlayerPrefs.GetInt("hScore2");
        hs3 = PlayerPrefs.GetInt("hScore3");

        int hold, hold2;

        if (scoreInt >= hs1)
        {
            hold = hs1;
            hs1 = scoreInt;
            hold2 = hs2;
            hs2 = hold;
            hs3 = hold2;

        }
        else if (scoreInt >= hs2)
        {
            hold = hs2;
            hs2 = scoreInt;
            hs3 = hold;
        }
        else if (scoreInt >= hs3)
        {
            hs3 = scoreInt;
        }

        if (hs1 != 0)
        {
            s1.text = hs1.ToString();
            if (hs2 != 0)
            {
                s2.text = hs2.ToString();
                if (hs3 != 0)
                {
                    s3.text = hs3.ToString();
                }
                else
                {
                    s3.text = "-";

                }
            }
            else
            {
                s2.text = "-";
                s3.text = "-";
            }

        }
        else
        {
            s1.text = "-";
            s2.text = "-";
            s3.text = "-";
        }

        PlayerPrefs.SetInt("hScore1", hs1);
        PlayerPrefs.SetInt("hScore2", hs2);
        PlayerPrefs.SetInt("hScore3", hs3);


        PlayerPrefs.Save();
    }

}
