using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EngineRoomGrate : MonoBehaviour
{
    public GameObject grateObject;
    public Rigidbody rb;

    void Awake()
    {
        rb = grateObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnTriggerEnter()
    {
        rb.isKinematic = false;
    }
}
