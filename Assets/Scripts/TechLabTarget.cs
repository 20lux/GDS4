using UnityEngine;

public class TechLabTarget : MonoBehaviour
{
    [SerializeField] private GameObject movingObject;
    [SerializeField] private Light[] lightsToEnable;
    [SerializeField] private GameObject[] particlesToEnable;
    [SerializeField] private AudioSource[] engineStartSounds;
    [SerializeField] private GameObject doorToOpenTrigger;
    [SerializeField] private GameObject[] alarms;

    void Start()
    {
        for (int i = 0; i < lightsToEnable.Length; i++)
        {
            lightsToEnable[i].enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            movingObject.transform.SetParent(gameObject.transform);
            movingObject.transform.position = gameObject.transform.position;
            
            for (int i = 0; i < lightsToEnable.Length; i++)
            {
                lightsToEnable[i].enabled = true;
                if (lightsToEnable[i].TryGetComponent(out LightFlickerer lightFlickerer))
                {
                    lightFlickerer.isOn = true;
                }
            }

            for (int i = 0; i < alarms.Length; i++)
            {
                alarms[i].GetComponent<Alarm>().thisLight.enabled = false;
                alarms[i].GetComponent<Alarm>().audioSource.Stop();
            }

            for (int i = 0; i < particlesToEnable.Length; i++)
            {
                var ps = particlesToEnable[i].GetComponent<ParticleSystem>().emission;
                ps.rateOverTime = 100;
            }

            for (int i = 0; i < engineStartSounds.Length; i++)
            {
                if (!engineStartSounds[i].isPlaying)
                {
                    engineStartSounds[i].enabled = true;
                    engineStartSounds[i].Play();
                }
            }

            if (doorToOpenTrigger.TryGetComponent(out DoorController doorController))
            {
                doorController.isDoorLocked = false;
            }
        }
    }
}
