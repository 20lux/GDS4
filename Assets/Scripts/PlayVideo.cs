using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject cartridge;
    private double duration = 0;
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

    void Start()
    {
        player.clip = clips[0];
        player.playOnAwake = false;
        player.isLooping = true;
        player.loopPointReached += EndReached;
        player.Play();
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

        player.Prepare();

        while (!player.isPrepared)
        {
            Debug.Log("Preparing video");
        }
        Debug.Log("Done prearing video!");
    }

    public void EndReached(VideoPlayer player)
    {
        player.clip = clips[0];
    }
}
