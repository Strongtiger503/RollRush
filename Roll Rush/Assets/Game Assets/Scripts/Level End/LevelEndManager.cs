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
    float TimeBeforePanelActiviation = 0.8f;

    [SerializeField]
    float TimeBeforeBackPanelActiviation = 0.6f;

    [SerializeField]
    GameObject LevelCompleteBackPanel;
    [SerializeField]
    GameObject LevelCompletePanel;

    //Player Forwrd Movement Script
    private ForwardMovement MoveForward;

    bool FireWorksOn = false;

    [SerializeField]
    GameObject musicplayer;
    AudioSource Music;

    [SerializeField]
    AudioSource FireWorksSound;

    [SerializeField]
    AudioSource FireWorksSound2;

    [SerializeField]
    AudioSource FireWorksSound3;

    PauseGameOnKeyDown Pause;

    public bool Win = false;

    #endregion


    #region Main


    void Start()
    {

        MoveForward = FindObjectOfType<ForwardMovement>();
        Pause = FindObjectOfType<PauseGameOnKeyDown>();
        Music = FindObjectOfType<StartManager>().gameObject.transform.GetChild(2).GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("You Win");
        Win = true;

        if (other.CompareTag(PlayerTag))
        {

            //Disable Pause
            Pause.enabled = false;

            StartCoroutine(ActivateLevelCompleteSequence());
           

        }


    }

    void Update()
    {


    }

 

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
        FireWorksSound.Play();

        yield return new WaitForSecondsRealtime(TimeBeforeNextConfettiActivation);
        
        //Disable First Set Confetti
        Confetti1.SetActive(false);
        
        //Enable Second Set Confetti
        Confetti2.SetActive(true);
        FireWorksSound2.Play();

        yield return new WaitForSecondsRealtime(TimeBeforeNextConfettiActivation);
        
        //Disable First Set Confetti
        Confetti2.SetActive(false);

        yield return new WaitForSecondsRealtime(0.1f);

        //Enable First Set Confetti
        Confetti1.SetActive(true);
        FireWorksSound.Play();
        //Enable Second Set Confetti
        Confetti2.SetActive(true);
        FireWorksSound3.Play();

        FireWorksOn = true;

    }

    IEnumerator MusicAndSound() 
    {


        Music.volume = 0.75f;
        yield return new WaitForSeconds(0.1f);
        Music.volume = 0.5f;
        yield return new WaitForSeconds(0.1f);
        Music.volume = 0.25f;
        yield return new WaitForSeconds(0.1f);
        Music.volume = 0.1f;


        yield return new WaitUntil(() => FireWorksOn == true);
        
        yield return new WaitForSeconds(0.7f);

        Music.volume = 0.25f;
        yield return new WaitForSeconds(0.2f);
        Music.volume = 0.5f;
        yield return new WaitForSeconds(0.2f);
        Music.volume = 0.75f;
        Music.pitch = 0.8f;
        yield return new WaitForSeconds(0.1f);
        Music.volume = 1;
        Music.pitch = 0.7f;

        Music.loop = false;


    }

    IEnumerator ActivateLevelCompleteSequence()
    {


        //Make Camera stop following the Player
        FindObjectOfType<FollowObject>().enabled = false;

        //Music Slow down
        StartCoroutine(MusicAndSound());

        //activite slow Mo and Change Player speed Back to Normalish
        StartCoroutine(SlowMoGame());

        yield return new WaitForSecondsRealtime(TimeBeforeConfettiManagerActivation);

        //Enable Confetti
        StartCoroutine(ConfettiManager());

        yield return new WaitForSecondsRealtime(TimeBeforePanelActiviation);

        //Enable Level Complete pop up
        LevelCompleteBackPanel.SetActive(true);

        yield return new WaitForSecondsRealtime(TimeBeforeBackPanelActiviation);

        LevelCompletePanel.SetActive(true);


        //number of stars


    }



    #endregion

}
