using UnityEngine;
using UnityEngine.Video;

public class BridgeEnding : MonoBehaviour
{
    public VideoPlayer bridgeMonitor;
    public AudioSource bridgeAudioSource;
    public GameController gameController;
    public DoorAnimations doorAnimations;
    public bool hasInteracted;

    void Awake()
    {
        bridgeMonitor.isLooping = false;
        hasInteracted = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!hasInteracted)
        {
            doorAnimations.CloseAnimation();
            PlayBridgeEnding();
        }
    }

    public void PlayBridgeEnding()
    {
        if (!hasInteracted)
        {
            bridgeAudioSource.Play();
            hasInteracted = true;
            gameController.startCountdown = true;
        }
    }
}