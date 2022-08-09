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

    AudioSource Music;
 

    #endregion

    #region Main

    void Start()
    {

        Music = FindObjectOfType<StartManager>().gameObject.transform.GetChild(2).GetComponent<AudioSource>();

    }

    void Update()
    {



        if (Input.GetKeyDown(PauseKey) && isPaused == false)
        {

            Pause();

        }
        else if (Input.GetKeyDown(PauseKey) && isPaused == true)
        {

            UnPause();

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

    public void Pause()
    {

        //pause Music
        Music.Pause();

        //pause game
        Time.timeScale = 0;

        //activate pause menu
        StartCoroutine(PauseSequence());

        isPaused = true;


    }

    public void UnPause()
    {

        //pause Music
        Music.UnPause();

        //unactivate pause menu
        StopCoroutine(PauseSequence());
        PausePanel.SetActive(false);
        PauseMenu.SetActive(false);

        //unpause game
        Time.timeScale = 1;

        isPaused = false;

    }


    #endregion

}
