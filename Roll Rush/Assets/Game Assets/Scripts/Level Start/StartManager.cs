using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private GameObject CountDown;

    #endregion

    #region Main
     
    void Update()
    {

       
        if (RestartOnKeyDownModified.ReloadNumber <= 0)
        {

            CountDown.SetActive(true);

        }
        else
        {

            CountDown.SetActive(false);

        }
         

    }

    #endregion

}
