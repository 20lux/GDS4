using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Player Interation Properties")]
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private TextMeshProUGUI UIText;
    int layerMask = 1 >> 8;
    private InteractableObject interactableObject;

    void Start()
    {
        ClearUI();
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, interactDistance))
        {
            if(hit.collider.tag == "InteractObject")
            {
                Debug.DrawRay(transform.position, Vector3.forward, Color.yellow);
                HighlightObject(hit);
            }
            else
            {
                Debug.DrawRay(transform.position, Vector3.forward, Color.white);
                ClearUI();
            }
        }
    }

    public void InteractWithObject()
    {
        Debug.Log("Interacting with object");
    }

    public void HighlightObject(RaycastHit hit)
    {
        UIText.text = hit.collider.gameObject.GetComponent<InteractableObject>().objectName;
    }

    public void ClearUI()
    {
        UIText.text = " ";
    }
}
