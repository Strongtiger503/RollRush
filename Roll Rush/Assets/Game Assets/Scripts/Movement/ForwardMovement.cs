using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    #region Variables

    
    Rigidbody rb;


   [SerializeField]
   public float ForwardForceAcceleration = 15;
   [SerializeField]
   public float SpeedLimit = 20;


    #endregion


    #region Main


    //One time Setters
    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }


    //Forward Movement (Auto)
    private void FixedUpdate()
    {

        if (rb.velocity.z < SpeedLimit) 
        {

            rb.velocity += Vector3.forward * ForwardForceAcceleration * Time.deltaTime;

        }

    }


    #endregion


    #region For Debugging


    private void Update()
    {
        //Log speed
        //Debug.Log(rb.velocity.z);
    }


    #endregion

}
