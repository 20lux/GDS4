using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechLabObjectBoundaryCheck : MonoBehaviour
{
    private Vector3 originalPosition;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            audioSource.Play();
            transform.position = originalPosition;
        }
    }
}
