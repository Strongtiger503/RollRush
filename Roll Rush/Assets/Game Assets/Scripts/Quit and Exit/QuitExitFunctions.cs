using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitExitFunctions : MonoBehaviour
{

    #region Variables

    [SerializeField]
    string MainMenuOrOther;

    #endregion

    #region Functions

    #region Exit Functions

    //Exit Game after a certain time which is set as a prameter

    public void Exit(float TimeBeforeExit)
    {
        Invoke("ExitFunction", TimeBeforeExit);
    }

    //the function used in the invoke method in the previous method

    private void ExitFunction()
    {

        SceneManager.LoadScene(MainMenuOrOther);

    }


    #endregion

    #region Quit Functions

    //Quit Game after a certain time which is set as a prameter

    public void Quit(float TimeBeforeExit)
    {
        Invoke("QuitFunction", TimeBeforeExit);
    }

    //the function used in the invoke method in the previous method

    private void QuitFunction()
    {

        Debug.Log("Quit");
        Application.Quit();

    }

    #endregion

    #endregion

}
