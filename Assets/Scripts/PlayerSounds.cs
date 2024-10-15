using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [Header("Player Sound Properties")]
    public AudioSource playerAudioSource;
    public AudioClip[] thinkingSounds;
    public AudioClip[] needMoreDataSounds;
    public AudioClip[] lockedSounds;
    public AudioClip[] notWorkingSounds;
    public AudioClip[] progressionSounds;
    public AudioClip[] movePlayer;
    public AudioClip[] screamSounds;
    public AudioClip[] panicSounds;
    public AudioClip SOSAccessSound;
    public AudioClip selfdestructAccessSound;
    public AudioClip airlockAccessSound;

    void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlayThinkingSounds()
    {
        var i = Random.Range(0, thinkingSounds.Length);
        playerAudioSource.clip = thinkingSounds[i];
        playerAudioSource.Play();
    }

    public void PlayMoreDataSounds()
    {
        var i = Random.Range(0, needMoreDataSounds.Length);
        playerAudioSource.clip = needMoreDataSounds[i];
        playerAudioSource.Play();
    }

    public void PlayLockedSounds()
    {
        var i = Random.Range(0, lockedSounds.Length);
        playerAudioSource.clip = lockedSounds[i];
        playerAudioSource.Play();
    }

    public void PlayNotWorkingSounds()
    {
        var i = Random.Range(0, notWorkingSounds.Length);
        playerAudioSource.clip = notWorkingSounds[i];
        playerAudioSource.Play();
    }

    public void PlayProgressionSounds()
    {
        var i = Random.Range(0, progressionSounds.Length);
        playerAudioSource.clip = progressionSounds[i];
        playerAudioSource.Play();
    }

    public void PlayMovePlayerSounds()
    {
        var i = Random.Range(0, movePlayer.Length);
        playerAudioSource.clip = movePlayer[i];
        playerAudioSource.Play();
    }

    public void PlayScreamSounds()
    {
        var i = Random.Range(0, screamSounds.Length);
        playerAudioSource.clip = screamSounds[i];
        playerAudioSource.Play();
    }

    public void PlayPanicSounds()
    {
        var i = Random.Range(0, panicSounds.Length);
        playerAudioSource.clip = panicSounds[i];
        playerAudioSource.Play();
    }

    public void PlayAirlockAccessSound()
    {
        playerAudioSource.clip = airlockAccessSound;
        playerAudioSource.Play();
    }

    public void PlaySelfDestructSound()
    {
        playerAudioSource.clip = selfdestructAccessSound;
        playerAudioSource.Play();
    }

    public void PlaySOSAccessSound()
    {
        playerAudioSource.clip = SOSAccessSound;
        playerAudioSource.Play();
    }
}
