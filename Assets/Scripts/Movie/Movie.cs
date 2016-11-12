﻿using UnityEngine;
using System.Collections;

public class Movie : MonoBehaviour {

    public string _movieFile;

	// Use this for initialization
	void Start () {

        StartCoroutine(moviePlay(_movieFile));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator moviePlay(string movieFile)
    {
        string movieTexturePath = Application.streamingAssetsPath + "/" + movieFile;
        string url = "file://" + movieTexturePath;
        WWW movie = new WWW(url);

        while (!movie.isDone)
        {
            yield return null;
        }

        MovieTexture movieTexture = movie.movie;

        while (!movieTexture.isReadyToPlay)
        {
            yield return null;
        }

        var renderer = GetComponent<MeshRenderer>();
        renderer.material.mainTexture = movieTexture;

        movieTexture.loop = true;
        movieTexture.Play();

        var audioSource = GetComponent<AudioSource>();
        audioSource.loop = movieTexture.audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
