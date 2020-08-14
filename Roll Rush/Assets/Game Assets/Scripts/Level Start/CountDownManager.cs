using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{

    //could be Optimized but not worth it


    #region Variables

    [SerializeField]
    private GameObject three;
    [SerializeField]
    private GameObject two;
    [SerializeField]
    private GameObject one;
    [SerializeField]
    private GameObject go;

    #endregion

    #region Main


    void OnEnable()
    {
        
        //Calling the Courntine
        StartCoroutine(CountDown());

    }

 
    //The Courantine

    IEnumerator CountDown()
    {


        //pause game
        Time.timeScale = 0;


        //Do Counter

        yield return new WaitForSecondsRealtime(1f);

        //Enabling and disabling " 3 "
        three.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        three.SetActive(false);

        //Enabling and disabling " 2 "
        two.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        two.SetActive(false);

        //Enabling and disabling " 1 "
        one.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        one.SetActive(false);

        //Enabling and disabling " Go "
        go.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        go.SetActive(false);


        //unpause game
        Time.timeScale = 1;


        yield return new WaitForSecondsRealtime(1f);


        //Destroy Object
        Destroy(gameObject);

    }


    #endregion

}
