using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Asset Links")]
    public PlayerActions playerActions;


    [Header("Bridge Ending Properties")]
    [SerializeField] private AudioClip bridgeEndingClip;
    AudioSource audioSource;

    // Countdown timer to decide ending sequence
    private float timeRemaining = 60;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerActions = FindObjectOfType<PlayerActions>();
    }

    void Update()
    {
        if (playerActions.isEnd)
        {
            BeginCountDown();
        }

        // For debugging
        if (Input.GetKey(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    void BeginCountDown()
    {
        if (timeRemaining > 0)
        {
            timeRemaining += Time.deltaTime;
        }
        else
        {
            SingularityEnding();
        }
    }

    void BridgeEnding()
    {
        audioSource.clip = bridgeEndingClip;
        audioSource.loop = false;
        audioSource.Play();
        waitForSound();
        Loader.Load(Loader.Scene.Bridge_Ending);
    }

    void SingularityEnding()
    {
        Loader.Load(Loader.Scene.Singularity_Ending);
    }

    IEnumerator waitForSound()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
