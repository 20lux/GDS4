using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonDrifter>() != null)
        {
            // Player entered collider
            door.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonDrifter>() != null)
        {
            // Player exited collider
            door.CloseDoor();
        }        
    }
}
