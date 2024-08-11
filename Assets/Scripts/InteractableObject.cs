using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [Header("Interactable Object Properties")]
    [SerializeField] private string ObjectName;
    [HideInInspector] public string objectName => ObjectName;
    [SerializeField] private bool objectIsDoor;
    [SerializeField] private bool objectIsPickable;
    [SerializeField] private bool objectIsConsole;

    public void Interact(Transform interactorTransform)
    {

    }

    public string GetInteractText()
    {
        return ObjectName;
    }
}
