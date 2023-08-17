using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mute : MonoBehaviour
{
    public GameObject glosnikOn;
    public GameObject glosnikOff;
    public GameObject dzwieki;

    public GameObject jingle;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("mute") == 1)
        {
            glosnikOn.SetActive(false);
            glosnikOff.SetActive(true);
            dzwieki.SetActive(false);
            
            if (Application.loadedLevel == 1)
            {
                jingle.SetActive(false);
            }
        }
        else
        {
            glosnikOn.SetActive(true);
            glosnikOff.SetActive(false);
            dzwieki.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Muted.");
            if(PlayerPrefs.GetInt("mute") == 1)
            {
                PlayerPrefs.SetInt("mute", 0);
                glosnikOn.SetActive(true);
                glosnikOff.SetActive(false);
                dzwieki.SetActive(true);

            }
            else
            {
                PlayerPrefs.SetInt("mute", 1);
                glosnikOn.SetActive(false);
                glosnikOff.SetActive(true);
                dzwieki.SetActive(false);

                if(Application.loadedLevel == 1)
                {
                     jingle.SetActive(false);
                }

            }

        }
    }
}
