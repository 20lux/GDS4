using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Asset Links")]
    public PlayerActions playerActions;


    [Header("Singularity Ending Properties")]
    public UnityEvent singularityEndingStart;
    public UnityEvent countdownStart;
    private bool isOtherEnding = false;

    // Countdown timer to decide ending sequence
    private float timeRemaining = 60;

    void Start()
    {
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
            countdownStart?.Invoke();
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            singularityEndingStart?.Invoke();
            SingularityEnding();
        }
    }

    public void BridgeEnding()
    {
        isOtherEnding = true;
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
