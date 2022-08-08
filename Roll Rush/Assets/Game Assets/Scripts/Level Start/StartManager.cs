using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{

    //Requires RestartFunctions Script   
    //as it Keeps track of Number of Restarts



    #region Variables

    [SerializeField]
    private GameObject CountDown;
    
    private PauseGameOnKeyDown Pause;
    private ForwardMovement MoveForward;
    private HorizontalMovement MoveHorizontal;

    GameRestartManager Gm;

    MusicManager Mm;

    LevelEndManager Lm;

    #endregion

    #region Main


    void Start()
    {

        Pause = FindObjectOfType<PauseGameOnKeyDown>();
        MoveForward = FindObjectOfType<ForwardMovement>();
        MoveHorizontal = FindObjectOfType<HorizontalMovement>();
        Gm = FindObjectOfType<GameRestartManager>();
        Mm = FindObjectOfType<MusicManager>();
        Lm = FindObjectOfType<LevelEndManager>();
    }


    void Update()
    {

        ///if number of restarts equals 0  do countdown if not don't

        if (RestartFunctions.RestartNumber <= 0)
        {

            //enable count down

            CountDown.SetActive(true);

            //when count down is done

            if (CountDownManager.CountDownDone == true)
            {

                //Enable Restaart
                Gm.enabled = true;

                //EnableWin
                Lm.enabled = true;


                //enable pausing

                Pause.enabled = true;

                //enable player movement

                MoveForward.enabled = true;
                MoveHorizontal.enabled = true;

                //disable start manager

                this.enabled = false;

                //Enable Music
                Mm.enabled = true;

            }

        }
        else
        {

            CountDown.SetActive(false);

            //Enable Restaart
            Gm.enabled = true;

            //EnableWin
            Lm.enabled = true;

            //enable pausing

            Pause.enabled = true;

            //enable player movement

            MoveForward.enabled = true;
            MoveHorizontal.enabled = true;

            //Enable Music
            Mm.enabled = true;

            //destroy count down and disable start manager

            Destroy(CountDown);
            this.enabled = false;

        }

    }
      
    #endregion

}
