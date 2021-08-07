using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBasedCharcterControllerV2 : MonoBehaviour
{
    
    #region Variables

    //Components used

    private Rigidbody rb;


    //Input

    float HorizontalMovement;
    float VerticalMovement;
    Vector3 Movement;


    [SerializeField]
    bool IsJumping = false;
    [SerializeField]
    bool IsGrounded = true;
    [SerializeField]
    string GroundTag = "Ground";


    //Force Applied Of Movement

    [SerializeField]
    float Speed = 1000f;
    [SerializeField]
    float JumpForce = 20000f;

// [ Warning : if the Jump force is low enough it could break the code ]


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

        //Checking for Input

        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        Movement = new Vector3(HorizontalMovement, 0f, VerticalMovement);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {

            IsJumping = true;

        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        //Applying Force to Movement and jumping

        //Movement
        rb.AddForce(Movement * Speed * Time.deltaTime);

       //Jumping

        if (IsJumping)
        {

            IsGrounded = false;
            rb.AddForce(Vector3.up * JumpForce * Time.deltaTime);
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
