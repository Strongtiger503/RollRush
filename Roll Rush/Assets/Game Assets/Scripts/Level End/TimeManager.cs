using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{

    #region Variables

    public static float time = 0;
    float TimeInMinutes;
    float TimeInseconds;
    float WinLevel = 0;


    [SerializeField]
    TextMeshProUGUI timetext;

    [SerializeField]
    TextMeshProUGUI wintimetext;



    LevelEndManager lm;

    [SerializeField]
    GameObject Star1;

    [SerializeField]
    GameObject Star2;

    [SerializeField]
    GameObject Star3;

    #endregion


    #region Main


    // Start is called before the first frame update
    void Start()
    {

        lm = FindObjectOfType<LevelEndManager>();

    }

    // Update is called once per frame
    void Update()
    {

        TimeInseconds = ((time % 60));
        TimeInMinutes = ((time / 60) - (TimeInseconds / 60));

        if (TimeInseconds < 9.5)
        {

            timetext.text = TimeInMinutes.ToString("F0") + " : 0" + TimeInseconds.ToString("F0");

        }
        else
        {

            timetext.text = TimeInMinutes.ToString("F0") + " : " + TimeInseconds.ToString("F0");

        }



        if (!lm.Win)
        {

            time += Time.deltaTime;

        }
        else
        {

            wintimetext.text = timetext.text.Replace(" : ", ":");

            if (time <= 61) 
            {

                WinLevel = 3;
                StartCoroutine(StarSequence());

            }
            else if (time <= 91)
            {

                WinLevel = 2;
                StartCoroutine(StarSequence());

            }
            else if (time >= 91 || time <= 121)
            {

                WinLevel = 1;
                StartCoroutine(StarSequence());

            }

        }



    }



    #endregion

    #region Functions

    IEnumerator StarSequence()
    {

        yield return new WaitForSeconds(5.1f);

        if (WinLevel >= 1) { Star1.SetActive(true); }

        yield return new WaitForSeconds(2f);
        
       if (WinLevel >= 2) { Star2.SetActive(true); }

        yield return new WaitForSeconds(1.5f);

       if (WinLevel >= 3) { Star3.SetActive(true); }

    }


    #endregion


}
