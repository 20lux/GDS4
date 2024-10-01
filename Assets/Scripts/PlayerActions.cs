using System.Collections.Generic;
using NavKeypad;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [Tooltip("Sets interaction distance of player")]
    [SerializeField] private float interactDistance = 10f;
    [Tooltip("Player camera object")]
    [SerializeField] private Camera playerCam;
    [Tooltip("Composite camera that shows object the player is currently holding")]
    [SerializeField] private GameObject grabCam;
    [Tooltip("Drop location for objects that player has dropped")]
    private bool isHolding = false;
    public List<int> clipIndex;
    public List<int> leverComboInput;
    private HighlightObjectController highlightObjectController;

    // Properties of objects that the player interacts with
    private LayerMask layerInteractable;
    // private LayerMask layerInspect;
    // private LayerMask layerGrab;
    // private LayerMask layerLock;
    private InteractableObject item;
 
    void Awake()
    {
        playerCam = Camera.main;
        layerInteractable = LayerMask.GetMask("InteractObjects");
        // layerInspect = LayerMask.GetMask("Inspect");
        // layerGrab = LayerMask.GetMask("Grab");
        // layerLock = LayerMask.GetMask("Lock");
        highlightObjectController = GetComponent<HighlightObjectController>();
    }

    public void Update()
    {
        #region Highlight
        if (Physics.Raycast(transform.position, 
                            transform.forward, 
                            out RaycastHit hit, 
                            interactDistance))
        {
            if (hit.collider.CompareTag("Inspect"))
            {
                highlightObjectController.Inspect();
            }
            else if (hit.collider.CompareTag("Grab"))
            {
                highlightObjectController.Grab();
            }
            else if (hit.collider.CompareTag("Lock"))
            {
                highlightObjectController.Lock();
            }
            else
            {
                highlightObjectController.CrosshairInactive();
            }
        }
        #endregion

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
                                    interactDistance, layerInteractable))
                {
                    #region Interacting
                    if (hit.collider.TryGetComponent(out item))
                    {
                        switch (item.objectType)
                        {
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
                                item.Grab(grabCam);
                                isHolding = false;
                                break;
                        }
                    }
                    #endregion

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

                        if (hit.collider.TryGetComponent(out SoundEvent soundEvent))
                        {
                            soundEvent.PlaySoundEvent();
                        }

                        if (hit.collider.TryGetComponent(out TapePlayerController tapePlayer))
                        {
                            tapePlayer.PlayTape();
                        }

                        if (hit.collider.TryGetComponent(out BridgeEnding bridgeEnding))
                        {
                            Debug.Log("Interacting with bridge console");
                            bridgeEnding.PlayBridgeEnding();
                        }

                        if (hit.collider.TryGetComponent(out VideoConsole videoPlayer))
                        {
                            if (grabCam.transform.childCount > 0)
                            {
                                var itemHeld = grabCam.transform.GetChild(0).gameObject;
                                Destroy(itemHeld);
                            }

                            switch (videoPlayer.clipIndex)
                            {
                                case VideoConsole.ClipIndex.BlueCart:
                                // "I'm stuck here"
                                    if (clipIndex.Contains(1))
                                    {
                                        videoPlayer.PlayCartridge(1);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.GreenCart:
                                // Morse code
                                    if (clipIndex.Contains(2))
                                    {
                                        videoPlayer.PlayCartridge(2);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.CreamCart:
                                // "Dodgy coding"
                                    if (clipIndex.Contains(3))
                                    {
                                        videoPlayer.PlayCartridge(3);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.RedCart:
                                // Medical interview
                                    if (clipIndex.Contains(4))
                                    {
                                        videoPlayer.PlayCartridge(4);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.PurpleCart:
                                // "In over my head"
                                    if (clipIndex.Contains(5))
                                    {
                                        videoPlayer.PlayCartridge(5);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.PinkCart:
                                // "I can't save them"
                                    if (clipIndex.Contains(6))
                                    {
                                        videoPlayer.PlayCartridge(6);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.WhiteCart:
                                // "Last few patients"
                                    if (clipIndex.Contains(7))
                                    {
                                        videoPlayer.PlayCartridge(7);
                                    }
                                    break;
                                case VideoConsole.ClipIndex.OrangeCart:
                                // "I know what he's gonna do"
                                    if (clipIndex.Contains(8))
                                    {
                                        videoPlayer.PlayCartridge(8);
                                    }
                                    break;
                            }

                            item = null;
                        }

                        if (hit.collider.TryGetComponent(out LeverComboCheck leverComboCheck))
                        {
                            leverComboCheck.CheckLeverCombination();
                        }

                        if (hit.collider.TryGetComponent(out LeverComboID lever))
                        {
                            lever.PullLever();
                        }
                    }
                    #endregion
                }
            }
            else
            {
                // Checking if interactable
                if (Physics.Raycast(playerCam.transform.position,
                                    playerCam.transform.forward,
                                    interactDistance,
                                    layerInteractable))
                {
                    // If hit returns associated lock for key
                    switch (item.objectType)
                    {
                        case InteractableObject.ObjectType.Key:
                            item.UseKey();
                            break;
                    }

                    item = null;
                    isHolding = false;
                }
            }
        }
    }
}
