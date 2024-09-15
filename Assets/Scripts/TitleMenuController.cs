using System.Collections;
using UnityEngine;

public class TitleMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip titleMusic;
    [SerializeField] private AudioClip buttonPress;
    [SerializeField] private AudioSource audioSource;
    public float fadeTime = 15f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = titleMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StartGame()
    {
        audioSource.clip = buttonPress;
        audioSource.loop = false;
        audioSource.Play();
        waitForSound();
        Loader.Load(Loader.Scene.Main);
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

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    IEnumerator waitForSound()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
