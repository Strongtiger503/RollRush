using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DisableAfterAnimation : MonoBehaviour
{

    Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();

    }


    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {

            gameObject.SetActive(false);

        }

    }
}
