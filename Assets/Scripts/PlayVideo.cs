using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public GameObject cartridge;
    private double duration = 0;
    public VideoClip[] clips = new VideoClip[8];
    public VideoClip defaultClip;
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

    public void PlayCartridge(int i)
    {
        Debug.Log("Playing clip: " + clipID.ToString());
        player.clip = clips[i];
        duration = clips[i].length;
    }

    private void Update()
    {
        if (duration >= 0)
        {
            duration -= Time.deltaTime;
        }
        else if (duration <= 0)
        {
            PlayStatic();
        }
    }

    public void PlayStatic()
    {
        player.clip = defaultClip;
    }
}
