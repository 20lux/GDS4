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
    public bool isDoorLocked;
    public bool doorNeedsKey;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorAnimations>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isGrate)
        {
            if (other.GetComponent<FirstPersonDrifter>() != null)
            {
                if (!isDoorLocked || doorNeedsKey)
                {
                    // Player entered collider
                    door.OpenDoor();
                }
                else if (!doorNeedsKey)
                {
                    door.OpenDoor();
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isGrate)
        {
            if (other.GetComponent<FirstPersonDrifter>() != null)
            {
                if (!isDoorLocked || doorNeedsKey)
                {
                    // Player exited collider
                    door.CloseDoor();
                }
                else if (!doorNeedsKey)
                {
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
