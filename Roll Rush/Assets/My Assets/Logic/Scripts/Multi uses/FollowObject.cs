using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    #region  Variables

    [SerializeField] 
    private Transform FollowedObject = null;
    [SerializeField]
    Vector3 DistanceFromFollowedObject = new Vector3(0, 0, 0);

    #endregion

    #region Main 

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = FollowedObject.position + DistanceFromFollowedObject;
    
    }

    #endregion

}
