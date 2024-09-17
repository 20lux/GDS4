using System;
using System.Collections.Generic;
using Assets.Diamondhenge.HengeVideoPlayer;
using NavKeypad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [Tooltip("Sets interaction distance of player")]
    [SerializeField] private float interactDistance = 10f;
    [Tooltip("Changes crosshair image")]
    [SerializeField] private Image playerCrosshair;
    [Tooltip("Player camera object")]
    [SerializeField] private Camera playerCam;
    [Tooltip("Composite camera that shows object the player is currently holding")]
    [SerializeField] private GameObject grabCam;
    [Tooltip("Drop location for objects that player has dropped")]
    [SerializeField] private GameObject playerDrop;

    // Properties of objects that the player interacts with
    private LayerMask layerInteractable;
    private InteractableObject thisInteractableObject;

    // Used for controlling arrow keys for arrow key puzzle
    private ArrowKeyConsoleInteract arrowKeyConsoleInteract;

    // Used for keeping track of cartridge collections
    private List<int> cartridgeCollection;
    [HideInInspector] public List<int> CartridgeCollection => cartridgeCollection;

    // Ending detection
    // TODO: move to game controller
    [HideInInspector] public bool isEnd = false;
 
    void Start()
    {
        playerCam = Camera.main;
        layerInteractable = LayerMask.GetMask("InteractObjects");
        HighlightObject(false);
    }

    public void Update()
    {
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red);

        // when looking at interactable object, change crosshair colour
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
        // If the player presses E or presses left mouse button,
        // interact with an object on the interactable layer and
        // do things depending on what type of object it is
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
                                thisInteractableObject.InteractWithVideo();
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

                    if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                    {
                        keypadButton.PressButton();
                    }

                    if (hit.collider.TryGetComponent(out BridgeEnding bridgeEnding))
                    {
                        isEnd = true;
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
                }
                else
                {
                    //thisInteractableObject.Drop(playerDrop.transform);
                }

                thisInteractableObject = null;
            }
        }
    }

#endregion

    // Differentiate between interactive objects
    // and non-interactive objects
    public void HighlightObject(bool isActive)
    {
        if (isActive)
        {
            playerCrosshair.color = Color.white;
        }
        else
        {
            playerCrosshair.color = Color.grey;
        }
    }
}
