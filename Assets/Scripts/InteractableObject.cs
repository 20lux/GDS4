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
    private Rigidbody objectRigidBody;
    private Transform objectGrabTransform;
    
    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();
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

    public enum ObjectType 
    {    
        None = 0, 
        Console = 1, 
        Key = 2, 
        PickableObject = 3,
        PlaceableSpace = 4,
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

    public void ObjectAction(GameObject playerLookObject)
    {
        switch (objectType)
        {
            case ObjectType.None:
                break;
            case ObjectType.Console:
                break;
            case ObjectType.Key:
                break;
            case ObjectType.PickableObject:
                Debug.Log("Interacting with object!");
                Grab(playerLookObject.transform);
                break;
            case ObjectType.PlaceableSpace:
                break;
            case ObjectType.InspectObject:
                break;
        }
    }

    public string GetInteractText()
    {
        return ObjectName;
    }
}
