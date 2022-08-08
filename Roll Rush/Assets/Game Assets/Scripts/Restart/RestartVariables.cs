using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartVariables : MonoBehaviour
{
    
    #region Main

    // Start is called before the first frame update
    void Start()
    {

        RestartFunctions.RestartNumber = 0;
        TimeManager.time = 0;

    }

    #endregion

}
