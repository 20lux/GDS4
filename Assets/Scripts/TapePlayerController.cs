using UnityEngine;

public class TapePlayerController : MonoBehaviour
{
    public AudioSource tapePlayerAudioSource;
    public Animator reelOne;
    public Animator reelTwo;

    void Awake()
    {
        reelOne.enabled = false;
        reelTwo.enabled = false;
    }

    void Update()
    {
        if (!tapePlayerAudioSource.isPlaying)
        {
            reelOne.enabled = false;
            reelTwo.enabled = false;
            reelOne.SetInteger("AudioState", 0);
            reelTwo.SetInteger("AudioState", 0);
        }
    }

    public void PlayTape()
    {
        reelOne.enabled = true;
        reelTwo.enabled = true;
        tapePlayerAudioSource.Play();
        reelOne.SetInteger("AudioState", 1);
        reelTwo.SetInteger("AudioState", 1);
    }
}
