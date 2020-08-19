using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndManager : MonoBehaviour
{

    //Requires Player Movement Script for Level Complete Sequence



    #region Variables

    [SerializeField]
    string PlayerTag = "Player";

    [SerializeField]
    float SlowMoFactor = 0.05f;
    [SerializeField]
    float SlowMoLength = 2f;


    [SerializeField]
    float TimeBeforeConfettiManagerActivation = 1f;
    [SerializeField]
    float TimeBeforeNextConfettiActivation = 1f;
    [SerializeField]
    GameObject Confetti1;
    [SerializeField]
    GameObject Confetti2;


    [SerializeField]
    float TimeBeforePanelActiviation = 0.6f;
    [SerializeField]
    GameObject LevelCompletePanel;

    //Player Forwrd Movement Script
    private ForwardMovement MoveForward;


    #endregion


    #region Main


    void Start()
    {

        MoveForward = FindObjectOfType<ForwardMovement>();

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("You Win");

        if (other.CompareTag(PlayerTag))
        {

            StartCoroutine(ActivateLevelCompleteSequence());

        }

    }


    //do sound 

    //number of stars 

    //quit button or Next Button

    #endregion


    #region Functions 

    IEnumerator SlowMoGame()
    {

        //wait then Begin SlowMo
        //yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = SlowMoFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        
        //Changing Player Speed To Normalish
        MoveForward.SpeedLimit = 26;
        MoveForward.ForwardForceAcceleration = 40;
        
        //wait then End SlowMo
        yield return new WaitForSecondsRealtime(SlowMoLength);
        Time.timeScale = 1f;


    }

    IEnumerator ConfettiManager()
    {

        //Enable First Set Confetti
        Confetti1.SetActive(true);
        
        yield return new WaitForSecondsRealtime(TimeBeforeNextConfettiActivation);
        
        //Disable First Set Confetti
        Confetti1.SetActive(false);
        
        //Enable Second Set Confetti
        Confetti2.SetActive(true);
        
        yield return new WaitForSecondsRealtime(TimeBeforeNextConfettiActivation);
        
        //Disable First Set Confetti
        Confetti2.SetActive(false);

        yield return new WaitForSecondsRealtime(0.1f);

        //Enable First Set Confetti
        Confetti1.SetActive(true);
        //Enable Second Set Confetti
        Confetti2.SetActive(true);

    }

    IEnumerator ActivateLevelCompleteSequence()
    {


        //Make Camera stop following the Player
        FindObjectOfType<FollowObject>().enabled = false;

        //activite slow Mo and Change Player speed Back to Normalish
        StartCoroutine(SlowMoGame());

        yield return new WaitForSecondsRealtime(TimeBeforeConfettiManagerActivation);

        //Enable Confetti
        StartCoroutine(ConfettiManager());

        yield return new WaitForSecondsRealtime(TimeBeforePanelActiviation);

        //Enable Level Complete pop up
        LevelCompletePanel.SetActive(true);

    }



    #endregion

}
