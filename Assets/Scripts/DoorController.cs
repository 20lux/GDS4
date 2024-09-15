using System.Collections;
using UnityEditor.Build.Content;
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
    public int timeToClose = 5;
    public bool isOpen = false;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorAnimations>();
        doorAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isManualDoor && !isOpen)
            {
                Open();
            }    
        }
    }

    public void Open()
    {
        isOpen = true;
        door.OpenDoor();
        doorAudio.time = 2f;
        doorAudio.clip = doorSounds[0];
        doorAudio.Play();
    }
}
