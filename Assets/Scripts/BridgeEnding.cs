using UnityEngine;
using UnityEngine.Video;

public class BridgeEnding : MonoBehaviour
{
    public VideoPlayer bridgeMonitor;
    public AudioSource bridgeAudioSource;
    public GameController gameController;
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