using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFunctions : MonoBehaviour
{

    //restarts scene after a certain time which is set as a prameter

    //It keeps track of the number of Restarts

    //So it is required for StartManager Script




    #region Functions


    //How many times the scene hs been reloaded
    public static int RestartNumber = 0;


    public void Restart(float TimeBeforeReset)
    {

        //it increase the Reload Number
        RestartNumber++;

        Invoke("RestartFunction", TimeBeforeReset);

    }


    public void RestartCompletlely(float TimeBeforeReset)
    {

        //it increase the Reload Number
        RestartNumber = 0;

        //ReloadTimer
        TimeManager.time = 0;

        Invoke("RestartFunction", TimeBeforeReset);

    }



    //the function used in the invoke method in the previous method

    private void RestartFunction()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    #endregion

}
