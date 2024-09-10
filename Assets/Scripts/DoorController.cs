using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Is this a grate?")]
    public bool isGrate;
    [SerializeField] private GameObject doorGameObject;
    
    [Header("Door Properties (Not needed for grates)")]
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource doorAudio;
    [SerializeField] private AudioClip[] doorSounds;
    private IDoor door;
    public bool isDoorLocked = true;
    public bool isManualDoor = true;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorAnimations>();
        doorAudio = GetComponent<AudioSource>();
    }

    public void LiftButtonPress()
    {
        if (!isGrate && isManualDoor)
        {
            if (!isDoorLocked)
            {
                // Player entered collider
                door.OpenDoor();
                doorAudio.clip = doorSounds[0];
                doorAudio.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isGrate)
        {
            if (other.tag == "Player")
            {
                if (!isDoorLocked)
                {
                    door.CloseDoor();
                    doorAudio.clip = doorSounds[1];
                    doorAudio.Play();
                }
            }
        }        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isDoorLocked)
            {
                door.OpenDoor();
                doorAudio.clip = doorSounds[0];
                doorAudio.Play();
            }                   
        }
    }

    public void OpenGrate()
    {
        door.OpenDoor();
        doorAudio.clip = doorSounds[0];
        doorAudio.Play();
    }
}
