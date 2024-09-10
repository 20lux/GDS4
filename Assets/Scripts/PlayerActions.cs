using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private Camera playerCam;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private GameObject grabCam;
    [SerializeField] private GameObject playerDrop;
    private LayerMask layerInteractable;
    private LayerMask ignoreRaycastLayer;
    private InteractableObject thisInteractableObject;
    private ArrowKeyConsoleInteract arrowKeyConsoleInteract;
 
    void Start()
    {
        playerCam = Camera.main;
        layerInteractable = LayerMask.GetMask("InteractObjects");
        HighlightObject(false);
    }

    public void Update()
    {
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red);

        // when looking at interactable object, highlight
        var ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Physics.Raycast(ray, interactDistance, layerInteractable))
        {
            HighlightObject(true);
        }
        else
        {
            HighlightObject(false);
        }

        PlayerInteract();
    }

#region Player Interact
    public void PlayerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            if (thisInteractableObject == null)
            {
                if (Physics.Raycast(playerCam.transform.position, 
                                    playerCam.transform.forward, out RaycastHit hit, 
                                    interactDistance, 
                                    layerInteractable))
                {
                    if (hit.collider.TryGetComponent(out thisInteractableObject))
                    {
                        switch (thisInteractableObject.objectType)
                        {
                            case InteractableObject.ObjectType.None:
                                break;
                            case InteractableObject.ObjectType.Key:
                                thisInteractableObject.Grab(grabCam);
                                break;
                            case InteractableObject.ObjectType.GrabObject:
                                thisInteractableObject.Grab(grabCam);
                                break;                              
                            case InteractableObject.ObjectType.Console:
                                break;
                        }
                    }
                    
                    if (hit.collider.TryGetComponent(out arrowKeyConsoleInteract))
                    {
                        arrowKeyConsoleInteract.KeyInteract();
                    }

                    if (hit.collider.TryGetComponent(out ButtonPress button))
                    {
                        button.Press();
                    }
                }
            }
            else
            {
                // Checking if interactable
                if (Physics.Raycast(playerCam.transform.position, 
                                    playerCam.transform.forward, 
                                    out RaycastHit hit, 
                                    interactDistance, 
                                    layerInteractable))
                {
                    switch (thisInteractableObject.objectType)
                    {
                        case InteractableObject.ObjectType.Key:
                            thisInteractableObject.UseKey();
                            break;
                    }

                    // if (hit.collider.tag == "Console")
                    // {
                    //     Debug.Log("Using console!");
                    //     switch (thisInteractableObject.objectType)
                    //     {
                    //         case InteractableObject.ObjectType.Cartridge:
                    //             Debug.Log("Putting in cartridge!");
                    //             thisInteractableObject.UseConsole(thisInteractableObject);
                    //             break;
                    //     }
                    // }
                }
                // else if (Physics.Raycast(playerCam.transform.position, 
                //                     playerCam.transform.forward, 
                //                     out RaycastHit wallHit, 
                //                     interactDistance))
                // {
                //     if (wallHit.collider.tag == "Wall")
                //     {
                //         // Play a sound
                //     }
                // }
                else
                {
                    // Only drop an object if not near a wall
                    thisInteractableObject.Drop(playerDrop.transform);
                }

                thisInteractableObject = null;
            }
        }
    }

    // Use for video or audio consoles
    public void InteractingWithObject()
    {
        
    }

#endregion

#region Inventory
    // Use for inventory
    public void FreeMouse()
    {
        Debug.Log("Freeing mouse!");
    }

    public void LockMouse()
    {
        Debug.Log("Locking mouse!");
    }

    public void UseConsole()
    {
        FreeMouse();
        Debug.Log("Using console!");
    }

    public void CloseConsole()
    {
        LockMouse();
        Debug.Log("Closing console!");
    }
#endregion
    // TODO: Change to icons
    public void HighlightObject(bool isActive)
    {
        if (isActive)
        {
            UIText.text = "Press [E] to interact";
            //Debug.Log("Highlighting object");
        }
        else
        {
            UIText.text = " ";
        }
    }
}
