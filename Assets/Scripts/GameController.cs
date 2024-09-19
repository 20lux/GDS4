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
    private bool isOtherEnding = false;

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

    public void BridgeEnding()
    {
        isOtherEnding = true;
        audioSource.PlayOneShot(bridgeEndingClip);
        Initiate.Fade("Bridge_Ending", Color.white, 5f);
    }

    public void SingularityEnding()
    {
        if (!isOtherEnding)
        {
            Initiate.Fade("Singularity_Ending", Color.red, 5f);
        }
    }

    public void AirlockEnding()
    {
        isOtherEnding = true;
        Initiate.Fade("Airlock_Ending", Color.black, 5f);
    }
}
