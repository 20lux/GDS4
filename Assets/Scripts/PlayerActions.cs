using System.Collections.Generic;
using NavKeypad;
using Unity.VisualScripting;
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
                            isEnd = true;
                        }

                        if (hit.collider.TryGetComponent(out VideoConsole videoPlayer))
                        {
                            if (grabCam.transform.childCount > 0)
                            {
                                var itemHeld = grabCam.transform.GetChild(0).gameObject;
                                Destroy(itemHeld);
                            }

                            switch (videoPlayer.clipID)
                            {
                                case VideoConsole.clipIndex.BlueCart:
                                // "I'm stuck here"
                                    if (clipIndex.Contains(1))
                                    {
                                        videoPlayer.PlayCartridge(1);
                                    }
                                    break;
                                case VideoConsole.clipIndex.GreenCart:
                                // Morse code
                                    if (clipIndex.Contains(2))
                                    {
                                        videoPlayer.PlayCartridge(2);
                                    }
                                    break;
                                case VideoConsole.clipIndex.CreamCart:
                                // "Dodgy coding"
                                    if (clipIndex.Contains(3))
                                    {
                                        videoPlayer.PlayCartridge(3);
                                    }
                                    break;
                                case VideoConsole.clipIndex.RedCart:
                                // Medical interview
                                    if (clipIndex.Contains(4))
                                    {
                                        videoPlayer.PlayCartridge(4);
                                    }
                                    break;
                                case VideoConsole.clipIndex.PurpleCart:
                                // "In over my head"
                                    if (clipIndex.Contains(5))
                                    {
                                        videoPlayer.PlayCartridge(5);
                                    }
                                    break;
                                case VideoConsole.clipIndex.PinkCart:
                                // "I can't save them"
                                    if (clipIndex.Contains(6))
                                    {
                                        videoPlayer.PlayCartridge(6);
                                    }
                                    break;
                                case VideoConsole.clipIndex.WhiteCart:
                                // "Last few patients"
                                    if (clipIndex.Contains(7))
                                    {
                                        videoPlayer.PlayCartridge(7);
                                    }
                                    break;
                                case VideoConsole.clipIndex.OrangeCart:
                                // "I know what he's gonna do"
                                    if (clipIndex.Contains(8))
                                    {
                                        videoPlayer.PlayCartridge(8);
                                    }
                                    break;
                            }

                            item = null;
                        }
                    }
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
