using UnityEngine;

public class TechLabTarget : MonoBehaviour
{
    [SerializeField] private GameObject movingObject;
    [SerializeField] private Light[] lightsToEnable;
    [SerializeField] private GameObject[] particlesToEnable;
    [SerializeField] private AudioSource[] engineStartSounds;
    [SerializeField] private ButtonPress buttonPress;
    [SerializeField] private GameObject[] alarms;

    public ArrowKeyConsoleInteract[] associatedConsoleKeys;

    void Start()
    {
        for (int i = 0; i < lightsToEnable.Length; i++)
        {
            lightsToEnable[i].enabled = false;
        }
    }

    // Turn on engine sequence
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            movingObject.transform.SetParent(gameObject.transform);
            movingObject.transform.position = gameObject.transform.position;
            
            // Disable highlight on associated console
            for (int i = 0; i < associatedConsoleKeys.Length; i++)
            {
                associatedConsoleKeys[i].isPuzzleComplete = true;
            }

            // Switch lights on
            for (int i = 0; i < lightsToEnable.Length; i++)
            {
                lightsToEnable[i].enabled = true;
                if (lightsToEnable[i].TryGetComponent(out LightFlickerer lightFlickerer))
                {
                    lightFlickerer.isOn = true;
                }
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
                var ps = particlesToEnable[i].GetComponent<ParticleSystem>().emission;
                ps.rateOverTime = 100;
            }

            // Play engine startup and running sounds
            for (int i = 0; i < engineStartSounds.Length; i++)
            {
                if (!engineStartSounds[i].isPlaying)
                {
                    engineStartSounds[i].enabled = true;
                    engineStartSounds[i].Play();
                }
            }

            // Engine room lift button active
            buttonPress.Activate();
        }
    }
}
