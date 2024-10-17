using UnityEngine;
using UnityEngine.Experimental.Audio;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] clips = new VideoClip[9];

    void Awake()
    { 
        player = GetComponent<VideoPlayer>();
        player.isLooping = true;
        player.clip = clips[0];
        player.loopPointReached += EndReached;
    }

    public void LoadClip(int i)
    {   
        if (i < 0 || i >= clips.Length)
        {
            Debug.LogErrorFormat(   "Cannot play video #{0}. The array contains {1} video(s)",
                                    i, clips.Length);
        }

        player.clip = clips[i];
    }

    public void EndReached(VideoPlayer vp)
    {
        vp = player;
        vp.clip = clips[0];
    }
}
