using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [Header("Interactable Object Properties")]
    [SerializeField] private string ObjectName;
    [HideInInspector] public string objectName => ObjectName;
}
