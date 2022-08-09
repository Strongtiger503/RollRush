using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnKeyDown : MonoBehaviour
{

    //Requires QuitExitFunctions Script to be on a gameObject in the scene


    #region Variables

    [SerializeField]
    KeyCode ExitButton = KeyCode.Q;
    [SerializeField]
    float TimeBeforeExit = 0;
    [SerializeField]
    GameObject Trans;
    MusicManager mm;

    public QuitExitFunctions Quit;
    SwipeAndTapForMobileAndStandalone ss;

    #endregion


    #region Main

    // Start is called before the first frame update
    private void Start()
    {

        Quit = FindObjectOfType<QuitExitFunctions>();
        mm = FindObjectOfType<MusicManager>();
        ss = FindObjectOfType<SwipeAndTapForMobileAndStandalone>();

    }

    // Update is called once per frame
    void Update()
    {

        //When Exit Button is pressed 

        if (Input.GetKey(ExitButton) || ss.SwipeUp)
        {

            //Exit to Main Menu
            mm.ResetMusic();
            Quit.Exit(TimeBeforeExit);
            Trans.SetActive(true);

        }

    }

    #endregion

}
