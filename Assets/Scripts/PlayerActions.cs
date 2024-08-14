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
    private Transform playerLook;
    [SerializeField] private LayerMask layerToIgnoreRaycast;
    [SerializeField] private LayerMask layerInteractable;
 
    void Start()
    {
        cam = Camera.main;
        layerToIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        HighlightObject(false);
    }

    public void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red);

        var ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactDistance, layerInteractable))
        {
            HighlightObject(true);
        }
        else
        {
            HighlightObject(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, 
                            out RaycastHit hit, interactDistance, layerInteractable))
            {
                Debug.DrawLine(cam.transform.position, hit.point, Color.green, 1f);
                Debug.Log(hit.transform);

                if (hit.transform.TryGetComponent(out interactableObject))
                {
                    Debug.Log("Trying to pick up interactable object!");

                    if (interactableObject)
                    {
                        PickItem(interactableObject);
                    }
                }
            }
        }
    }
    
    public void CheckIfHolding(InteractableObject interactableObject)
    {
        Debug.Log("Checking if holding something");
        if (interactableObject)
        {
            PlaceItem(interactableObject);
        }
        else
        {
            PickItem(interactableObject);
        }
    }

    // Picks up item
    public void PickItem(InteractableObject interactedObject)
    {
        Debug.Log("Picking up item!");

        interactedObject = interactableObject;
        interactedObject.gameObject.layer = layerToIgnoreRaycast;
        interactedObject.rb.isKinematic = true;
        interactedObject.transform.SetParent(playerLook);
        interactedObject.transform.localPosition = Vector3.zero;
        //interactedObject.transform.localRotation = Quaternion.identity;
    }

    // Places item in a set position in scene
    public void PlaceItem(InteractableObject placeObject)
    {
        placeObject = null;
        placeObject.rb.isKinematic = false;
        placeObject.transform.localPosition = Vector3.zero;
        //placeObject.transform.localRotation = Quaternion.identity;
    }

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
            UIText.text = "Press [E] to interact";
            Debug.Log("Highlighting object");
        }
        else
        {
            UIText.text = " ";
        }
    }
}
