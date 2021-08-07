using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementv0 : MonoBehaviour
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
  // [ Warning if forward force is setless than 10 code might break ]
    [SerializeField]
    float HorizontalForce = 1;
    [SerializeField]
    float SpeedLimit = 30;

    #endregion

    #region Main

    // Start is called before the first frame update
    void Awake()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       
        //Setting CheckPoint Values

        PointRight = new Vector3(TPointRight.position.x, transform.position.y, transform.position.z);
        PointMid = new Vector3(TPointMid.position.x, transform.position.y, transform.position.z);
        PointLeft = new Vector3(TPointLeft.position.x, transform.position.y, transform.position.z);


  
        //checking Input


        if (Input.GetKeyDown(RightKey) && !MoveMidToLeft && !MoveLeftToMid && !(transform.position.x <= PointLeft.x) && !(transform.position.x >= PointRight.x))
        {

            MoveMidToRight = true;
        
        }
        else if (Input.GetKeyDown(RightKey) && !MoveMidToLeft && !MoveLeftToMid && transform.position.x <= PointLeft.x)
        {

            MoveRightToMid = true;
        
        }


        if (Input.GetKeyDown(LeftKey) && !MoveMidToRight && !MoveRightToMid && !(transform.position.x <= PointLeft.x) && !(transform.position.x >= PointRight.x))
        {

            MoveMidToLeft = true;

        }
        else if (Input.GetKeyDown(LeftKey) && !MoveMidToRight && !MoveRightToMid && transform.position.x >= PointRight.x)
        {

            MoveLeftToMid = true;

        }




    }

    private void FixedUpdate()
    {

        //Forward Movement (Auto)
        if (rb.velocity.z < SpeedLimit)
        {

            rb.velocity += Vector3.forward * ForwardForce * Time.deltaTime;

        }
        else if (rb.velocity.z >= SpeedLimit )
        {

            rb.velocity = new Vector3(rb.velocity.x , rb.velocity.y, SpeedLimit);

        }

        //Right Movement

        if (MoveMidToRight)
        {

            transform.position = Vector3.MoveTowards(transform.position, PointRight, HorizontalForce * Time.deltaTime);
           
            if (transform.position.x >= PointRight.x)
            {

                MoveMidToRight = false;

            }
         

        }

        if (MoveRightToMid)
        {

            transform.position = Vector3.MoveTowards(transform.position, PointMid, HorizontalForce * Time.deltaTime);


            if (transform.position.x == PointMid.x)
            {

                MoveRightToMid = false;

            }


        }

        //Left Movement

        if (MoveMidToLeft)
        {

            transform.position = Vector3.MoveTowards(transform.position, PointLeft, HorizontalForce * Time.deltaTime);


            if (transform.position.x <= PointLeft.x)
            {

                MoveMidToLeft = false;

            }


        }

        if (MoveLeftToMid)
        {

            transform.position = Vector3.MoveTowards(transform.position, PointMid, HorizontalForce * Time.deltaTime);


            if (transform.position.x == PointMid.x)
            {
                
                MoveLeftToMid = false; 

            }

        }

    }

    #endregion

}
