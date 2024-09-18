using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject cartridge;
    public AudioSource audioSource;
    public VideoClip[] clips = new VideoClip[9];
    public clipIndex clipID;

    public enum clipIndex
    {
        BlueCart = 0,
        GreenCart = 1,
        CreamCart = 2,
        RedCart = 3,
        PurpleCart = 4,
        PinkCart = 5,
        WhiteCart = 6,
        OrangeCart = 7
    }

    void Awake()
    {
        player = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();
        player.clip = clips[0];
        player.loopPointReached += EndReached;
    }

    public void PlayCartridge(int i)
    {
        if (i < 0 || i >= clips.Length)
        {
            Debug.LogErrorFormat(   "Cannot play video #{0}. The array contains {1} video(s)",
                                    i, clips.Length);
        }

        Debug.Log("Playing clip: " + clipID.ToString());
        player.clip = clips[i];
    }

    public void EndReached(VideoPlayer vp)
    {
        vp = player;
        vp.clip = clips[0];
    }
}
