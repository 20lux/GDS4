using Unity.VisualScripting;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private GameObject keyObject;
    private IDoor door;
    private bool isLocked = true;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonDrifter>() != null)
        {
            if (!isLocked)
            {
                // Player entered collider
                door.OpenDoor();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonDrifter>() != null)
        {
            if (!isLocked)
            {
                // Player exited collider
                door.CloseDoor();
            }
        }        
    }

    private void Update()
    {
        if (keyObject != null)
        {
            if (keyObject.TryGetComponent(out InteractableObject keyInteract))
            {
                if (!keyInteract.isLocked)
                {
                    Debug.Log("Unlocking door!");
                    isLocked = false;
                }
            }
        }
    }
}
