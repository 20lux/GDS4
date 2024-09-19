using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Player Sound Properties")]
    public AudioSource playerAudioSource;
    public AudioClip[] thinkingSounds;
    public AudioClip[] needMoreDataSounds;
    public AudioClip[] lockedSounds;
    public AudioClip[] screwdriverSounds;
    public AudioClip[] progressionSounds;
    public AudioClip[] movePlayer;

    void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayThinkingSounds()
    {
        var i = Random.Range(0, thinkingSounds.Length);
        playerAudioSource.clip = thinkingSounds[i];
        playerAudioSource.Play();
    }

    public void PlayMoreDataSounds()
    {
        var i = Random.Range(0, needMoreDataSounds.Length);
        playerAudioSource.clip = needMoreDataSounds[i];
        playerAudioSource.Play();
    }

    public void PlayLockedSounds()
    {
        var i = Random.Range(0, lockedSounds.Length);
        playerAudioSource.clip = lockedSounds[i];
        playerAudioSource.Play();
    }

    public void PlayScrewdriverSounds()
    {
        var i = Random.Range(0, screwdriverSounds.Length);
        playerAudioSource.clip = screwdriverSounds[i];
        playerAudioSource.Play();
    }

    public void PlayProgressionSounds()
    {
        var i = Random.Range(0, progressionSounds.Length);
        playerAudioSource.clip = progressionSounds[i];
        playerAudioSource.Play();
    }

    public void PlayMovePlayerSounds()
    {
        var i = Random.Range(0, movePlayer.Length);
        playerAudioSource.clip = movePlayer[i];
        playerAudioSource.Play();
    }
}
