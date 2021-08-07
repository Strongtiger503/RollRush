using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerOnCollison2 : MonoBehaviour
{

    //Requires ForceBasedCharcterController Script to be on the Player
    

    #region Variables

    [SerializeField]
    string TagCollidedObject = "Obstacle";
    float Counter;

    #endregion

    #region Main

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(TagCollidedObject))
        {

            //Disable character controller

            Counter = 5f;
            while (Counter <= 0)
            {
                Counter -= 1f;
            }
            //Stop the player
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        
    }

    #endregion

}
