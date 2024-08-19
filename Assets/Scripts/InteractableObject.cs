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
    [SerializeField] private bool IsLocked;
    [HideInInspector] public bool isLocked => IsLocked;
    int layerIgnoreRaycast;

    private void Start()
    {
        layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");

        if (objectType != ObjectType.Console)
        {
            objectRigidBody = GetComponent<Rigidbody>();
        }
        
        if (objectType == ObjectType.Lock)
        {
            IsLocked = true;
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
        if (objectToInteractWith.TryGetComponent(out InteractableObject interactedLock))
        {
            Debug.Log("Interacting with lock");

            interactedLock.IsLocked = false;
            objectToInteractWith.GetComponentInChildren<MeshRenderer>().material = objectToInteractWith.GetComponent<InteractableObject>().newMaterial;
            objectToInteractWith.gameObject.transform.GetChild(0).gameObject.layer = layerIgnoreRaycast;
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

    public string GetObjectName()
    {
        return ObjectName;
    }
}
