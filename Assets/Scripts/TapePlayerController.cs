using UnityEngine;

public class TapePlayerController : MonoBehaviour
{
    public AudioSource tapePlayerAudioSource;
    public GameObject reelOne;
    public GameObject reelTwo;

    public void PlayTape()
    {
        var count = 0;
        tapePlayerAudioSource.Play();
        while (tapePlayerAudioSource.isPlaying)
        {
            count += 1;
            reelOne.transform.localRotation = new Quaternion(0, 0, count, 0);
            reelTwo.transform.localRotation = new Quaternion(0, 0, count, 0);
        }
    }
}
