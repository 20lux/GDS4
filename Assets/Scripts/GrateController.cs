using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateController : MonoBehaviour
{
    [Header("Grate Properties")]
    [SerializeField] private GameObject grateGameObject;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource grateAudioSource;
    public GrateAnimation grateAnimation;
    private Animator grateAnimator;

    void Awake()
    {
        grateAnimator = GetComponent<Animator>();
    }

    public void OpenGrate()
    {
        grateAnimator.SetBool("openGrate", true);
        grateAudioSource.Play();
    }
}
