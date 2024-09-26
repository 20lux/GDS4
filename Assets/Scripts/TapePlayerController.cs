using UnityEngine;

public class TapePlayerController : MonoBehaviour
{
    public AudioSource tapePlayerAudioSource;

    public void PlayTape()
    {
        tapePlayerAudioSource.Play();
    }
}
