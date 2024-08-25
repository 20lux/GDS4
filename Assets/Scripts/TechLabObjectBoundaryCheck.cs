using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechLabObjectBoundaryCheck : MonoBehaviour
{
    private Vector3 originalPosition;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        originalPosition = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Target")
        {
            audioSource.Play();
            transform.position = originalPosition;
        }
    }
}
