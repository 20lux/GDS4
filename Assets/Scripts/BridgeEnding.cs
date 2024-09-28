using UnityEngine;
using UnityEngine.Video;

public class BridgeEnding : MonoBehaviour
{
    public VideoPlayer bridgeMonitor;
    public VideoClip[] bridgeClips = new VideoClip[2];
    public AudioSource bridgeAudioSource;
    public GameController gameController;
    private bool hasInteracted = false;

    void Awake()
    {
        bridgeAudioSource = GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
        bridgeMonitor = GetComponent<VideoPlayer>();
        bridgeMonitor.clip = bridgeClips[0];
        bridgeMonitor.isLooping = true;
    }

    public void PlayBridgeEnding()
    {
        if (!hasInteracted)
        {
            bridgeAudioSource.Play();
            bridgeMonitor.clip = bridgeClips[1];
            bridgeMonitor.isLooping = false;
            gameController.startCountdown = true;
            hasInteracted = true;
        }
    }
}