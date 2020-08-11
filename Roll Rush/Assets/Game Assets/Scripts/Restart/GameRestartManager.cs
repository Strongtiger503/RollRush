using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class GameRestartManager : MonoBehaviour
{

    #region Variables

    [SerializeField]
    string ObstacleTag = "Obstacle";

    [SerializeField]
    GameObject Panel;
    [SerializeField]
    float TimeBeforePanelActivation = 0.25f;

    [SerializeField]
    GameObject GameOverPanel;
    [SerializeField]
    float TimeBeforeGameOverPopupActivation = 0.5f;

    private RestartOnKeyDownModified RestartOnKeyDownScript;
    [SerializeField]
    float TimeBeforeBeingAbleToRestart = 0.8f;

    #endregion

    #region Main

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(ObstacleTag))
        {

            //all need to be fast

            #region Sound

            //sound hit

            #endregion

            #region Stop Player

            StopPlayer();

            #endregion

            #region GameOver Screen 

            //Fade in the Red Panel and Game Over Panel
            Invoke("PanelFadein", TimeBeforePanelActivation);
            Invoke("GameOverPopup", TimeBeforeGameOverPopupActivation);

            //if Button is pressed Restart and
            //Enabling the script Responsable for that
            Invoke("EnableScript", TimeBeforeBeingAbleToRestart);

            #endregion

            //if another button is pressed quit

        }


    }

    #endregion
     
    #region Functions

    private void StopPlayer()
    {

        GetComponent<HorizontalMovement>().enabled = false;
        GetComponent<ForwardMovement>().enabled = false;

    }

    private void PanelFadein()
    {

        Panel.SetActive(true);


    }

    private void GameOverPopup()
    {

        GameOverPanel.SetActive(true);

    }

    private void EnableScript()
    {
       
        RestartOnKeyDownScript = FindObjectOfType<RestartOnKeyDownModified>();
        RestartOnKeyDownScript.enabled = true;

    }

    #endregion

}
