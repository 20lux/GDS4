using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Video;


public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] videos;
    public int videoClipIndex;
    private double duration;
    private bool isPlaying;
    public bool beingHeld;

    private void Start()
    {
        player.clip = videos[0];
        player.Play();
    }

    public void playVideo()
    {
        if (isPlaying == false && beingHeld == true)
        {
            player.clip = videos[videoClipIndex];
            player.Play();
            duration = videos[videoClipIndex].length;
            isPlaying = true;
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        
    }
    private void Update()
    {
        if (duration >= 0 && isPlaying == true)
        {
            duration -= Time.deltaTime;
        }
        else if (duration < 0 && isPlaying == true)
        {
            player.clip = videos[0];
            player.Play();
            isPlaying = false;
            GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        playVideo();
    }

}
