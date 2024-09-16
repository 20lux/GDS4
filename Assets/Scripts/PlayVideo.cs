using UnityEngine;
using UnityEngine.Video;


public class PlayVideo : MonoBehaviour
{
    public VideoPlayer player;
    public VideoClip[] videos;
    public int videoClipIndex;
    private double duration;
    public bool beingHeld;

    private void Start()
    {
        player.clip = videos[0];
        player.Play();
    }

    public void playVideo()
    {
        if (beingHeld == true)
        {
            player.clip = videos[videoClipIndex];
            player.Play();
            duration = videos[videoClipIndex].length;
            //GetComponentInChildren<MeshRenderer>().enabled = true;
        }
        
    }
    private void Update()
    {
        if (duration >= 0)
        {
            duration -= Time.deltaTime;
        }
        else if (duration < 0)
        {
            player.clip = videos[0];
            player.Play();
            //GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
