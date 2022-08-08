using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class GameRestartManager : MonoBehaviour
{

    //Script On Player




    #region Variables

    [SerializeField]
    string ObstacleTag = "Obstacle";

    [SerializeField]
    GameObject Panel;
    [SerializeField]
    float TimeBeforePanelActivation = 0;

    [SerializeField]
    GameObject GameOverPanel;
    [SerializeField]
    float TimeBeforeGameOverPopupActivation = 0.4f;

    private RestartOnKeyDownModified RestartOnKeyDownScript;
    private ExitOnKeyDown ExitOnKeyDownScript;
    [SerializeField]
    float TimeBeforeBeingAbleToInput = 0.5f;

    private PauseGameOnKeyDown Pause;


    [SerializeField]
    MusicManager musicManager = null;
    [SerializeField]
    AudioSource Music = null;

    [SerializeField]
    AudioSource CollisionSound;


    #endregion

    #region Main

    //One Time Setter
    void Start()
    {

        RestartOnKeyDownScript = FindObjectOfType<RestartOnKeyDownModified>();
        ExitOnKeyDownScript = FindObjectOfType<ExitOnKeyDown>();       
        Pause = FindObjectOfType<PauseGameOnKeyDown>();
        Music = FindObjectOfType<StartManager>().gameObject.transform.GetChild(2).GetComponent<AudioSource>();
        musicManager = FindObjectOfType<StartManager>().GetComponent<MusicManager>();

    }




    void Update()
    {

   
        //ReEnable Music

        if ( RestartOnKeyDownScript.enabled && Input.GetKeyDown(RestartOnKeyDownScript.ResetButton))
        {

            Music.UnPause();

        }

        

    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(ObstacleTag))
        {

            //all need to be fast

            #region Sound and Music

            StartCoroutine(VolumeDecreaseSequence());

            //sound hit

            CollisionSound.Play();


            #endregion

            #region Stop Player

            GetComponent<HorizontalMovement>().enabled = false;
            GetComponent<ForwardMovement>().enabled = false;

            #endregion

            #region GameOver Screen Sequence

            StartCoroutine(ActivateGamOverScreenSequence());

            //if another button is pressed quit

            #endregion

            #region Disable PauseFunction 

            Pause.enabled = false;

            #endregion


        }


    }

    #endregion
     
    #region Functions

    IEnumerator ActivateGamOverScreenSequence()
    {

        //Wait then Fade in the Red Panel
        yield return new WaitForSeconds(TimeBeforePanelActivation);
        Panel.SetActive(true);
        
        //Wait then activate Game Over Pop up
        yield return new WaitForSeconds(TimeBeforeGameOverPopupActivation);
        GameOverPanel.SetActive(true);
        
        //if Button is pressed Restart and
        //Enabling the script Responsable for that
        yield return new WaitForSeconds(TimeBeforeBeingAbleToInput);
        RestartOnKeyDownScript.enabled = true;
        ExitOnKeyDownScript.enabled = true;

    }

    IEnumerator VolumeDecreaseSequence()
    {

        Music.volume = 75;
        Music.pitch = 0.9f;
        yield return new WaitForSeconds(0.5f);
        Music.volume = 50;
        Music.pitch = 0.8f;
        yield return new WaitForSeconds(0.2f);
        Music.volume = 25;
        Music.pitch = 0.7f;
        //Save Music
        musicManager.SaveMusic();
        Music.Stop();


    }


    #endregion

}
