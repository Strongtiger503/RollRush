using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTransitionManager : MonoBehaviour
{

    [SerializeField]
    GameObject TransEnd;

    // Start is called before the first frame update
    void Awake()
    {

        if (!QuitExitFunctions.Playpressed) 
        {

            TransEnd.SetActive(false);

        }

    }

}
