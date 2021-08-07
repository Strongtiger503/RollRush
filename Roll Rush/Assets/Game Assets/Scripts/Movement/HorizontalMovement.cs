using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalMovement : MonoBehaviour
{

    #region Variables


    #region Check points Variables


    //transform of check points
    [SerializeField]
    Transform TPointRight;
    [SerializeField]
    Transform TPointMid;
    [SerializeField]
    Transform TPointLeft;

    //The actual check points
    Vector3 PointRight;
    Vector3 PointMid;
    Vector3 PointLeft;

    //Area of the check points
    [SerializeField]
    Transform PointRightCheckArea;
    [SerializeField]
    Transform PointLeftCheckArea;


    #endregion


    #region Components used

    //physics
    Rigidbody rb;

    #endregion


    #region Input

    //Keys
    [SerializeField]
    KeyCode RightKey = KeyCode.D;
    [SerializeField]
    KeyCode LeftKey = KeyCode.A;

    //Condition
    [SerializeField]
    bool MoveMidToRight = false;
    [SerializeField]
    bool MoveMidToLeft = false;
    [SerializeField]
    bool MoveRightToMid = false;
    [SerializeField]
    bool MoveLeftToMid = false;

    #endregion


    #region Movement Force
   
    //Horizontal Movement Force
    [SerializeField]
    float HorizontalForce = 40;

    #endregion


    #region Animation

    [SerializeField]
    Animator animator;

    #endregion


    #endregion

    #region Main

    #region One time Setters


    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }


    #endregion


    #region setting Checkpoints and Checking For Input


    private void Update()
    {

        //Setting CheckPoint Values

        PointRight = new Vector3(TPointRight.position.x, transform.position.y, transform.position.z);
        PointMid = new Vector3(TPointMid.position.x, transform.position.y, transform.position.z);
        PointLeft = new Vector3(TPointLeft.position.x, transform.position.y, transform.position.z);



        //checking Input

        if (Input.GetKeyDown(RightKey) && transform.position.x < PointLeftCheckArea.position.x && !MoveMidToLeft && !MoveLeftToMid && !MoveMidToRight )
        {

            MoveLeftToMid = true;
            animator.SetBool("MoveRight" , true);

        }
        else if (Input.GetKeyDown(RightKey) && (transform.position.x < PointRightCheckArea.position.x) && (transform.position.x > PointLeftCheckArea.position.x) && !MoveMidToLeft && !MoveLeftToMid && !MoveRightToMid )
        {

            MoveMidToRight = true;
            animator.SetBool("MoveRight", true);

        }

        if (Input.GetKeyDown(LeftKey) && transform.position.x > PointRightCheckArea.position.x && !MoveMidToRight && !MoveRightToMid && !MoveMidToLeft)
        {

            MoveRightToMid = true;
            animator.SetBool("MoveLeft", true);

        }
        else if (Input.GetKeyDown(LeftKey) && (transform.position.x < PointRightCheckArea.position.x) && (transform.position.x > PointLeftCheckArea.position.x) && !MoveMidToRight && !MoveRightToMid && !MoveLeftToMid)
        {

            MoveMidToLeft = true;
            animator.SetBool("MoveLeft", true);

        }


    }


    #endregion


    #region Horizontal Movement ( Right / Left ) 


    private void FixedUpdate()
    {


        //Right Movement

        if (MoveLeftToMid)
        {

            //Movement
            MoveToPoint(PointMid);


            //set condition to false after action is done
            if (transform.position.x == PointMid.x)
            {

                MoveLeftToMid = false;
                animator.SetBool("MoveRight", false);

            }

        }


        if (MoveMidToRight)
        {

            //Movement
            MoveToPoint(PointRight);


            //set condition to false after action is done
            if (transform.position.x >= PointRight.x)
            {

                MoveMidToRight = false;
                animator.SetBool("MoveRight", false);

            }

        }




        //Left Movement

        if (MoveRightToMid)
        {


            //Movement
            MoveToPoint(PointMid);


            //set condition to false after action is done
            if (transform.position.x == PointMid.x)
            {

                MoveRightToMid = false;
                animator.SetBool("MoveLeft", false);

            }

        }



        if (MoveMidToLeft)
        {


            //Movement
            MoveToPoint(PointLeft);


            //set condition to false after action is done
            if (transform.position.x <= PointLeft.x)
            {

                MoveMidToLeft = false;
                animator.SetBool("MoveLeft", false);

            }

        }
        

    }


    #endregion


    #region Functions

    private void MoveToPoint(Vector3 Point)
    {

        //Movement

        transform.position = Vector3.MoveTowards(transform.position, Point, HorizontalForce * Time.deltaTime);

    }

    #endregion

    #endregion

}
