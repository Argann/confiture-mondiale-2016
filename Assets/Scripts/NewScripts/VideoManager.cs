﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]
public class VideoManager : MonoBehaviour {

    public MovieTexture movie;
    private AudioSource audio;


    // Use this for initialization
    void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        //audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (!movie.isPlaying)
        {
            SceneManager.LoadScene("salle_boss", LoadSceneMode.Single);
        }
	}
}
