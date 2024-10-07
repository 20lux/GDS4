using UnityEngine;
using UnityEngine.Video;

public class BridgeEnding : MonoBehaviour
{
    public VideoPlayer bridgeMonitor;
    public VideoClip[] bridgeClips = new VideoClip[2];
    public AudioSource bridgeAudioSource;
    public GameController gameController;
    public DoorAnimations doorAnimations;
    public bool hasInteracted;

    void Awake()
    {
        bridgeMonitor.clip = bridgeClips[0];
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
            bridgeMonitor.clip = bridgeClips[1];
            bridgeMonitor.isLooping = false;
            hasInteracted = true;
            gameController.startCountdown = true;
        }
    }
}