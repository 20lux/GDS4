using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    AudioSource audioSource;
    private bool hasPlayed = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        if (!hasPlayed)
        {
            audioSource.Play();
            hasPlayed = true;
        }
    }
}
