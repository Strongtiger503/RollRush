using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKeyDownModified : MonoBehaviour
{

    //Requires SRestart Script to be on a gameObject in the scene

    


    #region Variables

    [SerializeField]
    KeyCode ResetButton = KeyCode.R;
    [SerializeField]
    float TimeBeforeRestart = 0;

    public SRestart Reset;


    //How many times the scene hs been reloaded
    public static int ReloadNumber = 0;

    #endregion


    #region Main

    // Start is called before the first frame update
    private void Start()
    {

        Reset = FindObjectOfType<SRestart>();


    }

    // Update is called once per frame
    void Update()
    {

        //When Restart Button is pressed 

        if (Input.GetKey(ResetButton))
        {

           //it increase the Reload Number
            ReloadNumber++;

           //Restart
            Reset.Restart(TimeBeforeRestart);


        }

    }

    #endregion

}
