using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    private double duration;
    public VideoClip defaultClip;

    public void PlayCartridge(VideoClip clip)
    {
        player.clip = clip;
        player.Play();
        duration = clip.length;
    }

    private void Update()
    {
        if (duration >= 0)
        {
            duration -= Time.deltaTime;
        }
        else if (duration < 0)
        {
            PlayStatic();
        }
    }

    public void PlayStatic()
    {
        player.clip = defaultClip;
        player.isLooping = true;
        player.Play();
    }
}
