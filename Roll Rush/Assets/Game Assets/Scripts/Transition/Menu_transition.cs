using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Menu_transition : MonoBehaviour
{

    Animator anim;
    [SerializeField]
    GameObject menuActive;
    [SerializeField]
    GameObject menuDisable;

    void Start()
    {
               
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f)
        {

            menuActive.SetActive(true);
            menuDisable.SetActive(false); 

        }
;
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f) 
        { 

            gameObject.SetActive(false);
 
        }

    }
}
