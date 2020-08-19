using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogVelocity : MonoBehaviour
{

    #region Main

    void Update()
    {

        //Log Velocity
        Debug.Log(GetComponent<Rigidbody>().velocity.z);

    }

    #endregion

}
