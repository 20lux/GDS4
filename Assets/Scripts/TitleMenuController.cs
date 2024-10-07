using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuController : MonoBehaviour
{
    [SerializeField] private AudioClip titleMusic;
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
        Initiate.Fade("Main", Color.black, fadeTime);
    }

    public void MainMenu()
    {
        audioSource.clip = buttonPress;
        audioSource.loop = false;
        audioSource.Play();
        waitForSound();
        Initiate.Fade("Title", Color.black, fadeTime);
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

        if (Input.GetKey(KeyCode.Space) && 
            SceneManager.GetActiveScene().name != "Main" &&
            SceneManager.GetActiveScene().name != "Title" &&
            SceneManager.GetActiveScene().name != "Credits")
        {
            Initiate.Fade("Credits", Color.black, fadeTime);
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
