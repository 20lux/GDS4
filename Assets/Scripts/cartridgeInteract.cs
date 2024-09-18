using UnityEngine;
using UnityEngine.Video;

public class cartridgeInteract : MonoBehaviour 
{
    public VideoClip videoClip;
    public PlayVideo consoleForCartridge;

    public void pickUpCartridge()
    {
        if (consoleForCartridge.beingHeld == false)
        {
            consoleForCartridge.beingHeld = true;
        }
    }

    public void dropCartridge()
    {
        if (consoleForCartridge.beingHeld == true)
        {
            consoleForCartridge.beingHeld = false;
        }
    }
}
