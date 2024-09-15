using Unity.VisualScripting;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private AudioClip teleportAudio;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = teleportAudio;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out FirstPersonMovement player))
        {
            audioSource.time = 1.5f;
            audioSource.Play();
            player.Teleport(destination.position, destination.rotation);
            player.isTeleporting = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(destination.position, 0.4f);
        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }

}
