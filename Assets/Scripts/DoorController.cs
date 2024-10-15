using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Properties")]
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource doorAudio;
    [SerializeField] private AudioClip[] doorSounds;
    public DoorAnimations door;
    public bool isManualDoor = false;
    private bool isDoorOpen = false;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorAnimations>();
        doorAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" && !isDoorOpen)
        {
            if (!isManualDoor)
            {
                Open();
                isDoorOpen = true;
            }    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isDoorOpen)
        {
            if (!isManualDoor)
            {
                Close();
                isDoorOpen = false;
            }    
        }
    }

    public void Open()
    {
        door.OpenAnimation();
        doorAudio.clip = doorSounds[0];
        doorAudio.Play();
    }

    public void Close()
    {
        door.CloseAnimation();
        doorAudio.time = 1f;
        doorAudio.clip = doorSounds[1];
        doorAudio.Play();
    }

    public void MakeDoorAuto()
    {
        isManualDoor = false;
    }
}
