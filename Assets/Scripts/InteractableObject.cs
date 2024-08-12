using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] enum ObjectType {  None = 0, 
                                        Console = 1, 
                                        Key = 2, 
                                        PickableObject = 3 }

    [Header("Interactable Object Properties")]
    [SerializeField] private string ObjectName;
    [HideInInspector] public string objectName => ObjectName;
    [SerializeField] private GameObject objectToInteractWith;

    public void GetObjectTransform(Transform interactorTransform)
    {
        gameObject.transform.position = interactorTransform.position;  
    }

    public string GetInteractText()
    {
        return ObjectName;
    }
}
