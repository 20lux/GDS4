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
            if (collider.TryGetComponent(out interactableObject))
            {
                HighlightObject(collider);
            }
        }
    }

    public void InteractWithObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            Debug.Log("Did not hit");    
        }
    }

    public void HighlightObject(Collider col)
    {
        UIText.text = col.gameObject.GetComponent<InteractableObject>().objectName;
        Debug.Log("Highlighting object");
    }

    public void ClearUI()
    {
        UIText.text = " ";
    }
}
