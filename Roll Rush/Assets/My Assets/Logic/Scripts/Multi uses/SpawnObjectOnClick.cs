using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnClick : MonoBehaviour
{

    #region Variables

    [SerializeField]
    public GameObject SpawnedObject;
    
    [SerializeField]
    float TimeBeforeSpawn = 0.05f;
    [SerializeField]
    float CurrentTimeBS;
    bool BeginTimer = false;

    [SerializeField]
    Vector3 PositionOfSpawn = new Vector3(0, 6, 0);
    [SerializeField]
    Vector3 SpawnJitter = new Vector3(0, 0, 0);

    #endregion


    #region Main


    // Start is called before the first frame update
    void Start()
    {
        CurrentTimeBS = TimeBeforeSpawn;
    }


    // Update is called once per frame
    void Update()
    {

       //if you left click it starts a Timer
        if (Input.GetMouseButton(0))
        {

            CurrentTimeBS = TimeBeforeSpawn;
            BeginTimer = true;

        }

 
    }

    private void FixedUpdate()
    {

        //when time hits zero it spawns the Object

        if (CurrentTimeBS <= 0)
        {

            BeginTimer = false;
            CurrentTimeBS = TimeBeforeSpawn;
            PositionOfSpawn += Vector3.right * SpawnJitter.x * (Random.value - 0.5f);
            PositionOfSpawn += Vector3.up * SpawnJitter.y * (Random.value - 0.5f);
            PositionOfSpawn += Vector3.forward * SpawnJitter.z * (Random.value - 0.5f);
            Instantiate(SpawnedObject, PositionOfSpawn , Quaternion.identity);


        }

        if (BeginTimer) 
        {


            if (CurrentTimeBS > 0)
            {

                //Decrease timer

                CurrentTimeBS -= Time.deltaTime;

            }


        }


    }



    #endregion

}
