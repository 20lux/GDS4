using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips = new VideoClip[8];
    public bool endClip = false;

    void Awake()
    {
        player = GetComponent<VideoPlayer>();
        player.isLooping = true;
        player.clip = clips[0];
        player.loopPointReached += EndReached;
    }

    public void LoadClip(int i, AudioSource audioSource)
    {   
        if (i < 0 || i >= clips.Length)
        {
            Debug.LogErrorFormat(   "Cannot play video #{0}. The array contains {1} video(s)",
                                    i, clips.Length);
        }
        player.audioOutputMode = VideoAudioOutputMode.AudioSource;
        player.EnableAudioTrack(0, true);
        player.SetTargetAudioSource(0, audioSource);
        player.controlledAudioTrackCount = 1;
        player.clip = clips[i];
        Debug.Log("Loading clip: " + i.ToString());
    }

    public void EndReached(VideoPlayer vp)
    {
        Debug.Log("End reached");
        vp = player;
        vp.clip = clips[0];
        endClip = true;
    }
}
