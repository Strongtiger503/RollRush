using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementv2 : MonoBehaviour
{

    #region Variables

    //Components Used

    Rigidbody rb;
   
    [SerializeField]
    Transform TPointRight;
    [SerializeField]
    Transform TPointMid;
    [SerializeField]
    Transform TPointLeft;

    Vector3 PointRight;
    Vector3 PointMid;
    Vector3 PointLeft;


    //Input

    [SerializeField]
    KeyCode RightKey = KeyCode.D;
    [SerializeField]
    KeyCode LeftKey = KeyCode.A;
    [SerializeField]
    bool MoveMidToRight = false;
    [SerializeField]
    bool MoveMidToLeft = false;
    [SerializeField]
    bool MoveRightToMid= false;
    [SerializeField]
    bool MoveLeftToMid = false;



    //Movement Forces

    [SerializeField]
    float ForwardForce = 10;
    [SerializeField]
    float HorizontalForce = 1;
    [SerializeField]
    float SpeedLimit = 30;

    #endregion

    #region Main

    //one time setters

    void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }




    //checkers and more than one time setters

    void Update()
    {

        //Log speed
        //Debug.Log(rb.velocity.z);
        


        //Setting CheckPoint Values

        PointRight = new Vector3(TPointRight.position.x, transform.position.y, transform.position.z);
        PointMid = new Vector3(TPointMid.position.x, transform.position.y, transform.position.z);
        PointLeft = new Vector3(TPointLeft.position.x, transform.position.y, transform.position.z);


  
        //checking Input

        //uses areas instead of checkpints


        if (Input.GetKeyDown(RightKey) && !MoveMidToLeft && !MoveLeftToMid && !MoveRightToMid && !(transform.position.x <= PointLeft.x) && !(transform.position.x >= PointRight.x))
        {

            MoveMidToRight = true;
        
        }
        else if (Input.GetKeyDown(RightKey) && !MoveMidToLeft && !MoveLeftToMid && !MoveMidToRight && transform.position.x <= PointLeft.x)
        {

            MoveLeftToMid = true;
        
        }


        if (Input.GetKeyDown(LeftKey) && !MoveMidToRight && !MoveRightToMid && !MoveLeftToMid && !(transform.position.x <= PointLeft.x) && !(transform.position.x >= PointRight.x))
        {

            MoveMidToLeft = true;

        }
        else if (Input.GetKeyDown(LeftKey) && !MoveMidToRight && !MoveRightToMid && !MoveMidToLeft && transform.position.x >= PointRight.x)
        {

            MoveRightToMid = true;

        }




    }




    //physics

    private void FixedUpdate()
    {

        //Forward Movement (Auto)
        if (rb.velocity.z < SpeedLimit)
        {

            rb.velocity += Vector3.forward * ForwardForce * Time.deltaTime;

        }

        //Horizontal Movement ( Right /Left ) 

        if (MoveMidToRight)
        {
            //Movement

            transform.position = Vector3.MoveTowards(transform.position, PointRight, HorizontalForce * Time.deltaTime);
           
            //set condition to false after action is done

            if (transform.position.x >= PointRight.x)
            {

                MoveMidToRight = false;

            }
         

        }

        if (MoveRightToMid)
        {

            //Movement

            transform.position = Vector3.MoveTowards(transform.position, PointMid, HorizontalForce * Time.deltaTime);


            //set condition to false after action is done

            if (transform.position.x == PointMid.x)
            {

                MoveRightToMid = false;

            }


        }

        //Left Movement

        if (MoveMidToLeft)
        {

            //Movement

            transform.position = Vector3.MoveTowards(transform.position, PointLeft, HorizontalForce * Time.deltaTime);


            //set condition to false after action is done

            if (transform.position.x <= PointLeft.x)
            {

                MoveMidToLeft = false;

            }


        }

        if (MoveLeftToMid)
        {

            //Movement

            transform.position = Vector3.MoveTowards(transform.position, PointMid, HorizontalForce * Time.deltaTime);


            //set condition to false after action is done

            if (transform.position.x == PointMid.x)
            {
                
                MoveLeftToMid = false; 

            }

        }

    }

    #endregion

}
