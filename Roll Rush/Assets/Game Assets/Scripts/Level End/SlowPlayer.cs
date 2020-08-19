using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{

    //Requires Player Forward Movement Script



    #region Variables

    [SerializeField]
    string PlayerTag = "Player";

    private ForwardMovement MoveForward;

    #endregion

    #region Main 


    private void Start()
    {

        MoveForward = FindObjectOfType<ForwardMovement>();

    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag(PlayerTag))
        {

            MoveForward.ForwardForceAcceleration = 5;
            MoveForward.SpeedLimit = 15;

        }
            
    
    }

    #endregion

}
