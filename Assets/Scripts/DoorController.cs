using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Is this a grate?")]
    public bool isGrate;
    [SerializeField] private GameObject doorGameObject;
    
    [Header("Door Properties (Not needed for grates)")]
    [SerializeField] private GameObject keyObject;
    private IDoor door;
    public bool isDoorLocked = true;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorAnimations>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isGrate)
        {
            if (other.tag == "Player")
            {
                if (!isDoorLocked)
                {
                    // Player entered collider
                    door.OpenDoor();
                }
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
                    // Player exited collider
                    door.CloseDoor();
                }
            }
        }        
    }

    public void OpenGrate()
    {
        door.OpenDoor();
    }
}
