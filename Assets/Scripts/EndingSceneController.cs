using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneController : MonoBehaviour
{
    [SerializeField] private AudioClip endingMusic;
    [SerializeField] private AudioClip buttonPress;
    [SerializeField] private AudioSource audioSource;
    public float fadeTime = 15f;

    void Awake()
    {
        gameObject.GetComponent<CursorLockControl>().UnlockCursor();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = endingMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void MainMenu()
    {
        audioSource.clip = buttonPress;
        audioSource.loop = false;
        audioSource.Play();
        waitForSound();
        Loader.Load(Loader.Scene.Title);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator waitForSound()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
