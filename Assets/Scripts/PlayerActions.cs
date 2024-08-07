using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private TextMeshProUGUI UIText;
    private InteractableObject interactableObject;

    void Start()
    {
        ClearUI();
    }

    void FixedUpdate()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactDistance);

        foreach (Collider collider in colliderArray)
        {
            Debug.Log("Detected collider object: " + collider.gameObject.name);
        }
    }

    public void InteractWithObject()
    {
        Debug.Log("Interacting with object");
    }

    public void HighlightObject(Collider col)
    {
        Debug.Log("Highlighting object");
    }

    public void ClearUI()
    {
        UIText.text = " ";
    }
}
