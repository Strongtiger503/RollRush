using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBasedCharcterControllerV1 : MonoBehaviour
{
    
    #region Variables

    //Components used

    private Rigidbody rb;
      


    //Input

    [SerializeField]
    KeyCode ForwardKey = KeyCode.W;
    [SerializeField]
    bool MoveForward = false;
    [SerializeField]
    KeyCode BackKey = KeyCode.S;
    [SerializeField]
    bool MoveBack = false;
    [SerializeField]
    KeyCode RightKey = KeyCode.D;
    [SerializeField]
    bool MoveRight = false;
    [SerializeField]
    KeyCode LeftKey = KeyCode.A;
    [SerializeField]
    bool MoveLeft = false;
    [SerializeField]
    KeyCode JumpKey = KeyCode.Space;
    [SerializeField]
    bool IsJumping = false;
    [SerializeField]
    bool IsGrounded = true;
    [SerializeField]
    string GroundTag = "Ground";



    //Force Applied Of Movement

    [SerializeField]
    float ForwardBackwardForce = 1000f;
    [SerializeField]
    float HorizontalForce = 1000f;
    [SerializeField]
    float JumpForce = 20000f;

//   [ Warning : if the Jump force is low enough it could break the code ]


    #endregion


    #region Main




    // Start is called before the first frame update
    void Start()
    {
 
     //Getting RedigidBody of gameObject

       rb = GetComponent<Rigidbody>();

    }






    private void Update()
    {

        //Checking for Input and setting bool as true

        if (Input.GetKey(ForwardKey))
        {
            MoveForward = true;
        }

        if (Input.GetKey(BackKey))
        {
            MoveBack = true;
        }

        if (Input.GetKey(RightKey))
        {
            MoveRight = true;
        }

        if (Input.GetKey(LeftKey))
        {
            MoveLeft = true;
        }

        if (Input.GetKeyDown(JumpKey) && IsGrounded)
        {

            IsJumping = true;

        }

    }






    // Update is called once per frame
    void FixedUpdate()
    {

        //Applying Force if bool is true

        if (MoveForward)
        {

            rb.AddForce(0f, 0f, ForwardBackwardForce * Time.deltaTime);
            MoveForward = false;

        }

        if (MoveBack)
        {

            rb.AddForce(0f, 0f, -ForwardBackwardForce * Time.deltaTime);
            MoveBack = false;

        }

        if (MoveRight) 
        {

            rb.AddForce(HorizontalForce * Time.deltaTime, 0f, 0f);
            MoveRight = false;

        }

        if (MoveLeft)
        {

            rb.AddForce(-HorizontalForce * Time.deltaTime, 0f, 0f);
            MoveLeft = false;

        }


        if (IsJumping)
        {

            IsGrounded = false;
            rb.AddForce(0f, JumpForce * Time.deltaTime, 0f);
            IsJumping = false;
            

        }

    }


    //make ground check true when colliding with ground

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag(GroundTag))
        {


            IsGrounded = true;


        }

    }

    

    #endregion


}
