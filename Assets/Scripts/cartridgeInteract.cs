using UnityEngine;

public class cartridgeInteract : MonoBehaviour 
{
    public int cartridgeIndex;
    public PlayVideo PlayVideo;

    public void pickUpCartridge()
    {
        if (PlayVideo.beingHeld == false)
        {
            PlayVideo.beingHeld = true;
        }
    }

    public void dropCartridge()
    {
        if (PlayVideo.beingHeld == true)
        {
            PlayVideo.beingHeld = false;
        }
    }
}
