using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips = new VideoClip[9];
    public bool endClip = false;
    private bool hasPlayed = false;
    private AudioSource triggerAudioSource;

    void Awake()
    { 
        player = GetComponent<VideoPlayer>();
        player.isLooping = true;
        player.clip = clips[0];
        player.loopPointReached += EndReached;
    }

    public void LoadClip(int i, AudioSource consoleAudioSource, AudioSource triggerAudioSource)
    {   
        this.triggerAudioSource = triggerAudioSource;
        if (i < 0 || i >= clips.Length)
        {
            Debug.LogErrorFormat(   "Cannot play video #{0}. The array contains {1} video(s)",
                                    i, clips.Length);
        }
        player.audioOutputMode = VideoAudioOutputMode.AudioSource;
        player.EnableAudioTrack(0, true);
        player.SetTargetAudioSource(0, consoleAudioSource);
        player.controlledAudioTrackCount = 1;
        player.clip = clips[i];
        Debug.Log("Loading clip: " + i.ToString());
    }

    public void Update()
    {
        if (endClip && !hasPlayed)
        {
            hasPlayed = false;
            triggerAudioSource.Play();
        }
    }

    public void EndReached(VideoPlayer vp)
    {
        Debug.Log("End clip reached");
        if (vp.clip != clips[0])
        {
            endClip = true;
        }
        vp = player;
        vp.clip = clips[0];
    }
}
