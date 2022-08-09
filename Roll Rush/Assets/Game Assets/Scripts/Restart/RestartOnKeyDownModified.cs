using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKeyDownModified : MonoBehaviour
{

    //Requires RestartFunctions Script to be on a gameObject in the scene

    //It Restart when a Button is pressed 


    #region Variables

    public KeyCode ResetButton = KeyCode.R;

    [SerializeField]
    float TimeBeforeRestart = 0;

    public RestartFunctions Reset;
    SwipeAndTapForMobileAndStandalone ss;


    #endregion


    #region Main

    // Start is called before the first frame update
    private void Start()
    {

        Reset = FindObjectOfType<RestartFunctions>();
        ss = FindObjectOfType<SwipeAndTapForMobileAndStandalone>();


    }

    // Update is called once per frame
    void Update()
    {

        //When Restart Button is pressed 

        if (Input.GetKey(ResetButton) || ss.Tap)
        {

           //Restart
            Reset.Restart(TimeBeforeRestart);

        }

    }

    #endregion

}
