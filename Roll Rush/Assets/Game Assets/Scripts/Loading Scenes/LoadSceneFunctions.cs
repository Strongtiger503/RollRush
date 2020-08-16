using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFunctions : MonoBehaviour
{

    #region Variables

    [SerializeField]
    string SceneToLoad;

    #endregion

    #region Functions

    public void LoadNextScene(float TimeBeforeLoad)
    {

        Invoke("LoadNextSceneFunction", TimeBeforeLoad);

    }

    public void LoadPreviousScene(float TimeBeforeLoad)
    {

        Invoke("LoadPreviousSceneFunction", TimeBeforeLoad);

    }


    public void LoadScene(float TimeBeforeLoad)
    {

        Invoke("LoadSceneFunction", TimeBeforeLoad);

    }

    private void LoadNextSceneFunction()
    {

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);

    }

    private void LoadPreviousSceneFunction()
    {

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) - 1);

    }


    private void LoadSceneFunction()
    {

        SceneManager.LoadScene(SceneToLoad);

    }

    #endregion

}
