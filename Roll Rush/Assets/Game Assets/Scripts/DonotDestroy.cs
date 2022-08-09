using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonotDestroy : MonoBehaviour
{
    void Awake()
    {

        DontDestroyOnLoad(GetComponent<DonotDestroy>());
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GetComponent<AudioSource>());

    }

}
