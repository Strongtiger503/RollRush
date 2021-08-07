using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGlobalLocalPos : MonoBehaviour
{

    #region Main

    // Start is called before the first frame update
    void Start()
    {

        //Print Global Position

        Debug.Log(GetComponent<Transform>().position);

        //Print Local Position

        Debug.Log(GetComponent<Transform>().localPosition);

    }

    #endregion

}
