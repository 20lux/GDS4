using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Asset Links")]
    public PlayerActions playerActions;


    [Header("Singularity Ending Properties")]
    public UnityEvent singularityEndingStart;
    public UnityEvent countdownStart;
    public TextMeshProUGUI countdownText;
    private bool isOtherEnding = false;

    [Header("Engine Start Up Properties")]
    public Light[] lightsToEnable;
    public GameObject[] particlesToEnable;
    public AudioSource[] engineStartSounds;
    public ButtonPress buttonPress;
    public GameObject[] alarms;

    // Countdown timer to decide ending sequence
    private float timeRemaining = 60;

    void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
        countdownText.text = " ";
        ShipEngineDisabled();
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
            countdownText.text = timeRemaining.ToString();
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
        Initiate.Fade("Bridge_Ending", Color.white, 60f);
    }

    public void SingularityEnding()
    {
        if (!isOtherEnding)
        {
            Initiate.Fade("Singularity_Ending", Color.red, 60f);
        }
    }

    public void AirlockEnding()
    {
        isOtherEnding = true;
        Initiate.Fade("Airlock_Ending", Color.black, 5f);
    }

    public void ShipEngineStart()
    {
            // Switch lights on
            for (int i = 0; i < lightsToEnable.Length; i++)
            {
                lightsToEnable[i].enabled = true;
            }

            // Turn off alarms
            for (int i = 0; i < alarms.Length; i++)
            {
                alarms[i].GetComponent<Alarm>().thisLight.enabled = false;
                alarms[i].GetComponent<Alarm>().audioSource.Stop();
            }

            // Fire up engine particles
            for (int i = 0; i < particlesToEnable.Length; i++)
            {
                var emission = particlesToEnable[i].GetComponent<ParticleSystem>().emission;
                emission.enabled = true;
            }

            // Play engine startup and running sounds
            for (int i = 0; i < engineStartSounds.Length; i++)
            {
                if (!engineStartSounds[i].isPlaying)
                {
                    engineStartSounds[i].Play();
                }
            }

            // Engine room lift button active
            buttonPress.Activate();
    }

    public void ShipEngineDisabled()
    {
        for (int i = 0; i < lightsToEnable.Length; i++)
        {
            lightsToEnable[i].enabled = false;
        }

        for (int i = 0; i < particlesToEnable.Length; i++)
        {
            var emission = particlesToEnable[i].GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
    }
}
