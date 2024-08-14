using System;
using TMPro;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 4f;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI UIText;
    public InteractableObject interactableObject;
    private RaycastHit hitInfo;
    private Ray ray;
    private Transform playerLook;
    [SerializeField] private LayerMask layerToIgnoreRaycast;
    [SerializeField] private LayerMask layerInteractable;
 
    void Start()
    {
        cam = Camera.main;
        layerToIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        ray = cam.ViewportPointToRay(Vector3.one * 0.5f);
        HighlightObject(false);
    }

    public void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, 
                            out RaycastHit hit, interactDistance, layerInteractable))
            {
                Debug.DrawLine(cam.transform.position, hit.point, Color.green, 1f);
                Debug.Log(hit.transform);
            }
        }

        // if (gameObject.TryGetComponent(out interactableObject))
        // {
        //     //Check if player picked some item already
        //     if (interactableObject)
        //     {
        //         CheckIfHolding();
        //     }
        //     else
        //     {
        //         NotHoldingAnything();
        //     }
        // }
    }


    // public void PickUpObject()
    // {
    //     if (Physics.Raycast(ray, out hitInfo, interactDistance))
    //     {
    //         if (hitInfo.collider.TryGetComponent(out interactableObject))
    //         {
    //             Debug.Log("Attempting to interact!");
    //         }
    //     }
    //     else
    //     {
    //         interactableObject = null;
    //     }
    // }
    
    // public void CheckIfHolding()
    // {
    //     //Check if ray hits something
    //     if (Physics.Raycast(ray, out hitInfo, interactDistance))
    //     {
    //         //If ray does hit tag "Placeable", grab held item and find child within object hit with ray
    //         if (hitInfo.collider.tag == "Placeable")
    //         {
    //             PlaceItem(interactableObject);
    //         }     
    //     }
    // }

    // // Picks up item
    // public void PickItem(InteractableObject interactedObject)
    // {
    //     interactedObject = interactableObject;
    //     interactedObject.gameObject.layer = layerToIgnoreRaycast;

    //     interactedObject.rb.isKinematic = true;

    //     interactedObject.transform.SetParent(playerLook);

    //     interactedObject.transform.localPosition = Vector3.zero;

    //     interactedObject.transform.localRotation = Quaternion.Euler(-90, 180, 0);
    // }

    // // Places item in a set position in scene
    // public void PlaceItem(InteractableObject placeObject)
    // {
    //     placeObject = null;

    //     placeObject.rb.isKinematic = false;

    //     placeObject.transform.localPosition = Vector3.zero;

    //     placeObject.transform.localRotation = Quaternion.Euler(-90, 180, 0);
    // }

    // public void NotHoldingAnything()
    // {
    //     //Shoot ray to find object to pick
    //     if (Physics.Raycast(ray, out hitInfo, interactDistance))
    //     {
    //         //Check if object is pickable
    //         var pickable = hitInfo.transform.GetComponent<InteractableObject>();

    //         //If object has PickableItem class
    //         if (pickable)
    //         {
    //             PickItem(pickable);
    //         }
    //     }
    // }

    public void HighlightObject(bool isActive)
    {
        if (isActive)
        {
            if (interactableObject)
            {
                UIText.text = "Press [E] to interact";
                Debug.Log("Highlighting object");
            }
        }
        else
        {
            UIText.text = " ";
        }
    }
}
