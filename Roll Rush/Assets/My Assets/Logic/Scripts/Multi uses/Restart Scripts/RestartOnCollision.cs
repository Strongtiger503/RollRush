using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnCollision : MonoBehaviour
{

    //Requires SRestart Script to be on a gameObject in the scene




    #region Variables

    [SerializeField]
    string TagCollidedObject = "Obstacle";
    [SerializeField]
    float TimeBeforeRestart = 0;

    public SRestart Reset;

    #endregion

    #region Main 

    // Start is called before the first frame update
    private void Start()
    {

        Reset = FindObjectOfType<SRestart>();

    }


    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(TagCollidedObject))
        {
            Reset.Restart(TimeBeforeRestart);
        }


    }

    #endregion

}

