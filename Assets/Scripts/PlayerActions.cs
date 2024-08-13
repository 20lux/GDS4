using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 4f;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI UIText;
    public InteractableObject interactableObject;
    private Transform playerLook;

    private RaycastHit hitInfo;
    private Ray ray;
    [HideInInspector] public int layerToIgnoreRaycast;
    [HideInInspector] public int layerInteractable;
 
    void Start()
    {
        cam = Camera.main;
        layerToIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        layerInteractable = LayerMask.NameToLayer("InteractObjects");
        ray = cam.ViewportPointToRay(Vector3.one * 0.5f);
        ClearUI();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.yellow);

        if (Physics.Raycast(ray, out hitInfo, interactDistance, layerInteractable))
        {
            HighlightObject();
        }
    }

    public void Interact()
    {
        if (gameObject.TryGetComponent(out interactableObject))
        {
            //Check if player picked some item already
            if (interactableObject)
            {
                CheckIfHolding();
            }
            else
            {
                NotHoldingAnything();
            }
        }
    }

    public void CheckIfHolding()
    {
        //Check if ray hits something
        if (Physics.Raycast(ray, out hitInfo, interactDistance))
        {
            //If ray does hit tag "Placeable", grab held item and find child within object hit with ray
            if (hitInfo.collider.tag == "Placeable")
            {
                PlaceItem(interactableObject);
            }     
        }
    }

    public void PickUpObject()
    {
        if (Physics.Raycast(ray, out hitInfo, interactDistance))
        {
            if (hitInfo.collider.TryGetComponent(out interactableObject))
            {
                Debug.Log("Attempting to interact!");
            }
        }
        else
        {
            interactableObject = null;
        }
    }

    // Picks up item
    public void PickItem(InteractableObject interactedObject)
    {
        interactedObject = interactableObject;
        interactedObject.gameObject.layer = layerToIgnoreRaycast;

        interactedObject.rb.isKinematic = true;

        interactedObject.transform.SetParent(playerLook);

        interactedObject.transform.localPosition = Vector3.zero;

        interactedObject.transform.localRotation = Quaternion.Euler(-90, 180, 0);
    }

    // Places item in a set position in scene
    public void PlaceItem(InteractableObject placeObject)
    {
        placeObject = null;

        placeObject.rb.isKinematic = false;

        placeObject.transform.localPosition = Vector3.zero;

        placeObject.transform.localRotation = Quaternion.Euler(-90, 180, 0);
    }

    public void NotHoldingAnything()
    {
        //Shoot ray to find object to pick
        if (Physics.Raycast(ray, out hitInfo, interactDistance))
        {
            //Check if object is pickable
            var pickable = hitInfo.transform.GetComponent<InteractableObject>();

            //If object has PickableItem class
            if (pickable)
            {
                PickItem(pickable);
            }
        }
    }

    public void HighlightObject()
    {
        if (interactableObject)
        {
            UIText.text = "Press [E] to interact";
            Debug.Log("Highlighting object");
        }
    }

    public void ClearUI()
    {
        UIText.text = " ";
    }

    // Grab names from interactive objects in surrounding areas
    // void FixedUpdate()
    // {
    //     Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactDistance, mask);

    //     if (colliderArray.Length > 0)
    //     {
    //         foreach (Collider collider in colliderArray)
    //         {
    //             if (collider.gameObject.TryGetComponent(out interactableObject))
    //             {
    //                 HighlightObject(interactableObject);
    //             }
    //         }
    //     }
    //     else
    //     {
    //         ClearUI();
    //     }
    // }

    // public InteractableObject GetInteractableObject()
    // {
    //     List<InteractableObject> interactableObjectList = new List<InteractableObject>();

    //     Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactDistance);
    //     foreach (Collider collider in colliderArray)
    //     {
    //         if (collider.TryGetComponent(out interactableObject))
    //         {
    //             interactableObjectList.Add(interactableObject);
    //         }
    //     }

    //     // gets closest interactable object in the array
    //     InteractableObject closestInteractable = null;
    //     foreach (InteractableObject interactableObject in interactableObjectList)
    //     {
    //         if (!closestInteractable)
    //         {
    //             closestInteractable = interactableObject;
    //         }
    //         else
    //         {
    //             if (Vector3.Distance(transform.position, interactableObject.transform.position) <
    //                 Vector3.Distance(transform.position, closestInteractable.transform.position))
    //                 {
    //                     closestInteractable = interactableObject;
    //                 }

    //         }
    //     }

    //     return closestInteractable;
    // }

    // public void InteractWithObject()
    // {
    //     RaycastHit hit;

    //     if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactDistance, mask))
    //     {
    //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //         Debug.Log("Did hit");
    //     }
    //     else
    //     {
    //         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white, mask);
    //         Debug.Log("Did not hit");    
    //     }
    // }
}
