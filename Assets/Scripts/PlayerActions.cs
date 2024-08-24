using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private Camera playerCam;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private GameObject grabCam;
    [SerializeField] private GameObject playerDrop;
    [SerializeField] private LayerMask layerInteractable;
    [SerializeField] private InteractableObject thisInteractableObject;
 
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

    public void PlayerInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (thisInteractableObject == null)
            {
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, interactDistance, layerInteractable))
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
                            case InteractableObject.ObjectType.Cartridge:
                                thisInteractableObject.Grab(grabCam);
                                break;                                
                            case InteractableObject.ObjectType.Console:
                                break;
                        }
                    }
                }
            }
            else
            {
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, interactDistance, layerInteractable))
                {
                    if (hit.collider.tag == "Door")
                    {
                        Debug.Log("Trying to open door");
                        switch (thisInteractableObject.objectType)
                        {
                            case InteractableObject.ObjectType.Key:
                                thisInteractableObject.UseKey();
                                break;
                        }
                    }

                    if (hit.collider.tag == "Console")
                    {
                        Debug.Log("Using console!");
                        switch (thisInteractableObject.objectType)
                        {
                            case InteractableObject.ObjectType.Cartridge:
                                Debug.Log("Putting in cartridge!");
                                thisInteractableObject.UseConsole(thisInteractableObject);
                                break;
                        }
                    }
                }
                else
                {
                    thisInteractableObject.Drop(playerDrop.transform);
                }

                thisInteractableObject = null;
            }
        }
    }

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
