using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKeyDown : MonoBehaviour
{

    //Requires SRestart Script to be on a gameObject in the scene

    


    #region Variables

    [SerializeField]
    KeyCode ResetButton = KeyCode.R;
    [SerializeField]
    float TimeBeforeRestart = 0;

    public SRestart Reset;

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
   
        if (Input.GetKey(ResetButton))
        {

            Reset.Restart(TimeBeforeRestart);

        }

    }

    #endregion

}
