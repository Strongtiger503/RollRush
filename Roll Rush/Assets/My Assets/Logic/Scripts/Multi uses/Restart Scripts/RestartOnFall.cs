using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnFall : MonoBehaviour
{

    //Requires SRestart Script to be on a gameObject in the scene
       
    //If the A Certain Object falls below a certain Y cordinate it restarts the scene


    #region Variables

    [SerializeField]
    Transform FallingObject = null;
    public SRestart Reset;

    [SerializeField]
    float TimeBeforeRestart = 0;
    [SerializeField]
    float AmountPlayerHasToFall = -25;

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
    
        if (FallingObject.position.y <= AmountPlayerHasToFall)
        {

            Reset.Restart(TimeBeforeRestart);

        }

    }

    #endregion

}
