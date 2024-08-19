using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Interactable Object Properties")]
    public ObjectType objectType;
    [SerializeField] private string ObjectName;
    [HideInInspector] public string objectName => ObjectName;
    [SerializeField] private GameObject objectToInteractWith;
    [SerializeField] private Material newMaterial;
    private Rigidbody objectRigidBody;
    private Transform objectGrabTransform;
    private int layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");

    private void Start()
    {
        if (objectType != ObjectType.Console)
        {
            objectRigidBody = GetComponent<Rigidbody>();
        }
    }

    public void Grab(Transform playerLookTransform)
    {
        objectGrabTransform = playerLookTransform;
        objectRigidBody.useGravity = false;
    }

    public void Drop()
    {
        objectGrabTransform = null;
        objectRigidBody.useGravity = true;
    }

    public void UseKey()
    {
        objectToInteractWith.GetComponentInChildren<MeshRenderer>().material = newMaterial;
        objectToInteractWith.gameObject.transform.GetChild(0).gameObject.layer = layerIgnoreRaycast;
    }

    public void RemoteDoorUnlock()
    {
        if (objectToInteractWith.TryGetComponent(out DoorController doorController))
        {
            doorController.UnlockDoor();
        }        
    }

    public enum ObjectType 
    {    
        None = 0, 
        Console = 1, 
        Key = 2,
        Lock = 3, 
        GrabObject = 4,
        InspectObject = 5 
    }

    private void FixedUpdate()
    {
        if (objectGrabTransform != null)
        {
            Vector3 newPosition = objectGrabTransform.position;
            objectRigidBody.MovePosition(newPosition);
        }
    }

    public string GetInteractText()
    {
        return ObjectName;
    }
}
