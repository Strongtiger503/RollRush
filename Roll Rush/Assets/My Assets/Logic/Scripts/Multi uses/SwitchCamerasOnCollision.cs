using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamerasOnCollision : MonoBehaviour
{

    //Requires ForceBasedCharcterController Script to be on the Player

    #region Variables

    [SerializeField]
    GameObject PlayerTracker1 = null;
    [SerializeField]
    GameObject PlayerTracker2 = null;

    [SerializeField]
    string TagCollidedObject = "Projectile";

    #endregion

    #region Main

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(TagCollidedObject))
        {

            Debug.Log(gameObject + "       Hit      " + collision.gameObject);
            PlayerTracker1.SetActive(false);
            PlayerTracker2.SetActive(true);
        
        }
        
    }

    #endregion

}
