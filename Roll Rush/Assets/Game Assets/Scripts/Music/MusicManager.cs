﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    GameObject MusicRoom;
    AudioSource _Music;
    [SerializeField]
    AudioClip Music;
    Music_Info MuInfo;

    void Awake()
    {

        MusicRoom = this.transform.GetChild(2).gameObject;


        if (MusicRoom.GetComponent<AudioSource>() == null) 
        {

            MusicRoom.AddComponent(typeof(AudioSource));

        }

         MuInfo = MusicRoom.GetComponent<Music_Info>();
        _Music = MusicRoom.GetComponent<AudioSource>();
        _Music.clip = Music;
        _Music.volume = MuInfo.volume;
        _Music.pitch = MuInfo.pitch;
        _Music.loop = true;
        _Music.time = Music_Info.LatestTime;

    }

    void Start()
    {
        _Music.Play();
    }

    public void SaveMusic()
    {

            Music_Info.LatestTime = _Music.time;

    }


    public void ResetMusic() 
    {

        Music_Info.LatestTime = 0;

    }

}
