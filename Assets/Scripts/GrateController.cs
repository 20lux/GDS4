using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateController : MonoBehaviour
{
    private AudioSource grateAudioSource;
    private Animator grateAnimator;

    void Awake()
    {
        grateAnimator = GetComponent<Animator>();
        grateAudioSource = GetComponent<AudioSource>();
    }

    public void OpenGrate()
    {
        grateAnimator.SetBool("openGrate", true);
        grateAudioSource.Play();
    }
}
