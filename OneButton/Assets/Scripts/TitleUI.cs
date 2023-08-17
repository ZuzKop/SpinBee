using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public GameObject bee;
    public GameObject beeCopy;
    public Vector3 beeOrg;

    public GameObject credits;
    public GameObject creditsCopy;
    public Vector3 creditsOrg;

    private bool toggle;
    private bool guard;

    public AudioSource tap;

    void Start()
    {
        toggle = false;
        guard = false;

        beeOrg = bee.transform.position;
        creditsOrg = credits.transform.position;

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if(!guard)
            {
                toggle =! toggle;
                StartCoroutine(Credits());
                tap.Play();

            }

        }
    }

    IEnumerator Credits()
    {
        Vector3 oldP;
        Vector3 newP;

        guard = true;

        if (toggle)
        {
            beeOrg = bee.transform.position;

            oldP = bee.transform.position;
            newP = beeCopy.transform.position;
        }
        else
        {
            oldP = bee.transform.position;
            newP = beeOrg;

        }

        StartCoroutine(Cred());

        float lerpTime = 0f;

        while (lerpTime <= 1)
        {
            bee.transform.position = Vector3.Lerp(oldP, newP, lerpTime);
            lerpTime += Time.deltaTime * 1.3f;
            yield return null;
        }

        bee.transform.position = newP;


    }  
    
    IEnumerator Cred()
    {
        Vector3 newCP;
        Vector3 oldCP;

        if (toggle)
        {
            creditsOrg = credits.transform.position;

            oldCP = credits.transform.position;
            newCP = creditsCopy.transform.position;
        }
        else
        {
            oldCP = credits.transform.position;
            newCP = creditsOrg;

        }
        float lerpT = 0f;

        while (lerpT <= 1)
        {
            credits.transform.position = Vector3.Lerp(oldCP, newCP, lerpT);
            lerpT += Time.deltaTime * 1.2f;
            yield return null;
        }

        credits.transform.position = newCP;


        guard = false;

    }
}
