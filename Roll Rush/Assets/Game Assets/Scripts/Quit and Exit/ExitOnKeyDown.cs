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

    public QuitExitFunctions Quit;

    #endregion


    #region Main

    // Start is called before the first frame update
    private void Start()
    {

        Quit = FindObjectOfType<QuitExitFunctions>();

    }

    // Update is called once per frame
    void Update()
    {

        //When Exit Button is pressed 

        if (Input.GetKey(ExitButton))
        {

            //Exit to Main Menu

            Quit.Exit(TimeBeforeExit);

        }

    }

    #endregion

}
