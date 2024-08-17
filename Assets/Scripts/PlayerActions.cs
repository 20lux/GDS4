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
    private InteractableObject interactableObject;
    [SerializeField] private Transform playerLookTransform;
    [SerializeField] private LayerMask layerInteractable;
 
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
            if (interactableObject == null)
            {
                // not carrying anything and trying to interact
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, 
                                out RaycastHit hit, interactDistance, layerInteractable))
                {
                    Debug.DrawLine(playerCam.transform.position, hit.point, Color.green, 1f);
                    Debug.Log(hit.transform);


                        if (hit.transform.TryGetComponent(out interactableObject))
                        {
                            //Debug.Log("Trying to pick up interactable object!");
                            switch (interactableObject.objectType)
                            {
                                case InteractableObject.ObjectType.GrabObject:
                                    interactableObject.Grab(playerLookTransform.transform);
                                    break;
                                case InteractableObject.ObjectType.Console:
                                    Debug.Log("Looking at screen!");
                                    FreeMouse();
                                    break;
                            }
                        }
                }
            }
            else
            {
                switch (interactableObject.objectType)
                {
                    // Currently carrying something, drop
                    case InteractableObject.ObjectType.GrabObject:
                        interactableObject.Drop();
                        interactableObject = null;
                        break;
                }
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
            Debug.Log("Highlighting object");
        }
        else
        {
            UIText.text = " ";
        }
    }
}
