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
    [HideInInspector] public ObjectType type;

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
        switch (type)
        {
            case ObjectType.None:
                break;
            case ObjectType.Console:
                break;
            case ObjectType.Key:
                break;
            case ObjectType.PickableObject:
                Transform playerLookTransform = playerObject.transform.GetChild(1).transform;
                transform.SetParent(playerLookTransform);
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
