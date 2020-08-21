using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameOnKeyDown : MonoBehaviour
{

    #region Variables

    KeyCode PauseKey = KeyCode.Escape;

    bool isPaused = false;

    [SerializeField]
    GameObject PausePanel;

    [SerializeField]
    GameObject PauseMenu;

    #endregion


    #region Main

    void Update()
    {
        if (Input.GetKeyDown(PauseKey) && isPaused == false)
        {

            //pause game
            Time.timeScale = 0;

            //activate pause menu
            StartCoroutine(PauseSequence());

            isPaused = true;

        }
        else if (Input.GetKeyDown(PauseKey) && isPaused == true)
        {

            //unactivate pause menu
            StopCoroutine(PauseSequence());
            PausePanel.SetActive(false);
            PauseMenu.SetActive(false);

            //unpause game
            Time.timeScale = 1;

            isPaused = false;

        }
    }

    #endregion

    #region Functions 

    IEnumerator PauseSequence()
    {

        PausePanel.SetActive(true);
        yield return new WaitForSecondsRealtime(0.4f);
        PauseMenu.SetActive(true);

    }

    #endregion



}
