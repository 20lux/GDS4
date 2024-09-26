using UnityEngine;
using UnityEngine.Video;

public class BridgeEnding : MonoBehaviour
{
    public VideoPlayer bridgeVideoPlayer;
    public VideoClip[] bridgeVideoClips;
    public AudioSource bridgeAudioSource;

    void Start()
    {
        bridgeVideoPlayer = GetComponent<VideoPlayer>();
        bridgeVideoPlayer.isLooping = true;
        bridgeVideoPlayer.clip = bridgeVideoClips[0];
    }

    public void PlayBridgeEnding()
    {
        bridgeVideoPlayer.playbackSpeed = 0.1f;
        bridgeVideoPlayer.clip = bridgeVideoClips[1];
        bridgeAudioSource.Play();
    }
}