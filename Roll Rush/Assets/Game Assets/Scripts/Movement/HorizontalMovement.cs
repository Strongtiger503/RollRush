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

    private void Awake()
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

        if (Input.GetKeyDown(RightKey) && !MoveMidToLeft && !MoveLeftToMid && !MoveMidToRight && transform.position.x < PointLeftCheckArea.position.x)
        {

            MoveLeftToMid = true;
            animator.SetBool("MoveRight" , true);

        }
        else if (Input.GetKeyDown(RightKey) && !MoveMidToLeft && !MoveLeftToMid && !MoveRightToMid && (transform.position.x < PointRightCheckArea.position.x) && (transform.position.x > PointLeftCheckArea.position.x))
        {

            MoveMidToRight = true;
            animator.SetBool("MoveRight", true);

        }

        if (Input.GetKeyDown(LeftKey) && !MoveMidToRight && !MoveRightToMid && !MoveMidToLeft && transform.position.x > PointRightCheckArea.position.x)
        {

            MoveRightToMid = true;
            animator.SetBool("MoveLeft", true);

        }
        else if (Input.GetKeyDown(LeftKey) && !MoveMidToRight && !MoveRightToMid && !MoveLeftToMid && (transform.position.x < PointRightCheckArea.position.x) && (transform.position.x > PointLeftCheckArea.position.x))
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

            transform.position = Vector3.MoveTowards(transform.position, PointMid, HorizontalForce * Time.deltaTime);



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

            transform.position = Vector3.MoveTowards(transform.position, PointRight, HorizontalForce * Time.deltaTime);



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

            transform.position = Vector3.MoveTowards(transform.position, PointMid, HorizontalForce * Time.deltaTime);



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

            transform.position = Vector3.MoveTowards(transform.position, PointLeft, HorizontalForce * Time.deltaTime);



            //set condition to false after action is done

            if (transform.position.x <= PointLeft.x)
            {

                MoveMidToLeft = false;
                animator.SetBool("MoveLeft", false);

            }


        }

    }


    #endregion

    #endregion

}
