using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFunctions : MonoBehaviour
{

    #region Functions

    public void LoadNextScene(float TimeBeforeLoad)
    {

        Invoke("LoadNextSceneFunction", TimeBeforeLoad);

    }

    public void LoadPreviousScene(float TimeBeforeLoad)
    {

        Invoke("LoadPreviousSceneFunction", TimeBeforeLoad);

    }

    public void LoadScene(string SceneToLoad)
    {

        SceneManager.LoadScene(SceneToLoad);

    }

    public void LoadSceneAfter(string SceneToLoad, float TimeBeforeLoad)
    {

        StartCoroutine(LoadSceneFunction(SceneToLoad, TimeBeforeLoad));

    }


    private void LoadNextSceneFunction()
    {

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);

    }

    private void LoadPreviousSceneFunction()
    {

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) - 1);

    }


    private IEnumerator LoadSceneFunction(string SceneToLoad, float TimeBeforeLoad)
    {
        yield return new WaitForSeconds(TimeBeforeLoad);
        SceneManager.LoadScene(SceneToLoad);

    }

    #endregion

}
