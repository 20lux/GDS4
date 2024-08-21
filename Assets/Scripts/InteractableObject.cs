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

    public void Grab(GameObject grabCam)
    {
        // Puts object in front of grab camera
        gameObject.transform.SetParent(grabCam.transform);
        gameObject.transform.position = grabCam.transform.position;
        objectRigidBody.isKinematic = true;
    }

    public void Drop(Transform playerCamTransform)
    {
        // Drops object in front of player
        gameObject.transform.SetParent(null);
        gameObject.transform.position = playerCamTransform.position;
        objectRigidBody.isKinematic = false;
    }

    public void UseKey(InteractableObject obj)
    {
        Debug.Log("Interacting with lock");

        obj.IsLocked = false;
        objectToInteractWith.GetComponentInChildren<MeshRenderer>().material = objectToInteractWith.GetComponent<InteractableObject>().newMaterial;
        objectToInteractWith.gameObject.transform.GetChild(0).gameObject.layer = layerIgnoreRaycast;
        gameObject.SetActive(false);
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

    public string GetObjectName()
    {
        return ObjectName;
    }
}
