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

    public void GetObjectTransform(Transform interactorTransform)
    {
        gameObject.transform.position = interactorTransform.position;  
    }

    public enum ObjectType 
    {    
        None = 0, 
        Console = 1, 
        Key = 2, 
        PickableObject = 3,
        InspectObject = 4 
    }

    public void ObjectAction(GameObject playerObject)
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
