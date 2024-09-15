using System;
using Assets.Diamondhenge.HengeVideoPlayer;
using NavKeypad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private Image playerCrosshair;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject grabCam;
    [SerializeField] private GameObject playerDrop;
    private LayerMask layerInteractable;
    private LayerMask ignoreRaycastLayer;
    private InteractableObject thisInteractableObject;
    private ArrowKeyConsoleInteract arrowKeyConsoleInteract;
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
                                InteractWithVideo();
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
                        Debug.Log("This is the end!");
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
                    // Only drop an object if not near a wall
                    thisInteractableObject.Drop(playerDrop.transform);
                }

                thisInteractableObject = null;
            }
        }
    }

#endregion

    public void InteractWithVideo()
    {
        var videoPlayer = thisInteractableObject.GetComponent<PlayVideo>();
        if (!videoPlayer.hengeVideo.isPlaying)
        {
            videoPlayer.hengeVideo.PlayVideo();
        }
        else
        {
            videoPlayer.hengeVideo.TogglePauseState();
        }
    }

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
            //Debug.Log("Highlighting object");
            playerCrosshair.color = Color.green;
        }
        else
        {
            playerCrosshair.color = Color.white;
        }
    }
}
