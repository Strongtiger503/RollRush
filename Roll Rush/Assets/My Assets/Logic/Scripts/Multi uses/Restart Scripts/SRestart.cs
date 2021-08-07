using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SRestart : MonoBehaviour
{

    #region Functions

    //restarts scene after a certain time which is set as a prameter
    

    public void Restart(float TimeBeforeReset)
    {

        Invoke("RestartFunction", TimeBeforeReset);

    }

    //the function used in the invoke method in the previous method

    private void RestartFunction()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    #endregion

}
