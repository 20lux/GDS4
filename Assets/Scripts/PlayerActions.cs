using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI UIText;
    private InteractableObject interactableObject;
    private Transform playerLook;
    [HideInInspector] public Transform PlayerLook => playerLook;

    private RaycastHit hitInfo;
    private Ray ray;
    
    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
        ray = cam.ScreenPointToRay(Vector3.one * 0.5f);
        ClearUI();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.yellow);
    }

    public void PickUpObject()
    {
        if (Physics.Raycast(ray, out hitInfo))
        {
            Collider collider = hitInfo.collider;
            if (collider.TryGetComponent(out interactableObject))
            {
                interactableObject.ObjectAction(gameObject);
            }
        }
    }

    public void CheckIfHolding()
    {

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
}
