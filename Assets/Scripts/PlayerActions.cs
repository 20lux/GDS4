using System.Collections.Generic;
using NavKeypad;
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
    private bool isHolding = false;
    public List<int> clipIndex;

    // Properties of objects that the player interacts with
    private LayerMask layerInteractable;
    private InteractableObject item;

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
        if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            if (item == null)
            {
                if (Physics.Raycast(playerCam.transform.position, 
                                    playerCam.transform.forward, out RaycastHit hit, 
                                    interactDistance))
                {
                    if (hit.collider.TryGetComponent(out item))
                    {
                        switch (item.objectType)
                        {
                            case InteractableObject.ObjectType.None:
                                Destroy(item.gameObject);
                                break;
                            case InteractableObject.ObjectType.Key:
                                item.Grab(grabCam);
                                isHolding = true;
                                break;
                            case InteractableObject.ObjectType.GrabObject:
                                item.Grab(grabCam);
                                isHolding = true;
                                break;
                            case InteractableObject.ObjectType.ConsoleCartridge:
                                if (item.TryGetComponent(out cartridgeInteract index))
                                {
                                    clipIndex.Add(index.clipIndex);
                                }
                                Destroy(item.gameObject);
                                isHolding = false;
                                break;                            
                        }
                    }
                    
                    // Can't interact with objects if you're holding an object
                    // You must drop of the cartridge first
                    if (!isHolding)
                    {
                        if (hit.collider.TryGetComponent(out ArrowKeyConsoleInteract arrowKeyConsoleInteract))
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

                        if (hit.collider.TryGetComponent(out PlayVideo videoPlayer))
                        {
                            Debug.Log("Clicking on player!");
                            switch (videoPlayer.clipID)
                            {
                                case PlayVideo.clipIndex.BlueCart:
                                    if (clipIndex.Contains(0))
                                    {
                                        videoPlayer.PlayCartridge(0);
                                    }
                                    break;
                                case PlayVideo.clipIndex.GreenCart:
                                    if (clipIndex.Contains(1))
                                    {
                                        videoPlayer.PlayCartridge(1);
                                    }
                                    break;
                                case PlayVideo.clipIndex.CreamCart:
                                    if (clipIndex.Contains(2))
                                    {
                                        videoPlayer.PlayCartridge(2);
                                    }
                                    break;
                                case PlayVideo.clipIndex.RedCart:
                                    if (clipIndex.Contains(3))
                                    {
                                        videoPlayer.PlayCartridge(3);
                                    }
                                    break;
                                case PlayVideo.clipIndex.PurpleCart:
                                    if (clipIndex.Contains(4))
                                    {
                                        videoPlayer.PlayCartridge(4);
                                    }
                                    break;
                                case PlayVideo.clipIndex.PinkCart:
                                    if (clipIndex.Contains(5))
                                    {
                                        videoPlayer.PlayCartridge(5);
                                    }
                                    break;
                                case PlayVideo.clipIndex.WhiteCart:
                                    if (clipIndex.Contains(6))
                                    {
                                        videoPlayer.PlayCartridge(6);
                                    }
                                    break;
                                case PlayVideo.clipIndex.OrangeCart:
                                    if (clipIndex.Contains(7))
                                    {
                                        videoPlayer.PlayCartridge(7);
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                // Checking if interactable, otherwise drop what we're holding
                if (Physics.Raycast(playerCam.transform.position, 
                                    playerCam.transform.forward, 
                                    out RaycastHit hit, 
                                    interactDistance, 
                                    layerInteractable))
                {
                    switch (item.objectType)
                    {
                        case InteractableObject.ObjectType.Key:
                            item.UseKey();
                            break;
                    }

                    item = null;
                }
                else
                {
                    item = null;
                    isHolding = false;
                }
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
