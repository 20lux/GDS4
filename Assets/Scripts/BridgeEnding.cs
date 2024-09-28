using UnityEngine;
using UnityEngine.Video;

public class BridgeEnding : MonoBehaviour
{
    public VideoPlayer bridgeMonitor;
    public VideoClip[] bridgeClips = new VideoClip[2];
    public AudioSource bridgeAudioSource;
    public GameController gameController;
    public bool hasInteracted;

    void Awake()
    {
        bridgeAudioSource = GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
        bridgeMonitor = GetComponent<VideoPlayer>();
        bridgeMonitor.clip = bridgeClips[0];
        bridgeMonitor.isLooping = true;
        hasInteracted = false;
    }

    public void PlayBridgeEnding()
    {
        if (!hasInteracted)
        {
            Debug.Log("Playing loading clip");
            bridgeAudioSource.Play();
            bridgeMonitor.clip = bridgeClips[1];
            bridgeMonitor.isLooping = false;
            gameController.startCountdown = true;
            hasInteracted = true;
        }
    }
}