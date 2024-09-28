using UnityEngine;

public class BridgeEnding : MonoBehaviour
{
    public AudioSource bridgeAudioSource;

    void Awake()
    {
        bridgeAudioSource = GetComponent<AudioSource>();
    }

    public void PlayBridgeEnding()
    {
        bridgeAudioSource.Play();
    }
}