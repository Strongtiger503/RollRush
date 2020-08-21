using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    //Requires RestartFunctions Script   
    //as it Keeps track of Number of Restarts



    #region Variables

    [SerializeField]
    private GameObject CountDown;
    
    private PauseGameOnKeyDown Pause;

    #endregion

    #region Main

    void Start()
    {

        Pause = FindObjectOfType<PauseGameOnKeyDown>();

    }


    void Update()
    {
      
        if (RestartFunctions.RestartNumber <= 0)
        {

            CountDown.SetActive(true);
            if (CountDownManager.CountDownDone == true)
            {

                Pause.enabled = true;
                this.enabled = false;

            }

        }
        else
        {

            CountDown.SetActive(false);
            Pause.enabled = true;
            Destroy(CountDown);
            this.enabled = false;

        }

    }

    #endregion

}
