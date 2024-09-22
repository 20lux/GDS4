using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips = new VideoClip[9];
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
        player.SetTargetAudioSource(1, audioSource);
        player.clip = clips[i];
    }

    public void EndReached(VideoPlayer vp)
    {
        vp = player;
        vp.clip = clips[0];
        endClip = true;
    }
}
