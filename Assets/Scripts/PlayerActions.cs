using System;
using TMPro;
using UnityEditor;
using UnityEditor.Search;
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
                // not carrying anything and trying to grab
                if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, 
                                out RaycastHit hit, interactDistance, layerInteractable))
                {
                    Debug.DrawLine(playerCam.transform.position, hit.point, Color.green, 1f);
                    Debug.Log(hit.transform);


                        if (hit.transform.TryGetComponent(out interactableObject))
                        {
                            Debug.Log("Trying to pick up interactable object!");

                            interactableObject.Grab(playerLookTransform.transform);
                        }
                }
            }
            else
            {
                // Currently carrying something, drop
                interactableObject.Drop();
                interactableObject = null;
            }
        }
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
