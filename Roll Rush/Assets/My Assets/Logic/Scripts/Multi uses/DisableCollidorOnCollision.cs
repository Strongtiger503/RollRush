using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollidorOnCollision : MonoBehaviour
{

    #region Variables
    [SerializeField]
    BoxCollider box;
    [SerializeField]
    string TagCollidedObject = "Player";

    #endregion

    #region Main

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(TagCollidedObject))
        {

            box.enabled = false;

        }

    }

    #endregion

}
