using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    //Requires RestartOnKeyDownModified Script   
    //as it Keeps track of Number of Restarts



    #region Variables

    [SerializeField]
    private GameObject CountDown;

    #endregion

    #region Main
     
    void Update()
    {
      
        if (RestartOnKeyDownModified.RestartNumber <= 0)
        {

            CountDown.SetActive(true);
            gameObject.SetActive(false);

        }
        else
        {

            CountDown.SetActive(false);
            gameObject.SetActive(false);

        }

    }

    #endregion

}
