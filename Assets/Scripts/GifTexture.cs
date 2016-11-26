﻿using UnityEngine;
using System.Collections;

public class GifTexture : MonoBehaviour {

    public Texture[] textures;
    public GameObject obj;
    public float changeFrameSecond;
    private float dTime;
    private int frameNum;

    // Use this for initialization
    void Start()
    {
        dTime = 0.0f;
        frameNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime;
        if (changeFrameSecond < dTime)
        {
            dTime = 0.0f;
            frameNum++;
            if (frameNum >= textures.Length) frameNum = 0;
        }
        obj.GetComponent<Renderer>().material.SetTexture("_MainTex", textures[frameNum]);
    }

}
