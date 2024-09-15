using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerStay()
    {
        audioSource.Play();
    }
}
